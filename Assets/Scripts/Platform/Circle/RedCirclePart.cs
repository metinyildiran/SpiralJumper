using UnityEngine;

public class RedCirclePart : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameFailed();
        }
    }
}
