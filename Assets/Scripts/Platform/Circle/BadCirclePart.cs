using UnityEngine;

public class BadCirclePart : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.GameFailed();
    }
}
