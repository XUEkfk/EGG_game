using UnityEngine;

public class ObjectFill : MonoBehaviour
{
    public RectTransform objectToFill; // 引用需要填充的物件的RectTransform
    public float fillTime = 10f; // 物件充滿時間（秒）

    private float elapsedTime = 0f; // 已經過去的時間
    private float initialWidth; // 物件的初始寬度
    private float targetWidth; // 物件的目標寬度

    void Start()
    {
        if (objectToFill != null)
        {
            initialWidth = objectToFill.sizeDelta.x;
            targetWidth = objectToFill.parent.GetComponent<RectTransform>().sizeDelta.x;
            // 初始化物件寬度為0
            objectToFill.sizeDelta = new Vector2(0f, objectToFill.sizeDelta.y);
        }
    }

    void Update()
    {
        // 逐漸增加物件的寬度
        if (objectToFill != null)
        {
            elapsedTime += Time.deltaTime;
            float newWidth = Mathf.Lerp(0f, targetWidth, elapsedTime / fillTime);
            objectToFill.sizeDelta = new Vector2(newWidth, objectToFill.sizeDelta.y);

            // Debug信息
            Debug.Log("Object Width: " + newWidth);

            // 當填充時間結束時，確保寬度為目標寬度
            if (elapsedTime >= fillTime)
            {
                objectToFill.sizeDelta = new Vector2(targetWidth, objectToFill.sizeDelta.y);
            }
        }
    }
}
