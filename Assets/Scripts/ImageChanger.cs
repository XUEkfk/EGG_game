using UnityEngine;
using UnityEngine.UI;

public class IconChanger : MonoBehaviour
{
    public Slider triggerSlider; // �Ʊ줸��
    public GameObject objectToChange; // �ݭn�󴫹ϼЪ��C����H
    public Sprite spriteOne; // �ϼФ@
    public Sprite spriteTwo; // �ϼФG

    private SpriteRenderer spriteRenderer; // �C����H�� SpriteRenderer

    void Start()
    {
        if (objectToChange != null)
        {
            // ����C����H�W�� SpriteRenderer ����
            spriteRenderer = objectToChange.GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        // �ˬd�Ʊ쪺�ƭȬO�_�F��10���p��20
        if (triggerSlider.value >= 10 && triggerSlider.value < 20)
        {
            ChangeIcon(spriteOne);
        }
        // �ˬd�Ʊ쪺�ƭȬO�_�F��20
        else if (triggerSlider.value >= 20)
        {
            ChangeIcon(spriteTwo);
        }
    }

    void ChangeIcon(Sprite newSprite)
    {
        // �󴫹ϼЪ���k
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}