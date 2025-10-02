using UnityEngine;
using Uduino;
using UnityEngine.UI;
using System.Collections;

public class C01 : MonoBehaviour
{
    [Header("UI 元件")]
    public Slider slider; // 引用滑桿元件
    public Text messageText; // 引用顯示訊息的文本元件

    [Header("遊戲設置")]
    public float increaseSpeed = 1.0f; // 控制滑桿值增加的速度
    public Vector3 targetPosition; // 預製物件移動的目標位置

    [Header("預製件引用")]
    public GameObject prefab2; // 引用預製件2
    public GameObject eggPrefab; // 預製物件

    [Header("圖標")]
    public Sprite spriteZero;
    public Sprite spriteOne; // 圖標一
    public Sprite spriteTwo; // 圖標二
    public Sprite spriteThree; // 圖標三

    [Header("動畫控制器")]
    public Animator animator; // 引用動畫控制器

    [Header("蛋餅生成位置")]
    public float X = 5f; // 預製物件生成的X軸位置
    public float Y = 5f; // 預製物件生成的Y軸位置

    [Header("音效")]
    public AudioSource audioSource; // 引用音效來源
    public AudioClip wKeyClip; // 引用W鍵的音效
    public AudioClip animationEndClip; // 引用動畫結束時的音效
    public AudioClip ding; //叮的音效

    private float timer; // 計時器
    private SpriteRenderer spriteRenderer; // 預製物件的 SpriteRenderer
    private GameObject instantiatedEgg; // 存儲已實例化的預製物件
    private bool coroutineStarted = false; // 用於檢測是否執行過協程
    private bool coroutineCompleted = false; // 用於檢測協程是否完成


    void Start()
    {
        slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        timer = 0f; // 初始化計時器
        InstantiateEgg(); // 實例化初始的預製物件
    }

    void Update()
    {
        UpdateSliderValue(); // 更新滑桿值
        CheckSliderValue(); // 檢查滑桿值是否達到特定條件
        CheckMouseButton(); // 檢查滑鼠按鍵是否被按下
        UpdateEggSprite(); // 更新蛋餅的圖標
        CheckKeyPress(); // 檢查 W 鍵是否被按下
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
        if (slider.value >= 20f && slider.value < 30f && coroutineCompleted)
        {
            messageText.text = "出餐按鈴"; // 提示玩家按下W鍵
        }
        else if (slider.value >= 20f && slider.value < 30f)
        {
            messageText.text = "按下空白鍵"; // 提示玩家按下空白鍵
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("pot", true);
                prefab2.SetActive(true); // 啟用預製件
                if (instantiatedEgg != null)
                {
                    instantiatedEgg.SetActive(false);
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("pot", false);
                if (!coroutineStarted)
                {
                    StartCoroutine(DisablePrefabAfterDelay(1.8f)); // 等待動畫播完
                    coroutineStarted = true; // 設置為已執行過協程
                }
            }
        }
        else if (Mathf.Approximately(slider.value, 31f))
        {
            // messageText.text = "已燒焦"; // 提示用戶已燒焦
            slider.value = 0f; // 重置滑桿值
            Destroy(instantiatedEgg); // 銷毀已實例化的預製物件
            InstantiateEgg(); // 重新實例化一個新的預製物件
            coroutineStarted = false; // 重置協程執行狀態
            coroutineCompleted = false; // 重置協程完成狀態
        }
        else
        {
            messageText.text = ""; // 清除提示訊息
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

    void CheckKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.W) && slider.value >= 20f && slider.value < 30f && coroutineCompleted)
        {
            if (instantiatedEgg != null)
            {
                coroutineCompleted = false; // 重置協程完成狀態
                StartCoroutine(MoveAndDestroyEgg());
                slider.value = 0f; // 重置滑桿值

                // 播放音效
                if (audioSource != null && wKeyClip != null)
                {
                    audioSource.PlayOneShot(wKeyClip);
                    audioSource.PlayOneShot(ding);
                }
            }
        }
    }

    void OnSliderValueChanged()
    {
        // 顯示slider的數值
        Debug.Log("Slider value: " + slider.value);
    }

    IEnumerator DisablePrefabAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 延遲後執行的代碼
        prefab2.SetActive(false); // 禁用預製件
        slider.value = 0f; // 重置滑桿值

        // 播放動畫結束的音效
        if (audioSource != null && animationEndClip != null)
        {
            audioSource.PlayOneShot(animationEndClip);
        }

        if (instantiatedEgg != null)
        {
            instantiatedEgg.SetActive(true); // 顯示蛋餅
        }
        coroutineCompleted = true; // 設置為協程完成
        coroutineStarted = false; // 重置協程狀態
    }

    IEnumerator MoveAndDestroyEgg()
    {
        if (instantiatedEgg != null)
        {
            float moveDuration = 0.06f; // 移動持續時間
            Vector3 startPosition = instantiatedEgg.transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < moveDuration)
            {
                instantiatedEgg.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            instantiatedEgg.transform.position = targetPosition;
            Destroy(instantiatedEgg); // 銷毀已實例化的預製物件
            InstantiateEgg(); // 重新實例化一個新的預製物件
            coroutineCompleted = false; // 設置為協程未完成
        }
    }

    void UpdateEggSprite()
    {
        if (spriteRenderer != null)
        {
            if (slider.value >= 0 && slider.value < 10)
            {
                ChangeIcon(spriteZero);
            }
            // 檢查滑桿的數值是否達到10但小於20
            if (slider.value >= 10 && slider.value < 20)
            {
                ChangeIcon(spriteOne);
            }
            // 檢查滑桿的數值是否達到20但小於30
            else if (slider.value >= 20 && slider.value < 30)
            {
                ChangeIcon(spriteTwo);
            }
            // 檢查滑桿的數值是否達到30
            else if (slider.value >= 30)
            {
                ChangeIcon(spriteThree);
            }
        }
    }

    void ChangeIcon(Sprite newSprite)
    {
        // 更換圖標的方法
        if (newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }

    void InstantiateEgg()
    {
        // 實例化一個新的預製物件在指定的位置
        Vector3 position = new Vector3(X, Y, 0f);
        instantiatedEgg = Instantiate(eggPrefab, position, Quaternion.identity);

        // 獲取預製物件上的 SpriteRenderer 元件
        if (instantiatedEgg != null)
        {
            spriteRenderer = instantiatedEgg.GetComponent<SpriteRenderer>();
        }

        // 重置協程狀態
        coroutineStarted = false;
    }
}
