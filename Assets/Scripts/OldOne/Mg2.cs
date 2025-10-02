using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Mg2 : MonoBehaviour
{
    public Button againBtn, exitBtn;
    // �ŧi���s����

    // Start is called before the first frame update
    void Start()
    {
        againBtn.onClick.AddListener(GoScene1);
        exitBtn.onClick.AddListener(GoScene2);
        // ���s��������
    }

    // ������C������
    public void GoScene1()
    {
        InputManager2.Instance.ResetArduinoButtonPressCount();
        SceneManager.LoadScene("game2"); 
    }

    // ���}
    public void GoScene2()
    {
        Application.Quit(); 
        //�h�X���ε{��
    }
}