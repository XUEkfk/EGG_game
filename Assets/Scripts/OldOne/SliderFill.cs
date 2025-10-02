using UnityEngine;
using UnityEngine.UI;

public class SliderFill : MonoBehaviour
{
    public Slider slider; // 引用Slider?件
    public float fillTime = 10f; // 能量?充???（秒）

    private float elapsedTime = 0f; // 已??去的??

    void Start()
    {
        // 初始化Slider值?0
        if (slider != null)
        {
            slider.value = 0f;
        }
    }

    void Update()
    {
        // 逐?增加Slider的值
        if (slider != null)
        {
            elapsedTime += Time.deltaTime;
            slider.value = Mathf.Clamp01(elapsedTime / fillTime);

            // Debug信息
            Debug.Log("Slider Value: " + slider.value);
        }
    }
}