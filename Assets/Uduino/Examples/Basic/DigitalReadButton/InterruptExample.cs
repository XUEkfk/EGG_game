using System.Collections;
using UnityEngine;
using Uduino;

public class InterruptExample : MonoBehaviour
{
    public int interruptPin = 3; // い耞ま竲

    void Start()
    {
        // ﹍て﹃︽硄獺
        UduinoManager.Instance.OnBoardConnected += OnBoardConnected; 
    }

    void OnBoardConnected(UduinoDevice connectedDevice)
    {
        // 砞竚ま竲家Α
        UduinoManager.Instance.SetBoardType(connectedDevice, "Arduino Uno");
        UduinoManager.Instance.pinMode(interruptPin, PinMode.Input_pullup);

        // 爹い耞秸
        UduinoManager.Instance.OnDataReceived += OnDataReceived;
    }

    void OnDataReceived(string data, UduinoDevice device)
    {
        if (data == "interrupt")
        {
            Procedure();
        }
    }

    void Update()
    {
        // 家览 Arduino  loop() ㄧ计
        Debug.Log("1");
        StartCoroutine(Delay(0.5f)); // 家览 Arduino  delay(500)
    }

    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
    }

    void Procedure()
    {
        // 家览 Arduino  procedure() ㄧ计
        Debug.Log("0");
        StartCoroutine(Delay(0.1f)); // 家览 Arduino  delay(100)
    }
}