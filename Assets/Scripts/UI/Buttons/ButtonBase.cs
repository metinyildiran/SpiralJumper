using UnityEngine;
using UnityEngine.EventSystems;

namespace Buttons
{
    public abstract class ButtonBase : MonoBehaviour, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            OnPressed();
        }

        protected abstract void OnPressed();
    }
}