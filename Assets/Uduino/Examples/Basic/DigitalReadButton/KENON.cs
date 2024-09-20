using System.Collections;
using UnityEngine;
using Uduino;

public class KENON : MonoBehaviour
{
    public int interruptPin = 3; // ���_�޸}
    public GameObject buttonGameObject;

    private bool interruptTriggered = false; // �аO���_�O�_Ĳ�o

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
        if (data == "Knock on!")
        {
            interruptTriggered = true;
        }
    }

    void Update()
    {
        // ���� Arduino �� loop() ���
        if (interruptTriggered)
        {
            Procedure();
            interruptTriggered = false;
        }
        
        Debug.Log("1");
        StartCoroutine(Delay(0.2f)); // ���� Arduino �� delay(200)
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
        PressedDown(); // ���_Ĳ�o�ɽեΫ��s���U�ĪG
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