using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        var transform1 = transform.position;
        transform1.y = player.transform.position.y + 2.0f;

        transform.position = transform1;
    }
}
