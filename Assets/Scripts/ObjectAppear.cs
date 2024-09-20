using UnityEngine;

public class ObjectAppear : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // ���^�� SpriteRenderer ?��
    public float fillTime = 10f; // ��R??�]��^

    private Color originalColor; // ���^����l?��
    private float originalWidth; // ���^����l?��
    private float elapsedTime = 0f; // �w??��??

    void Start()
    {
        // ?�����^����l?��M?��
        originalColor = spriteRenderer.color;
        originalWidth = spriteRenderer.bounds.size.x;

        // ��l??���^���z����?�m?0
        Color newColor = originalColor;
        newColor.a = 0f;
        spriteRenderer.color = newColor;

        // ��l??���^��?��?�m?0
        Vector3 newScale = transform.localScale;
        newScale.x = 0f;
        transform.localScale = newScale;

        // ?���^����m��?��̥�?
        Vector3 newPosition = transform.position;
        newPosition.x -= originalWidth / 2f;
        transform.position = newPosition;
    }

    void Update()
    {
        // �v?�W�[���^��?�שM�z����
        if (elapsedTime < fillTime)
        {
            elapsedTime += Time.deltaTime;
            float ratio = Mathf.Clamp01(elapsedTime / fillTime);

            // ?�m�z���שM?��
            Color newColor = originalColor;
            newColor.a = 1f; // ?�m�z����?1
            spriteRenderer.color = newColor;

            Vector3 newScale = transform.localScale;
            newScale.x = originalWidth * ratio;
            transform.localScale = newScale;
        }
    }
}
