using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MOSlider : MonoBehaviour
{
    public Slider slider; // 引用滑桿元件
    public Text messageText; // 引用顯示訊息的文本元件
    public float increaseSpeed = 1.0f; // 控制滑桿值增加的速度
    public GameObject prefab2; // 引用預製件2
    public Animator animator; // 引用動畫控制器
    private float timer; // 計時器

    void Start()
    {
        // 當滑桿的值發生變化時，執行OnSliderValueChanged方法
        slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        timer = 0f; // 初始化計時器
    }

    void Update()
    {
        UpdateSliderValue(); // 更新滑桿值
        CheckSliderValue(); // 檢查滑桿值是否達到特定條件
        CheckMouseButton(); // 檢查滑鼠按鍵是否被按下
    }

    void UpdateSliderValue()
    {
        timer += Time.deltaTime; // 計時器累加時間
        if (timer >= 1f)
        {
            slider.value += increaseSpeed; // 每秒增加滑桿值
            timer = 0f; // 重置計時器
        }
    }

    void CheckSliderValue()
    {
        if (slider.value >= 20f)
        {
            messageText.text = "按下空白鍵"; // 提示用戶按下空白鍵
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("pot", true);
                prefab2.SetActive(true); // 啟用預製件
                GameObject.Find("蛋餅(Clone)").SetActive(false);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("pot", false);
                StartCoroutine(DisablePrefabAfterDelay(2.5f)); // 等待動畫播完
            }
        }
        else
        {
            messageText.text = ""; // 清除提示訊息
        }

        // 檢查滑桿值是否達到 31，如果是，重置為 0
        if (Mathf.Approximately(slider.value, 31f))
        {
            slider.value = 0f;
        }
    }

    void CheckMouseButton()
    {
        if (Input.GetMouseButtonDown(0)) // 0 表示左鍵
        {
            slider.value += 0.5f; // 每次按下滑鼠左鍵增加滑桿值0.5
            Debug.Log("滑鼠被按下");
        }
    }

    void OnSliderValueChanged()
    {
        // 顯示slider的數值
        Debug.Log("Slider value: " + slider.value);
    }

    IEnumerator DisablePrefabAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        // 延遲後執行的代碼
        prefab2.SetActive(false); // 禁用預製件
        GameObject.Find("蛋餅(Clone)").SetActive(true);
        Debug.Log("顯示蛋餅1");
    }
}