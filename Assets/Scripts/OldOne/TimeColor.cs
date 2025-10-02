using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeColor : MonoBehaviour
{
    public Image foregroundImage; // 參考到前景圖片
    public float countdownTime = 90f; // 倒計時90秒
    private float remainingTime; // 剩余時間
    private bool isCountingDown = false; // 是否正在倒計時
    public string targetSceneName;

    void Start()
    {
        if (foregroundImage != null)
        {
            foregroundImage.type = Image.Type.Filled;
            foregroundImage.fillMethod = Image.FillMethod.Radial360;
            foregroundImage.fillOrigin = (int)Image.Origin360.Top; // 設置為底部開始
            foregroundImage.fillClockwise = true; // 順時針方向
        }

        StartCountdown(); // 開始倒計時
    }

    void Update()
    {
        if (isCountingDown)
        {
            // 更新剩余時間
            remainingTime -= Time.deltaTime;

            // 更新前景圖片的填充量
            if (foregroundImage != null)
            {
                foregroundImage.fillAmount = remainingTime / countdownTime;
            }

            // 輸出剩余時間到控制台
            //Debug.Log("Remaining Time: " + remainingTime + " seconds");

            // 當倒計時結束時停止計時
            if (remainingTime <= 0)
            {
                isCountingDown = false;
                remainingTime = 0;
                Debug.Log("Countdown finished!");
                LoadTargetScene();
            }
        }
    }

    // 開始倒計時
    void StartCountdown()
    {
        remainingTime = countdownTime;
        isCountingDown = true;
    }

    void LoadTargetScene()  //加載目標場景
    {
        SceneManager.LoadScene(targetSceneName);
    }
}