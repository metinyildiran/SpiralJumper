using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class UIPanelBase : MonoBehaviour
{
    private void OnMouseDown()
    {
        OnPressed();
    }

    protected abstract void OnPressed();
}
