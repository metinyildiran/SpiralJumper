using UnityEngine;

public abstract class TouchBase : MonoBehaviour
{
    private Touch touch;

    protected virtual void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            CheckTouchPhase(touch);
        }
    }

    protected abstract void CheckTouchPhase(Touch touch);
}
