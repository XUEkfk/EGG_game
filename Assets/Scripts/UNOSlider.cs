using UnityEngine;
using UnityEngine.UI;
using Uduino;
using System.Collections;

public class UNOSlider : MonoBehaviour
{
    public Slider slider;
    public Text messageText;
    public float increaseSpeed = 1.0f; // 控制增加速度
    private float timer; // 計時器
    public GameObject prefab2; // 引用預製件2
    public Animator animator; // 引用動畫控制器

    public int buttonSlider = 9;
    public int buttonEx = 11;

    int buttonValue = 0; 
    int prevButtonValue = 0;
    int button2Value = 0;
    int prevButton2Value = 0;  //註解需拿掉

    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        timer = 0f; // 初始化計時器
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
            timer = 0f; // 重置計時器
        }
    }

    void CheckSliderValue()
    {
        button2Value = UduinoManager.Instance.digitalRead(buttonEx);
        if (slider.value >= 20f)
        {
            messageText.text = "按下按鈕";
            if (button2Value == 0 )
            {
                slider.value = 0f;
                Debug.Log("按鈕已被按下");
                animator.SetBool("pot", true);
                prefab2.SetActive(true); // 啟用預製件

            }
            else 
            {
                animator.SetBool("pot", false);
                Debug.Log("按鈕已被放開");
                WaitForPrefabValue(); // 等待動畫播完
            }
            prevButton2Value = button2Value;
        }
        else
        {
            messageText.text = ""; // 清除提示訊息
        }

        if (slider.value >= 31f)
        {
            slider.value = 0f;
        }
    }

    void OnSliderValueChanged(float value)
    {
        // 顯示slider的數值
        Debug.Log("Slider value: " + slider.value);
    }

    void CheckButtonState()
    {
        buttonValue = UduinoManager.Instance.digitalRead(buttonSlider);

        // 只在值改變時觸發
        if (buttonValue != prevButtonValue)
        {
            if (buttonValue == 0)
            {
                Debug.Log("加速0.5");
                slider.value += 0.5f;
            }
            prevButtonValue = buttonValue; // 將當前按鈕值設置為之前按鈕值
        }
    }

    void WaitForPrefabValue()
    {
        StartCoroutine(DisablePrefabAfterDelay(3f)); // 啟動協程，等待2秒後禁用預製件
    }

    IEnumerator DisablePrefabAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 等待指定的延遲時間
        //prefab2.SetActive(false); // 禁用預製件
    }
}