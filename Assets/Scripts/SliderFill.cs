using UnityEngine;
using UnityEngine.UI;

public class SliderFill : MonoBehaviour
{
    public Slider slider; // �ޥ�Slider?��
    public float fillTime = 10f; // ��q?�R???�]��^

    private float elapsedTime = 0f; // �w??�h��??

    void Start()
    {
        // ��l��Slider��?0
        if (slider != null)
        {
            slider.value = 0f;
        }
    }

    void Update()
    {
        // �v?�W�[Slider����
        if (slider != null)
        {
            elapsedTime += Time.deltaTime;
            slider.value = Mathf.Clamp01(elapsedTime / fillTime);

            // Debug�H��
            Debug.Log("Slider Value: " + slider.value);
        }
    }
}