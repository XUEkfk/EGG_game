using System.Collections;
using UnityEngine;
using Uduino;

public class InterruptExample : MonoBehaviour
{
    public int interruptPin = 3; // ���_�޸}

    void Start()
    {
        // ��l�Ʀ��q�H
        UduinoManager.Instance.OnBoardConnected += OnBoardConnected; 
    }

    void OnBoardConnected(UduinoDevice connectedDevice)
    {
        // �]�m�޸}�Ҧ�
        UduinoManager.Instance.SetBoardType(connectedDevice, "Arduino Uno");
        UduinoManager.Instance.pinMode(interruptPin, PinMode.Input_pullup);

        // ���U���_�^��
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
        // ���� Arduino �� loop() ���
        Debug.Log("1");
        StartCoroutine(Delay(0.5f)); // ���� Arduino �� delay(500)
    }

    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
    }

    void Procedure()
    {
        // ���� Arduino �� procedure() ���
        Debug.Log("0");
        StartCoroutine(Delay(0.1f)); // ���� Arduino �� delay(100)
    }
}