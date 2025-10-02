using UnityEngine;
using UnityEngine.UI;

public class ChiCakeFill : MonoBehaviour
{
    public Slider slider; // 引用Slider組件
    public float fillTime = 10f; // 填充時間（秒）
    private float elapsedTime = 0f; // 已經過的時間

    void Update()
    {
        // 逐漸增加Slider的值
        if (elapsedTime < fillTime)
        {
            elapsedTime += Time.deltaTime;
            float fillValue = Mathf.Clamp01(elapsedTime / fillTime);
            slider.value = fillValue;
        }
        else
        {
            // 當時間到達時，確保Slider的值為最大值（1）
            slider.value = 1f;
        }
    }
}
