using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (GameManager.instance.GetCanFollow())
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        if (!player) return;

        Vector3 transform1 = transform.position;
        transform1.y = player.transform.position.y + 3.0f;

        transform.position = transform1;
    }
}
