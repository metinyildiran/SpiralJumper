using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    private AudioSource _audioSource;
    private GameObject splashParticle;
    private GameObject splashObject;

    private float jumpForce = 400.0f;
    private bool isJumping;
    private bool isCollided;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

        jumpForce *= _rb.mass;

        splashParticle = Resources.Load<GameObject>("Prefabs/SplashParticle");
        splashObject = Resources.Load<GameObject>("Prefabs/Splash");
    }

    private void Update()
    {
        DrawBottomRay();
    }

    private void DrawTopRay()
    {
        Vector3 position = transform.position + new Vector3(-1, 0.5f);
        Vector3 direction = new Vector3(2, 0, 0);

        Debug.DrawRay(position, direction, Color.green);

        if (!Physics.Raycast(position, direction))
        {
            GameManager.instance.SetCanRotateCylinder(true);
        }
    }

    private void DrawBottomRay()
    {
        Vector3 position = transform.position + new Vector3(-1, 0.15f);
        Vector3 direction = new Vector3(2, 0, 0);

        Debug.DrawRay(position, direction, Color.red);

        if (Physics.Raycast(position, direction))
        {
            GameManager.instance.SetCanFollow(true);
            GameManager.instance.SetCanRotateCylinder(false);

            //foreach (RaycastHit hit in Physics.RaycastAll(position, direction))
            //{
            //    Destroy(hit.collider.gameObject.transform.parent.gameObject);
            //}
        }
        else
        {
            DrawTopRay();
        }
    }

    private void SetCanRotateCylinder()
    {
        GameManager.instance.SetCanRotateCylinder(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Jump();

        if (isCollided) return;

        isCollided = true;

        if (collision.contacts[0].normal == Vector3.up)
        {
            GameManager.instance.SetCanFollow(false);

            SpawnSplashObject(collision);

            DOBounce(transform);
        }

        Invoke(nameof(SetIsCollidedFalse), 0.1f);
    }

    private void SpawnSplashObject(Collision collision)
    {
        if (!transform) return;

        SpawnSplashParticle();

        GameObject splash = Instantiate(splashObject);

        splash.transform.position = transform.position + new Vector3(0, 0.05f);
        splash.transform.DORotate(new Vector3(0, Random.Range(0, 360)), 0.0f);
        splash.transform.parent = collision.transform.parent;
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

    private void Jump()
    {
        if (isJumping) return;

        isJumping = true;

        SetIsCollidedFalse();

        _rb.AddForce(Vector3.up * jumpForce);

        Invoke(nameof(SetIsJumpingFalse), 0.1f);
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
}
