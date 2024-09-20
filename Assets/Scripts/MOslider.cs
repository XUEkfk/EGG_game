using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MOSlider : MonoBehaviour
{
    public Slider slider; // �ޥηƱ줸��
    public Text messageText; // �ޥ���ܰT�����奻����
    public float increaseSpeed = 1.0f; // ����Ʊ�ȼW�[���t��
    public GameObject prefab2; // �ޥιw�s��2
    public Animator animator; // �ޥΰʵe���
    private float timer; // �p�ɾ�

    void Start()
    {
        // ��Ʊ쪺�ȵo���ܤƮɡA����OnSliderValueChanged��k
        slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        timer = 0f; // ��l�ƭp�ɾ�
    }

    void Update()
    {
        UpdateSliderValue(); // ��s�Ʊ��
        CheckSliderValue(); // �ˬd�Ʊ�ȬO�_�F��S�w����
        CheckMouseButton(); // �ˬd�ƹ�����O�_�Q���U
    }

    void UpdateSliderValue()
    {
        timer += Time.deltaTime; // �p�ɾ��֥[�ɶ�
        if (timer >= 1f)
        {
            slider.value += increaseSpeed; // �C��W�[�Ʊ��
            timer = 0f; // ���m�p�ɾ�
        }
    }

    void CheckSliderValue()
    {
        if (slider.value >= 20f)
        {
            messageText.text = "���U�ť���"; // ���ܥΤ���U�ť���
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("pot", true);
                prefab2.SetActive(true); // �ҥιw�s��
                GameObject.Find("�J��(Clone)").SetActive(false);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("pot", false);
                StartCoroutine(DisablePrefabAfterDelay(2.5f)); // ���ݰʵe����
            }
        }
        else
        {
            messageText.text = ""; // �M�����ܰT��
        }

        // �ˬd�Ʊ�ȬO�_�F�� 31�A�p�G�O�A���m�� 0
        if (Mathf.Approximately(slider.value, 31f))
        {
            slider.value = 0f;
        }
    }

    void CheckMouseButton()
    {
        if (Input.GetMouseButtonDown(0)) // 0 ��ܥ���
        {
            slider.value += 0.5f; // �C�����U�ƹ�����W�[�Ʊ��0.5
            Debug.Log("�ƹ��Q���U");
        }
    }

    void OnSliderValueChanged()
    {
        // ���slider���ƭ�
        Debug.Log("Slider value: " + slider.value);
    }

    IEnumerator DisablePrefabAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        // �������檺�N�X
        prefab2.SetActive(false); // �T�ιw�s��
        GameObject.Find("�J��(Clone)").SetActive(true);
        Debug.Log("��ܳJ��1");
    }
}