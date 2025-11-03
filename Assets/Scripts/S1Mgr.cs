using System.Collections;
using UnityEngine;

public class S1Mgr : MonoBehaviour
{
    [Header("UI 動畫控制器")] public Animator titleAnimator;
    public Animator mainObjectAnimator;
    public Animator descriptionAnimator;
    public Animator transitionAnim;

    [Header("輸入模組")] public ArduinoInputHandler inputHandler;

    private bool animationPlayed = false; // 是否已經播過動畫


    private void Awake()
    {
        // 確保一開始動畫停止
        StopAllAnimations();
    }

    void Start()
    {
        // 訂閱輸入事件
        if (inputHandler != null)
        {
            inputHandler.OnPotTriggered += HandlePotTriggered;
        }
    }

    void OnDestroy()
    {
        if (inputHandler != null)
        {
            inputHandler.OnPotTriggered -= HandlePotTriggered;
        }
    }

    private void StopAllAnimations()
    {
        if (titleAnimator != null) titleAnimator.enabled = false;
        if (mainObjectAnimator != null) mainObjectAnimator.enabled = false;
        if (descriptionAnimator != null) descriptionAnimator.enabled = false;
        if (transitionAnim != null) transitionAnim.enabled = false;
    }

    private void HandlePotTriggered()
    {
        if (!animationPlayed)
        {
            // 第一次觸發：播放動畫
            PlayAnimations();
            StartCoroutine(SetAnimationPlayedDelayed(1.5f));
        }
        else
        {
            // 第二次觸發：切換場景
            LoadNextScene();
        }
    }

    private void PlayAnimations()
    {
        if (titleAnimator != null) titleAnimator.enabled = true;
        if (mainObjectAnimator != null) mainObjectAnimator.enabled = true;
        if (descriptionAnimator != null) descriptionAnimator.enabled = true;
    }

    private IEnumerator SetAnimationPlayedDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        animationPlayed = true;
    }

    private void LoadNextScene()
    {
        Debug.Log("換場景");
        // TODO: 之後加淡入淡出特效
        if (transitionAnim)
        {
            transitionAnim.enabled = true;
        }
        //SceneManager.LoadScene("S2"); // 換成你的下一個場景名稱
    }
}