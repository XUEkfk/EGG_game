using UnityEngine;

public class EggCakeRotate : MonoBehaviour
{
    public float rotationSpeed = 93f; // ����t��

    void Update()
    {
        // �C������Ϥ�
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}