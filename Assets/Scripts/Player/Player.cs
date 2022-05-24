using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    private AudioSource _audioSource;
    private GameObject splashParticle;

    private float jumpForce = 400.0f;
    private bool isJumping;
    private bool isCollided;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

        jumpForce *= _rb.mass;

        splashParticle = Resources.Load<GameObject>("Prefabs/SplashParticle");
    }

    private void Start()
    {
        GameManager.instance.onGameStop += StopBall;

        DOTween.Init(true, true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isCollided) return;

        isCollided = true;

        if (collision.contacts[0].normal == Vector3.up)
        {
            GameManager.instance.SetCanFollow(false);

            SpawnSplashObject(collision);

            DOBounce(transform);
        }

        if (collision.gameObject.CompareTag("RedObject"))
        {
            GameManager.instance.GameFailed();
        }
        else
        {
            Jump();
        }

        Invoke(nameof(SetIsCollidedFalse), 0.2f);
    }

    private void SpawnSplashObject(Collision collision)
    {
        if (!transform) return;

        SpawnSplashParticle();

        GameObject splash = SplashPooler.SharedInstance.GetPooledObject();

        splash.transform.position = transform.position + new Vector3(0, 0.05f);
        splash.transform.DORotate(new Vector3(0, Random.Range(0, 360)), 0.0f);
        splash.transform.parent = collision.transform.parent;

        splash.SetActive(true);
    }

    private void SpawnSplashParticle()
    {
        Instantiate(splashParticle, transform.position, Quaternion.Euler(new Vector3(-90, 0)));
    }

    private void DOBounce(Transform transform)
    {
        if (!transform) return;

        PlayJumpingSound();

        Sequence sequence = DOTween.Sequence();
        sequence
            .Append(transform.DOScaleZ(0.6f, 0.1f))
            .Append(transform.DOScaleZ(1f, 0.1f))
            .Append(transform.DOShakeScale(0.1f, strength: 0.2f, vibrato: 1, randomness: 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.SetCanRotateCylinder(false);
        GameManager.instance.SetCanFollow(true);
    }

    private void OnTriggerExit(Collider other)
    {
        print("triggered");

        GameManager.instance.SetCanRotateCylinder(true);
    }

    private void Jump()
    {
        if (isJumping) return;

        _rb.AddForce(Vector3.up * jumpForce);

        isJumping = true;

        Invoke(nameof(SetIsJumpingFalse), 0.2f);
    }

    private void SetIsJumpingFalse()
    {
        isJumping = false;
    }

    private void SetIsCollidedFalse()
    {
        isCollided = false;
    }

    private void PlayJumpingSound()
    {
        _audioSource.PlayRandomly();
    }

    private void StopBall()
    {
        _rb.velocity = Vector3.zero;
    }
}
