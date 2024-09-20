using UnityEngine;

public class CakeFill : MonoBehaviour
{
    public GameObject objectToFill; // 引用需要填充的物體
    public float fillTime = 10f; // 填充時間（秒）
    public float maxAlpha = 1f; // 最大透明度

    private float elapsedTime = 0f; // 已經過的時間
    private SpriteRenderer spriteRenderer; // 物體的SpriteRenderer組件
    private Color originalColor; // 物體的原始顏色

    void Start()
    {
        spriteRenderer = objectToFill.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // 逐漸增加透明度
        if (elapsedTime < fillTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fillTime) * maxAlpha;
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
        }
        else
        {
            // 當時間到達時，確保透明度為最大值
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, maxAlpha);
        }
    }
}
