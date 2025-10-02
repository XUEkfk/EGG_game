using UnityEngine;
using Uduino;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public int wKeyPressCount = 0;
    public int buttonDing = 11; //出餐按鍵

    int button2Value = 0; //出餐按鍵
    int prevButton2Value = 0;

    void Start()
    {
        UduinoManager.Instance.pinMode(buttonDing, PinMode.Input_pullup);
    }

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

    void Update()
    {
        if (button2Value == 0)
        {
            Debug.Log("分數加分");
            wKeyPressCount++;
    
        }
    }

    public int GetWKeyPressCount()
    {
        return wKeyPressCount;
    }

    public void setWKeyPressCount()
    {
        Debug.Log("分數初始化");
        wKeyPressCount = 0;
    
    }
}