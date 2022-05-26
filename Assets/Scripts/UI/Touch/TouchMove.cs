using UnityEngine;

public abstract class TouchMove : TouchBase
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (touch.phase == TouchPhase.Moved)
        {
            OnTouchMoved(touch);
        }
    }

    protected abstract void OnTouchMoved(Touch touch);
}
