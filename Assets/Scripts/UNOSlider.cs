using UnityEngine;
using UnityEngine.UI;
using Uduino;
using System.Collections;

public class UNOSlider : MonoBehaviour
{
    public Slider slider;
    public Text messageText;
    public float increaseSpeed = 1.0f; // ����W�[�t��
    private float timer; // �p�ɾ�
    public GameObject prefab2; // �ޥιw�s��2
    public Animator animator; // �ޥΰʵe���

    public int buttonSlider = 9;
    public int buttonEx = 11;

    int buttonValue = 0; 
    int prevButtonValue = 0;
    int button2Value = 0;
    int prevButton2Value = 0;  //���ѻݮ���

    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        timer = 0f; // ��l�ƭp�ɾ�
        UduinoManager.Instance.pinMode(buttonSlider, PinMode.Input_pullup);
        UduinoManager.Instance.pinMode(buttonEx, PinMode.Input_pullup);
    }

    void Update()
    {
        UpdateSliderValue();
        CheckSliderValue();
        CheckButtonState();
    }

    void UpdateSliderValue()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            slider.value += increaseSpeed;
            timer = 0f; // ���m�p�ɾ�
        }
    }

    void CheckSliderValue()
    {
        button2Value = UduinoManager.Instance.digitalRead(buttonEx);
        if (slider.value >= 20f)
        {
            messageText.text = "���U���s";
            if (button2Value == 0 )
            {
                slider.value = 0f;
                Debug.Log("���s�w�Q���U");
                animator.SetBool("pot", true);
                prefab2.SetActive(true); // �ҥιw�s��

            }
            else 
            {
                animator.SetBool("pot", false);
                Debug.Log("���s�w�Q��}");
                WaitForPrefabValue(); // ���ݰʵe����
            }
            prevButton2Value = button2Value;
        }
        else
        {
            messageText.text = ""; // �M�����ܰT��
        }

        if (slider.value >= 31f)
        {
            slider.value = 0f;
        }
    }

    void OnSliderValueChanged(float value)
    {
        // ���slider���ƭ�
        Debug.Log("Slider value: " + slider.value);
    }

    void CheckButtonState()
    {
        buttonValue = UduinoManager.Instance.digitalRead(buttonSlider);

        // �u�b�ȧ��ܮ�Ĳ�o
        if (buttonValue != prevButtonValue)
        {
            if (buttonValue == 0)
            {
                Debug.Log("�[�t0.5");
                slider.value += 0.5f;
            }
            prevButtonValue = buttonValue; // �N��e���s�ȳ]�m�����e���s��
        }
    }

    void WaitForPrefabValue()
    {
        StartCoroutine(DisablePrefabAfterDelay(3f)); // �Ұʨ�{�A����2���T�ιw�s��
    }

    IEnumerator DisablePrefabAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���ݫ��w������ɶ�
        //prefab2.SetActive(false); // �T�ιw�s��
    }
}