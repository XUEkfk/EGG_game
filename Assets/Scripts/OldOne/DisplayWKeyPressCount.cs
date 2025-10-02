using UnityEngine;
using UnityEngine.UI;

public class DisplayArduinoButtonPressCount : MonoBehaviour
{
    public Text arduinoButtonPressText;

    void Start()
    {
        if (InputManager2.Instance != null)
        {
            int arduinoButtonPressCount = InputManager2.Instance.GetArduinoButtonPressCount();
            arduinoButtonPressText.text = arduinoButtonPressCount.ToString();
            Debug.Log("顯示分數"+arduinoButtonPressCount);
        }
    }
}
