using UnityEngine;

public class eggDown : MonoBehaviour
{
    public Vector2 targetPosition; // ��?��m
    public float speed = 1.0f; // ��?�t��

    void Update()
    {
        // �ϥ�MoveTowards��k??�H??�e��m��?���?��m
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}