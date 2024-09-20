using UnityEngine;

public class CakeFill : MonoBehaviour
{
    public GameObject objectToFill; // �ޥλݭn��R������
    public float fillTime = 10f; // ��R�ɶ��]��^
    public float maxAlpha = 1f; // �̤j�z����

    private float elapsedTime = 0f; // �w�g�L���ɶ�
    private SpriteRenderer spriteRenderer; // ���骺SpriteRenderer�ե�
    private Color originalColor; // ���骺��l�C��

    void Start()
    {
        spriteRenderer = objectToFill.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // �v���W�[�z����
        if (elapsedTime < fillTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fillTime) * maxAlpha;
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
        }
        else
        {
            // ��ɶ���F�ɡA�T�O�z���׬��̤j��
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, maxAlpha);
        }
    }
}
