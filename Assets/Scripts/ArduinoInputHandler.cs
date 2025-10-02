using UnityEngine;
using Uduino;
using System;

public class ArduinoInputHandler : MonoBehaviour
{
    [Header("Arduino Pin 設定")]
    public int buttonPot = 10; // 翻鍋按鍵 (Pin10)

    public event Action OnPotTriggered; // 當翻鍋按下時的事件

    private int prevButtonValue = 1; // 預設未按下 (Arduino 高電位)
    private float debounceTime = 0.2f; // 200ms 冷卻
    private float lastTriggerTime = 0f;
    void Start()
    {
        UduinoManager.Instance.pinMode(buttonPot, PinMode.Input_pullup);
    }

    void Update()
    {
        int buttonValue = UduinoManager.Instance.digitalRead(buttonPot);

        // ✅ 只在從「未按下(1) → 按下(0)」的瞬間觸發
        if (buttonValue == 0 && prevButtonValue == 1 && Time.time - lastTriggerTime > debounceTime)
        {
            OnPotTriggered?.Invoke();
            lastTriggerTime = Time.time;
        }

        prevButtonValue = buttonValue; // 記錄狀態，避免重複觸發
    }
}