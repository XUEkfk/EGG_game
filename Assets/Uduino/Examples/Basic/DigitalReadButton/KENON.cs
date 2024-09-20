using System.Collections;
using UnityEngine;
using Uduino;

public class KENON : MonoBehaviour
{
    public int interruptPin = 3; // 中斷引腳
    public GameObject buttonGameObject;

    private bool interruptTriggered = false; // 標記中斷是否觸發

    void Start()
    {
        // 初始化串行通信
        UduinoManager.Instance.OnBoardConnected += OnBoardConnected; 
    }

    void OnBoardConnected(UduinoDevice connectedDevice)
    {
        // 設置引腳模式
        UduinoManager.Instance.SetBoardType(connectedDevice, "Arduino Uno");
        UduinoManager.Instance.pinMode(interruptPin, PinMode.Input_pullup);

        // 註冊中斷回調
        UduinoManager.Instance.OnDataReceived += OnDataReceived;
    }

    void OnDataReceived(string data, UduinoDevice device)
    {
        if (data == "Knock on!")
        {
            interruptTriggered = true;
        }
    }

    void Update()
    {
        // 模擬 Arduino 的 loop() 函數
        if (interruptTriggered)
        {
            Procedure();
            interruptTriggered = false;
        }
        
        Debug.Log("1");
        StartCoroutine(Delay(0.2f)); // 模擬 Arduino 的 delay(200)
    }

    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
    }

    void Procedure()
    {
        // 模擬 Arduino 的 procedure() 函數
        Debug.Log("0");
        StartCoroutine(Delay(0.1f)); // 模擬 Arduino 的 delay(100)
        PressedDown(); // 當中斷觸發時調用按鈕按下效果
    }

    void PressedDown()
    {
        buttonGameObject.GetComponent<Renderer>().material.color = Color.red;
        buttonGameObject.transform.Translate(Vector3.down / 20);
    }

    void PressedUp()
    {
        buttonGameObject.GetComponent<Renderer>().material.color = Color.green;
        buttonGameObject.transform.Translate(Vector3.up / 20);
    }
}