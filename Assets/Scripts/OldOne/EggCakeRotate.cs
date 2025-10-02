using UnityEngine;

public class EggCakeRotate : MonoBehaviour
{
    public float rotationSpeed = 93f; // 旋轉速度

    void Update()
    {
        // 每楨旋轉圖片
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}