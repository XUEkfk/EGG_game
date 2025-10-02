using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Mg3 : MonoBehaviour
{
    public Button backBtn, nextBtn;
    // «Å§i«ö¶s³õ´º

    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(GoScene1);
        nextBtn.onClick.AddListener(GoScene2);
        // «ö¶s³õ´º¤Á´«
    }

    // ¤Á´«¨ì¹CÀ¸³õ´º
    public void GoScene1()
    {
        SceneManager.LoadScene("Start"); 
    }

    // Â÷¶}
    public void GoScene2()
    {
        SceneManager.LoadScene("game2");
    }
}