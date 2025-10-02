using UnityEngine;
using Uduino;

public class InputManager2 : MonoBehaviour
{
    public static InputManager2 Instance { get; private set; }
    private int arduinoButtonPressCount = 0;
    public int buttonDing = 11; // 出餐按鍵
    private int button2Value = 1; // 按鈕狀態初始為未按下
    private int prevButton2Value = 1; // 上一次的按鈕狀態

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 在這裡設置 Arduino 按鈕的 pin
        UduinoManager.Instance.pinMode(buttonDing, PinMode.Input_pullup);
    
    }

    void Update()
    {
        // 在這裡檢測 Arduino 按鈕的狀態
        button2Value = UduinoManager.Instance.digitalRead(buttonDing);
        
        if (button2Value == 0 && prevButton2Value == 1) // 按鈕從未按下變為按下
        {
            Debug.Log("分數加成");
            //arduinoButtonPressCount++;
            GetArduinoButtonPressCount();

        }
        
        prevButton2Value = button2Value; // 更新上一次的按鈕狀態
    }

    public int GetArduinoButtonPressCount()
    {
        Debug.Log("數值加成"+arduinoButtonPressCount);
        return arduinoButtonPressCount++;
    }

    public void ResetArduinoButtonPressCount()
    {
        Debug.Log("分數初始化");
        arduinoButtonPressCount = 0;
    }
}
