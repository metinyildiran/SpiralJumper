using UnityEngine;

public abstract class TouchBase : MonoBehaviour
{
    protected Touch touch;

    protected virtual void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
    }
}
