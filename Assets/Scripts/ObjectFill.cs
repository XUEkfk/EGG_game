using UnityEngine;

public class ObjectFill : MonoBehaviour
{
    public RectTransform objectToFill; // �ޥλݭn��R������RectTransform
    public float fillTime = 10f; // ����R���ɶ��]��^

    private float elapsedTime = 0f; // �w�g�L�h���ɶ�
    private float initialWidth; // ���󪺪�l�e��
    private float targetWidth; // ���󪺥ؼмe��

    void Start()
    {
        if (objectToFill != null)
        {
            initialWidth = objectToFill.sizeDelta.x;
            targetWidth = objectToFill.parent.GetComponent<RectTransform>().sizeDelta.x;
            // ��l�ƪ���e�׬�0
            objectToFill.sizeDelta = new Vector2(0f, objectToFill.sizeDelta.y);
        }
    }

    void Update()
    {
        // �v���W�[���󪺼e��
        if (objectToFill != null)
        {
            elapsedTime += Time.deltaTime;
            float newWidth = Mathf.Lerp(0f, targetWidth, elapsedTime / fillTime);
            objectToFill.sizeDelta = new Vector2(newWidth, objectToFill.sizeDelta.y);

            // Debug�H��
            Debug.Log("Object Width: " + newWidth);

            // ���R�ɶ������ɡA�T�O�e�׬��ؼмe��
            if (elapsedTime >= fillTime)
            {
                objectToFill.sizeDelta = new Vector2(targetWidth, objectToFill.sizeDelta.y);
            }
        }
    }
}
