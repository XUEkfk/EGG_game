using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Mg3 : MonoBehaviour
{
    public Button backBtn, nextBtn;
    // �ŧi���s����

    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(GoScene1);
        nextBtn.onClick.AddListener(GoScene2);
        // ���s��������
    }

    // ������C������
    public void GoScene1()
    {
        SceneManager.LoadScene("Start"); 
    }

    // ���}
    public void GoScene2()
    {
        SceneManager.LoadScene("game2");
    }
}