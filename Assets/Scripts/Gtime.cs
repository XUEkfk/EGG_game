using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gtime : MonoBehaviour
{
    public Slider time; // �Ʊ줸��
    public float decrementValue = 1f; // �C���֪��ƭ�

    private float timer; // �p�ɾ�

    void Start()
    {
        // ��l�ƭp�ɾ�
        timer = 0f;
    }

    void Update()
    {
        // �W�[�p�ɾ�
        timer += Time.deltaTime;

        // ��p�ɾ��F��1��ɴ�ַƱ쪺��
        if (timer >= 1f)
        {
            time.value -= decrementValue;
            timer = 0f; // ���m�p�ɾ�
             Debug.Log("��e�Ʊ�ƭ�: " + time.value); // ��X��e�Ʊ쪺�ƭ�
            if (time.value == 0)
            {
                SceneManager.LoadScene("Settlement");
            }
        }
    }
}