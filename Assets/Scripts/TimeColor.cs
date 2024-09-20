using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeColor : MonoBehaviour
{
    public Image foregroundImage; // �ѦҨ�e���Ϥ�
    public float countdownTime = 90f; // �˭p��90��
    private float remainingTime; // �ѧE�ɶ�
    private bool isCountingDown = false; // �O�_���b�˭p��
    public string targetSceneName;

    void Start()
    {
        if (foregroundImage != null)
        {
            foregroundImage.type = Image.Type.Filled;
            foregroundImage.fillMethod = Image.FillMethod.Radial360;
            foregroundImage.fillOrigin = (int)Image.Origin360.Top; // �]�m�������}�l
            foregroundImage.fillClockwise = true; // ���ɰw��V
        }

        StartCountdown(); // �}�l�˭p��
    }

    void Update()
    {
        if (isCountingDown)
        {
            // ��s�ѧE�ɶ�
            remainingTime -= Time.deltaTime;

            // ��s�e���Ϥ�����R�q
            if (foregroundImage != null)
            {
                foregroundImage.fillAmount = remainingTime / countdownTime;
            }

            // ��X�ѧE�ɶ��챱��x
            //Debug.Log("Remaining Time: " + remainingTime + " seconds");

            // ��˭p�ɵ����ɰ���p��
            if (remainingTime <= 0)
            {
                isCountingDown = false;
                remainingTime = 0;
                Debug.Log("Countdown finished!");
                LoadTargetScene();
            }
        }
    }

    // �}�l�˭p��
    void StartCountdown()
    {
        remainingTime = countdownTime;
        isCountingDown = true;
    }

    void LoadTargetScene()  //�[���ؼг���
    {
        SceneManager.LoadScene(targetSceneName);
    }
}