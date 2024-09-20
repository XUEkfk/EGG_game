using UnityEngine;
using UnityEngine.UI;

public class EggCakeTime : MonoBehaviour
{
    public Image fillImage; // �ޥ�Image�ե�
    public float fillTime = 10f; // �Ϥ��R���ɶ��]��^

    private float elapsedTime = 0f; // �w�g�L�h���ɶ�
    private RectTransform rectTransform; // �Ϥ���RectTransform

    void Start()
    {
        if (fillImage != null)
        {
            rectTransform = fillImage.GetComponent<RectTransform>();
            // ��l�ƹϤ��e�׬�0
            rectTransform.sizeDelta = new Vector2(0f, rectTransform.sizeDelta.y);
        }
    }

    void Update()
    {
        // �v���W�[�Ϥ����e��
        if (rectTransform != null)
        {
            elapsedTime += Time.deltaTime;
            float width = Mathf.Clamp01(elapsedTime / fillTime) * rectTransform.parent.GetComponent<RectTransform>().sizeDelta.x;
            rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);

            // Debug�H��
            Debug.Log("Image Width: " + width);
        }
    }
}