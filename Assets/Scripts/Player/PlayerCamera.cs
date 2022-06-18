using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private GameObject player;
    private const float offsetY = 2.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        SetPerspectiveSize();
    }

    private void Update()
    {
        if (GameManager.Instance.GetIsGameFailed() || !GameManager.Instance.GetCanFollow()) return;

        FollowPlayer();
    }

    private void SetPerspectiveSize()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.fieldOfView = Mathf.Floor(1920 / currentAspect / 56f);
    }

    private void FollowPlayer()
    {
        if (!player) return;

        Vector3 transform1 = transform.position;
        transform1.y = player.transform.position.y + offsetY;

        transform.position = transform1;
    }
}
