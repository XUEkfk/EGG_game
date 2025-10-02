using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Mg1 : MonoBehaviour
{
    public Button startBtn, exitBtn;
    // 宣告按鈕場景

    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(GoScene1);
        exitBtn.onClick.AddListener(GoScene2);
        // 按鈕場景切換
    }

    // 切換到遊戲場景
    public void GoScene1()
    {
        SceneManager.LoadScene("Intru");  
    }

   
    public void GoScene2()
    {
        Application.Quit(); 
        //退出應用程序
    }
}