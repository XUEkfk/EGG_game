using Uduino;
using UnityEngine.UI;
using UnityEngine;

public class IUSlider : MonoBehaviour
{
    public int button = 9; //�ĴX���}
    public GameObject buttonGameObject;
    public Slider slider;
    public Text messageText;
    public float increaseSpeed = 1.0f; // ����W�[�t��
    private float timer; // ??��

    int buttonValue = 0;
    int prevButtonValue = 0;


    void Start()
    {
        slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        timer = 0f; // ��l��??��
        UduinoManager.Instance.pinMode(button, PinMode.Input_pullup);
    }

    void Update()
    {
        UpdateSliderValue();
        CheckSliderValue();
        CheckMouseButton();
      
        buttonValue = UduinoManager.Instance.digitalRead(button);

        // In this case, we compare the current button value to the previous button value, 
        // to trigger the change only once the value change.
        if (buttonValue != prevButtonValue)
        {
            if (buttonValue == 0)
            {
                CheckMouseButton();
            }
            prevButtonValue = buttonValue; // Here we assign prev button value to the new value
        }

    }

    void UpdateSliderValue()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            slider.value += increaseSpeed;
            timer = 0f; // ���m??��
        }
    }

    void CheckSliderValue()
    {
        if (slider.value >= 20f)
        {
            messageText.text = "���U�ť���";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                slider.value = 0f;
                Debug.Log("�ť�?�Q���U");
            }
        }
        else
        {
            messageText.text = "";
        }

        if (slider.value == 25f)
        {
            slider.value = 0f;
        }
    }

    void CheckMouseButton()
    {
        if (Input.GetMouseButtonDown(0)) // 0 ��ܥ�?
        {
            slider.value += 0.5f;
            Debug.Log("��?�Q���U");
        }
    }

    void OnSliderValueChanged()
    {
        // ?��slider��?��
        Debug.Log("Slider value: " + slider.value);
    }
}