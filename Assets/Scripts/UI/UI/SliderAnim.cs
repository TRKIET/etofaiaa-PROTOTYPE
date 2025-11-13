using UnityEngine;
using UnityEngine.UI;

public class SliderAnim : MonoBehaviour
{
    public Slider slider;
    public Image handleImage;
    public Sprite birdClosed;    // 羽根を閉じた画像
    public Sprite birdHalfOpen;  // 羽根を半分開いた画像（追加）
    public Sprite birdOpen;      // 羽根を開いた画像

    private float previousValue;

    void Start()
    {
        previousValue = slider.value;
        slider.onValueChanged.AddListener(OnSliderMoved);
        UpdateBirdSprite(slider.value);
    }

    void OnSliderMoved(float newValue)
    {
        UpdateBirdSprite(newValue);

        // 向きの変更
        if (newValue < previousValue)
        {
            handleImage.rectTransform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            handleImage.rectTransform.localScale = new Vector3(1, 1, 1);
        }

        previousValue = newValue;
    }

    void UpdateBirdSprite(float value)
    {
        if (value < 0.33f)
        {
            handleImage.sprite = birdClosed;
        }
        else if (value < 0.66f)
        {
            handleImage.sprite = birdHalfOpen;
        }
        else
        {
            handleImage.sprite = birdOpen;
        }
    }
}