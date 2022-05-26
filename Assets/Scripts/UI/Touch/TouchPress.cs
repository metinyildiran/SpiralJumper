using UnityEngine;

public abstract class TouchPress : TouchBase
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (touch.phase == TouchPhase.Ended)
        {
            print("fdffgfgfdgfd");
            OnTouchPressed(touch);
        }
    }

    protected abstract void OnTouchPressed(Touch touch);
}
