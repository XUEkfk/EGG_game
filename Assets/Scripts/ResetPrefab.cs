using UnityEngine;

public class ResetPrefab : MonoBehaviour
{
    public GameObject prefabToReset; // 要重置的預製物件
    private Vector3 resetPosition; // 重置位置
    private Quaternion resetRotation; // 重置旋轉
    private SpriteRenderer spriteRenderer; // 預製物件的SpriteRenderer

    void Start()
    {
        // 儲存初始位置和旋轉
        resetPosition = prefabToReset.transform.position;
        resetRotation = prefabToReset.transform.rotation;

        // 獲取預製物件的SpriteRenderer
        spriteRenderer = prefabToReset.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 如果按下空白鍵，重置預製物件的位置和狀態
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetPrefabTransform();
        }
    }

    // 重置預製物件的位置、旋轉和圖片狀態
    public void ResetPrefabTransform()
    {
        // 將預製物件的位置和旋轉設置為初始值
        prefabToReset.transform.position = resetPosition;
        prefabToReset.transform.rotation = resetRotation;

        // 將不透明度設置為100%
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = 1.0f;
            spriteRenderer.color = color;
        }
    }
}