using UnityEngine;
using UnityEngine.UI;

public class SoundButton : ButtonBase
{
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    protected override void OnPressed()
    {
        bool isMuted = AudioManager.Instance.ToggleMute();

        Image imageComponent = GetComponent<Image>();

        if (isMuted)
        {
            imageComponent.sprite = soundOffSprite;
        }
        else
        {
            imageComponent.sprite = soundOnSprite;
        }
    }
}
