using UnityEngine;

public abstract class UIPanelBase : TouchPress
{
    protected override void OnTouchPressed(Touch touch)
    {
        OnPressed();
    }

    protected abstract void OnPressed();
}
