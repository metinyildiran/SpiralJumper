using UnityEngine;

public class BottomCircle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.GameFinished();
    }
}
