using Core;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    private void OnMouseDown()
    {
        LevelManager.Instance.RestartLevel();
    }
}
