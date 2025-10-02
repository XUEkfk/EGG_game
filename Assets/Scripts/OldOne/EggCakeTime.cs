using UnityEngine;
using UnityEngine.UI;

public class EggCakeTime : MonoBehaviour
{
    public Image fillImage; // 引用Image組件
    public float fillTime = 10f; // 圖片充滿時間（秒）

    private float elapsedTime = 0f; // 已經過去的時間
    private RectTransform rectTransform; // 圖片的RectTransform

    void Start()
    {
        if (fillImage != null)
        {
            rectTransform = fillImage.GetComponent<RectTransform>();
            // 初始化圖片寬度為0
            rectTransform.sizeDelta = new Vector2(0f, rectTransform.sizeDelta.y);
        }
    }

    void Update()
    {
        // 逐漸增加圖片的寬度
        if (rectTransform != null)
        {
            elapsedTime += Time.deltaTime;
            float width = Mathf.Clamp01(elapsedTime / fillTime) * rectTransform.parent.GetComponent<RectTransform>().sizeDelta.x;
            rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);

            // Debug信息
            Debug.Log("Image Width: " + width);
        }
    }
}