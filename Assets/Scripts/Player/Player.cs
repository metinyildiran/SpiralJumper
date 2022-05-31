using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    private AudioSource _audioSource;
    private GameObject splashParticle;
    private ParticleSystem specialParticle;
    private GameObject splashObject;
    private BoxCollider _boxCollider;

    private const float jumpForce = 350.0f;
    private const float maxSpeed = 15.0f;

    private bool isJumping;
    private bool isCollided;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider>();

        splashParticle = Resources.Load<GameObject>("Prefabs/SplashParticle");
        specialParticle = GameObject.FindGameObjectWithTag("SpecialParticle").GetComponent<ParticleSystem>();
        splashObject = Resources.Load<GameObject>("Prefabs/Splash");
    }

    private void Start()
    {
        GameManager.Instance.OnSpecialChanged += OnSpecialChanged;
        GameManager.Instance.OnGameFailed += DODestroyBall;
    }

    private void Update()
    {
        if (GameManager.Instance.CanPlayGame()) return;

        DrawBottomRay();
    }

    private void FixedUpdate()
    {
        if (_rb.velocity.magnitude > maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * maxSpeed;
        }
    }

    private void DrawBottomRay()
    {
        Vector3 position = transform.position + new Vector3(-3, 0.1f, 0.5f);
        Vector3 direction = new Vector3(6, 0, 0);

        Debug.DrawRay(position, direction, Color.red);

        Ray ray = new Ray(position, direction);
        if (Physics.Raycast(ray, out var hit, LayerMask.GetMask("CirclePiece")))
        {
            GameManager.Instance.SetCanFollow(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(GameManager.Instance.SetIsSpecialActive(false));

        if (GameManager.Instance.CanPlayGame()) return;

        #region Check Special
        if (GameManager.Instance.GetIsSpecialActive())
        {
            Jump();

            collision.gameObject.GetComponent<CirclePieceBase>().DestroyParent();

            StartCoroutine(GameManager.Instance.SetIsSpecialActive(false, 0.01f));

            return;
        }
        #endregion

        Jump();

        if (isCollided) return;

        isCollided = true;

        if (collision.contacts[0].normal == Vector3.up)
        {
            GameManager.Instance.SetCanFollow(false);

            SpawnSplashObject(collision);

            DOBounce(transform);
        }

        Invoke(nameof(SetIsCollidedFalse), 0.1f);
    }

    private void DODestroyBall()
    {
        if (!transform) return;

        transform.DOScale(Vector3.zero, 1f);
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

    private void OnSpecialChanged(bool isActive)
    {
        if (GameManager.Instance.GetIsGameFailed()) return;

        if (isActive)
        {
            specialParticle.Play();
        }
        else
        {
            specialParticle.Stop();
        }
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
