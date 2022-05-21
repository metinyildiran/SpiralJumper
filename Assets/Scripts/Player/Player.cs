using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    private readonly float jumpForce = 250.0f;
    private bool isJumping;

    private Rigidbody _rb;
    private AudioSource _audioSource;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

        GameManager.instance.onGameStop += StopBall;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            GameManager.instance.SetCanFollow(false);
        }

        if (collision.gameObject.CompareTag("RedObject"))
        {
            GameManager.instance.GameFailed();
        } else
        {
            Jump();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.SetCanRotateCylinder(false);
        GameManager.instance.SetCanFollow(true);
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.instance.SetCanRotateCylinder(true);
    }

    private void Jump()
    {
        if (isJumping) return;

        _rb.AddForce(Vector3.up * jumpForce);
        isJumping = true;

        Invoke(nameof(SetIsJumpingFalse), 0.2f);

        PlayJumpingSound();
    }

    private void SetIsJumpingFalse()
    {
        isJumping = false;
    }

    private void PlayJumpingSound()
    {
        _audioSource.pitch = Random.Range(0.95f, 1.05f);
        _audioSource.Play();
    }

    private void StopBall()
    {
        _rb.velocity = Vector3.zero;
    }
}
