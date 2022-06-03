using UnityEngine;
using UnityEngine.UI;

public class SoundButton : ButtonBase
{
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;
    private bool isMuted;
    private Image imageComponent;

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt(nameof(isMuted), 0) == 0)
        {
            isMuted = false;
        }
        else
        {
            isMuted = true;
        }

        SetButtonSprite();
    }

    protected override void OnPressed()
    {
        isMuted = AudioManager.Instance.ToggleMute();

        SetButtonSprite();
    }

    private void SetButtonSprite()
    {
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
