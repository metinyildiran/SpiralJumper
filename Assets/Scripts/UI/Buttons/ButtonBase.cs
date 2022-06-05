using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ButtonBase : MonoBehaviour, IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        AudioManager.Instance.PlayButtonClick();

        OnPressed();
    }

    protected abstract void OnPressed();
}
