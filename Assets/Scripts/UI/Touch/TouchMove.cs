using UnityEngine;

public abstract class TouchMove : TouchBase
{

    protected override void CheckTouchPhase(Touch touch)
    {
        if (touch.phase == TouchPhase.Moved)
        {
            OnTouchMoved(touch);
        }
    }

    protected abstract void OnTouchMoved(Touch touch);
}
