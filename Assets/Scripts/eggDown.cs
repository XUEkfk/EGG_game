using UnityEngine;

public class eggDown : MonoBehaviour
{
    public Vector2 targetPosition; // 目?位置
    public float speed = 1.0f; // 移?速度

    void Update()
    {
        // 使用MoveTowards方法??象??前位置移?到目?位置
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}