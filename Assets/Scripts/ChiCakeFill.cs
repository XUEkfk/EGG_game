using UnityEngine;
using UnityEngine.UI;

public class ChiCakeFill : MonoBehaviour
{
    public Slider slider; // �ޥ�Slider�ե�
    public float fillTime = 10f; // ��R�ɶ��]��^
    private float elapsedTime = 0f; // �w�g�L���ɶ�

    void Update()
    {
        // �v���W�[Slider����
        if (elapsedTime < fillTime)
        {
            elapsedTime += Time.deltaTime;
            float fillValue = Mathf.Clamp01(elapsedTime / fillTime);
            slider.value = fillValue;
        }
        else
        {
            // ��ɶ���F�ɡA�T�OSlider���Ȭ��̤j�ȡ]1�^
            slider.value = 1f;
        }
    }
}
