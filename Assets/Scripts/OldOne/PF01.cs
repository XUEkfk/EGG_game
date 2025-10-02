using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PF01 : MonoBehaviour
{
    public GameObject eggPrefab; // 預製物件
    public float X = 5f; // 預製物件生成的X軸位置
    public float Y = 5f; // 預製物件生成的Y軸位置

    public Slider triggerSlider; // 滑桿元件
    public Sprite spriteOne; // 圖標一
    public Sprite spriteTwo; // 圖標二
    public Sprite spriteThree; // 圖標三

    private SpriteRenderer spriteRenderer; // 預製物件的 SpriteRenderer
    private GameObject instantiatedEgg; // 存儲已實例化的預製物件

    // Start is called before the first frame update
    void Start()
    {
        // 實例化一個新的預製物件在指定的位置
        Vector3 position = new Vector3(X, Y, 0f);
        instantiatedEgg = Instantiate(eggPrefab, position, Quaternion.identity);

        // 獲取預製物件上的 SpriteRenderer 元件
        if (instantiatedEgg != null)
        {
            spriteRenderer = instantiatedEgg.GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer != null)
        {
            // 檢查滑桿的數值是否達到10但小於20
            if (triggerSlider.value >= 10 && triggerSlider.value < 20)
            {
                ChangeIcon(spriteOne);
            }
            // 檢查滑桿的數值是否達到20但小於30
            else if (triggerSlider.value >= 20 && triggerSlider.value < 30)
            {
                ChangeIcon(spriteTwo);
            }
            // 檢查滑桿的數值是否達到30
            else if (triggerSlider.value >= 30)
            {
                ChangeIcon(spriteThree);
            }
        }
    }

    void ChangeIcon(Sprite newSprite)
    {
        // 更換圖標的方法
        if (newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}