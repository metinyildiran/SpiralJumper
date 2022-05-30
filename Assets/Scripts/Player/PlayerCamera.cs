using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        SetPerspectiveSize();
    }

    private void Update()
    {
        if (GameManager.instance.IsGameFailed()) return;

        if (GameManager.instance.GetCanFollow())
        {
            FollowPlayer();
        }
    }

    private void SetPerspectiveSize()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.fieldOfView = Mathf.Floor(1920 / currentAspect / 75.85f);
    }

    private void FollowPlayer()
    {
        if (!player) return;

        Vector3 transform1 = transform.position;
        transform1.y = player.transform.position.y + 3.0f;

        transform.position = transform1;
    }
}
