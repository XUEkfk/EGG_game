using UnityEngine;
using UnityEngine.UI;

public class IconChanger : MonoBehaviour
{
    public Slider triggerSlider; // 滑桿元件
    public GameObject objectToChange; // 需要更換圖標的遊戲對象
    public Sprite spriteOne; // 圖標一
    public Sprite spriteTwo; // 圖標二

    private SpriteRenderer spriteRenderer; // 遊戲對象的 SpriteRenderer

    void Start()
    {
        if (objectToChange != null)
        {
            // 獲取遊戲對象上的 SpriteRenderer 元件
            spriteRenderer = objectToChange.GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        // 檢查滑桿的數值是否達到10但小於20
        if (triggerSlider.value >= 10 && triggerSlider.value < 20)
        {
            ChangeIcon(spriteOne);
        }
        // 檢查滑桿的數值是否達到20
        else if (triggerSlider.value >= 20)
        {
            ChangeIcon(spriteTwo);
        }
    }

    void ChangeIcon(Sprite newSprite)
    {
        // 更換圖標的方法
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}