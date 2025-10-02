using UnityEngine;

public class ObjectAppear : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // 物体的 SpriteRenderer ?件
    public float fillTime = 10f; // 填充??（秒）

    private Color originalColor; // 物体的原始?色
    private float originalWidth; // 物体的原始?度
    private float elapsedTime = 0f; // 已??的??

    void Start()
    {
        // ?取物体的原始?色和?度
        originalColor = spriteRenderer.color;
        originalWidth = spriteRenderer.bounds.size.x;

        // 初始??物体的透明度?置?0
        Color newColor = originalColor;
        newColor.a = 0f;
        spriteRenderer.color = newColor;

        // 初始??物体的?度?置?0
        Vector3 newScale = transform.localScale;
        newScale.x = 0f;
        transform.localScale = newScale;

        // ?物体的位置移?到最左?
        Vector3 newPosition = transform.position;
        newPosition.x -= originalWidth / 2f;
        transform.position = newPosition;
    }

    void Update()
    {
        // 逐?增加物体的?度和透明度
        if (elapsedTime < fillTime)
        {
            elapsedTime += Time.deltaTime;
            float ratio = Mathf.Clamp01(elapsedTime / fillTime);

            // ?置透明度和?度
            Color newColor = originalColor;
            newColor.a = 1f; // ?置透明度?1
            spriteRenderer.color = newColor;

            Vector3 newScale = transform.localScale;
            newScale.x = originalWidth * ratio;
            transform.localScale = newScale;
        }
    }
}
