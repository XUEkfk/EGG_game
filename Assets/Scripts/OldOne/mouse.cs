using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class Mouse : MonoBehaviour
{
    public GameObject Fire; // 引用物件
    public Animator animator; // 引用動畫控制器
    public int buttonSlider = 9;

    private int buttonValue = 0; // 當前按鈕值
    private int prevButtonValue = 0; // 前一個按鈕值

    void Start()
    {
        // 初始化 Uduino
        UduinoManager.Instance.pinMode(buttonSlider, PinMode.Input_pullup);
    }

    void Update()
    {
        CheckButtonState();
    }

    void CheckButtonState()
    {
        buttonValue = UduinoManager.Instance.digitalRead(buttonSlider);

        // 僅在值改變時觸發
        if (buttonValue != prevButtonValue)
        {
            if (buttonValue == 0) // 假設按鈕按下返回 0
            {
                animator.SetBool("Fire", true); // 將動畫參數設為 true
                //Debug.Log("按鈕按下 - Fire");
            }
            else
            {
                animator.SetBool("Fire", false); // 將動畫參數設為 false
                //Debug.Log("按鈕釋放 - Fire");
            }

            prevButtonValue = buttonValue; // 更新前一個按鈕值
        }
    }
}