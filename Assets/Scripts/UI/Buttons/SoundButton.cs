using UnityEngine;
using UnityEngine.UI;

public class SoundButton : ButtonBase
{
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;
    private Image imageComponent;

    private void Awake()
    {
        imageComponent = GetComponent<Image>();
    }

    private void Start()
    {
        SetButtonSprite();
    }

    protected override void OnPressed()
    {
        AudioManager.Instance.ToggleMute();

        SetButtonSprite();
    }

    private void SetButtonSprite()
    {
        imageComponent.sprite = AudioManager.Instance.IsMuted ? soundOffSprite : soundOnSprite;
    }
}
