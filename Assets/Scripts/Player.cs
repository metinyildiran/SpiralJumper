using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private readonly float jumpForce = 250.0f;
    private bool isJumping;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter()
    {
        Jump();
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
}
