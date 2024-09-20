using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class Mouse : MonoBehaviour
{
    public GameObject Fire; // �ޥΪ���
    public Animator animator; // �ޥΰʵe���
    public int buttonSlider = 9;

    private int buttonValue = 0; // ��e���s��
    private int prevButtonValue = 0; // �e�@�ӫ��s��

    void Start()
    {
        // ��l�� Uduino
        UduinoManager.Instance.pinMode(buttonSlider, PinMode.Input_pullup);
    }

    void Update()
    {
        CheckButtonState();
    }

    void CheckButtonState()
    {
        buttonValue = UduinoManager.Instance.digitalRead(buttonSlider);

        // �Ȧb�ȧ��ܮ�Ĳ�o
        if (buttonValue != prevButtonValue)
        {
            if (buttonValue == 0) // ���]���s���U��^ 0
            {
                animator.SetBool("Fire", true); // �N�ʵe�ѼƳ]�� true
                //Debug.Log("���s���U - Fire");
            }
            else
            {
                animator.SetBool("Fire", false); // �N�ʵe�ѼƳ]�� false
                //Debug.Log("���s���� - Fire");
            }

            prevButtonValue = buttonValue; // ��s�e�@�ӫ��s��
        }
    }
}