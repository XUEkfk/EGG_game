using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gtime : MonoBehaviour
{
    public Slider time; // 滑桿元件
    public float decrementValue = 1f; // 每秒減少的數值

    private float timer; // 計時器

    void Start()
    {
        // 初始化計時器
        timer = 0f;
    }

    void Update()
    {
        // 增加計時器
        timer += Time.deltaTime;

        // 當計時器達到1秒時減少滑桿的值
        if (timer >= 1f)
        {
            time.value -= decrementValue;
            timer = 0f; // 重置計時器
             Debug.Log("當前滑桿數值: " + time.value); // 輸出當前滑桿的數值
            if (time.value == 0)
            {
                SceneManager.LoadScene("Settlement");
            }
        }
    }
}