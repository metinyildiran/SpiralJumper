using UnityEngine;

public abstract class TouchPress : TouchBase
{

    protected override void CheckTouchPhase(Touch touch)
    {
        if (touch.phase == TouchPhase.Ended)
        {
            OnTouchPressed(touch);
        }
    }

    protected abstract void OnTouchPressed(Touch touch);
}
