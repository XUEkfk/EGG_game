using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PF01 : MonoBehaviour
{
    public GameObject eggPrefab; // �w�s����
    public float X = 5f; // �w�s����ͦ���X�b��m
    public float Y = 5f; // �w�s����ͦ���Y�b��m

    public Slider triggerSlider; // �Ʊ줸��
    public Sprite spriteOne; // �ϼФ@
    public Sprite spriteTwo; // �ϼФG
    public Sprite spriteThree; // �ϼФT

    private SpriteRenderer spriteRenderer; // �w�s���� SpriteRenderer
    private GameObject instantiatedEgg; // �s�x�w��Ҥƪ��w�s����

    // Start is called before the first frame update
    void Start()
    {
        // ��ҤƤ@�ӷs���w�s����b���w����m
        Vector3 position = new Vector3(X, Y, 0f);
        instantiatedEgg = Instantiate(eggPrefab, position, Quaternion.identity);

        // ����w�s����W�� SpriteRenderer ����
        if (instantiatedEgg != null)
        {
            spriteRenderer = instantiatedEgg.GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer != null)
        {
            // �ˬd�Ʊ쪺�ƭȬO�_�F��10���p��20
            if (triggerSlider.value >= 10 && triggerSlider.value < 20)
            {
                ChangeIcon(spriteOne);
            }
            // �ˬd�Ʊ쪺�ƭȬO�_�F��20���p��30
            else if (triggerSlider.value >= 20 && triggerSlider.value < 30)
            {
                ChangeIcon(spriteTwo);
            }
            // �ˬd�Ʊ쪺�ƭȬO�_�F��30
            else if (triggerSlider.value >= 30)
            {
                ChangeIcon(spriteThree);
            }
        }
    }

    void ChangeIcon(Sprite newSprite)
    {
        // �󴫹ϼЪ���k
        if (newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}