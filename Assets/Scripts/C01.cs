using UnityEngine;
using Uduino;
using UnityEngine.UI;
using System.Collections;

public class C01 : MonoBehaviour
{
    [Header("UI ����")]
    public Slider slider; // �ޥηƱ줸��
    public Text messageText; // �ޥ���ܰT�����奻����

    [Header("�C���]�m")]
    public float increaseSpeed = 1.0f; // ����Ʊ�ȼW�[���t��
    public Vector3 targetPosition; // �w�s���󲾰ʪ��ؼЦ�m

    [Header("�w�s��ޥ�")]
    public GameObject prefab2; // �ޥιw�s��2
    public GameObject eggPrefab; // �w�s����

    [Header("�ϼ�")]
    public Sprite spriteZero;
    public Sprite spriteOne; // �ϼФ@
    public Sprite spriteTwo; // �ϼФG
    public Sprite spriteThree; // �ϼФT

    [Header("�ʵe���")]
    public Animator animator; // �ޥΰʵe���

    [Header("�J��ͦ���m")]
    public float X = 5f; // �w�s����ͦ���X�b��m
    public float Y = 5f; // �w�s����ͦ���Y�b��m

    [Header("����")]
    public AudioSource audioSource; // �ޥέ��Ĩӷ�
    public AudioClip wKeyClip; // �ޥ�W�䪺����
    public AudioClip animationEndClip; // �ޥΰʵe�����ɪ�����
    public AudioClip ding; //�m������

    private float timer; // �p�ɾ�
    private SpriteRenderer spriteRenderer; // �w�s���� SpriteRenderer
    private GameObject instantiatedEgg; // �s�x�w��Ҥƪ��w�s����
    private bool coroutineStarted = false; // �Ω��˴��O�_����L��{
    private bool coroutineCompleted = false; // �Ω��˴���{�O�_����


    void Start()
    {
        slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
        timer = 0f; // ��l�ƭp�ɾ�
        InstantiateEgg(); // ��Ҥƪ�l���w�s����
    }

    void Update()
    {
        UpdateSliderValue(); // ��s�Ʊ��
        CheckSliderValue(); // �ˬd�Ʊ�ȬO�_�F��S�w����
        CheckMouseButton(); // �ˬd�ƹ�����O�_�Q���U
        UpdateEggSprite(); // ��s�J�檺�ϼ�
        CheckKeyPress(); // �ˬd W ��O�_�Q���U
    }

    void UpdateSliderValue()
    {
        timer += Time.deltaTime; // �p�ɾ��֥[�ɶ�
        if (timer >= 1f)
        {
            slider.value += increaseSpeed; // �C��W�[�Ʊ��
            timer = 0f; // ���m�p�ɾ�
        }
    }

    void CheckSliderValue()
    {
        if (slider.value >= 20f && slider.value < 30f && coroutineCompleted)
        {
            messageText.text = "�X�\���a"; // ���ܪ��a���UW��
        }
        else if (slider.value >= 20f && slider.value < 30f)
        {
            messageText.text = "���U�ť���"; // ���ܪ��a���U�ť���
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("pot", true);
                prefab2.SetActive(true); // �ҥιw�s��
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
                    StartCoroutine(DisablePrefabAfterDelay(1.8f)); // ���ݰʵe����
                    coroutineStarted = true; // �]�m���w����L��{
                }
            }
        }
        else if (Mathf.Approximately(slider.value, 31f))
        {
            // messageText.text = "�w�N�J"; // ���ܥΤ�w�N�J
            slider.value = 0f; // ���m�Ʊ��
            Destroy(instantiatedEgg); // �P���w��Ҥƪ��w�s����
            InstantiateEgg(); // ���s��ҤƤ@�ӷs���w�s����
            coroutineStarted = false; // ���m��{���檬�A
            coroutineCompleted = false; // ���m��{�������A
        }
        else
        {
            messageText.text = ""; // �M�����ܰT��
        }
    }

    void CheckMouseButton()
    {
        if (Input.GetMouseButtonDown(0)) // 0 ��ܥ���
        {
            slider.value += 0.5f; // �C�����U�ƹ�����W�[�Ʊ��0.5
            Debug.Log("�ƹ��Q���U");
        }
    }

    void CheckKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.W) && slider.value >= 20f && slider.value < 30f && coroutineCompleted)
        {
            if (instantiatedEgg != null)
            {
                coroutineCompleted = false; // ���m��{�������A
                StartCoroutine(MoveAndDestroyEgg());
                slider.value = 0f; // ���m�Ʊ��

                // ���񭵮�
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
        // ���slider���ƭ�
        Debug.Log("Slider value: " + slider.value);
    }

    IEnumerator DisablePrefabAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // �������檺�N�X
        prefab2.SetActive(false); // �T�ιw�s��
        slider.value = 0f; // ���m�Ʊ��

        // ����ʵe����������
        if (audioSource != null && animationEndClip != null)
        {
            audioSource.PlayOneShot(animationEndClip);
        }

        if (instantiatedEgg != null)
        {
            instantiatedEgg.SetActive(true); // ��ܳJ��
        }
        coroutineCompleted = true; // �]�m����{����
        coroutineStarted = false; // ���m��{���A
    }

    IEnumerator MoveAndDestroyEgg()
    {
        if (instantiatedEgg != null)
        {
            float moveDuration = 0.06f; // ���ʫ���ɶ�
            Vector3 startPosition = instantiatedEgg.transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < moveDuration)
            {
                instantiatedEgg.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            instantiatedEgg.transform.position = targetPosition;
            Destroy(instantiatedEgg); // �P���w��Ҥƪ��w�s����
            InstantiateEgg(); // ���s��ҤƤ@�ӷs���w�s����
            coroutineCompleted = false; // �]�m����{������
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
            // �ˬd�Ʊ쪺�ƭȬO�_�F��10���p��20
            if (slider.value >= 10 && slider.value < 20)
            {
                ChangeIcon(spriteOne);
            }
            // �ˬd�Ʊ쪺�ƭȬO�_�F��20���p��30
            else if (slider.value >= 20 && slider.value < 30)
            {
                ChangeIcon(spriteTwo);
            }
            // �ˬd�Ʊ쪺�ƭȬO�_�F��30
            else if (slider.value >= 30)
            {
                ChangeIcon(spriteThree);
            }
        }
    }

    void ChangeIcon(Sprite newSprite)
    {
        // �󴫹ϼЪ���k
        if (newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }

    void InstantiateEgg()
    {
        // ��ҤƤ@�ӷs���w�s����b���w����m
        Vector3 position = new Vector3(X, Y, 0f);
        instantiatedEgg = Instantiate(eggPrefab, position, Quaternion.identity);

        // ����w�s����W�� SpriteRenderer ����
        if (instantiatedEgg != null)
        {
            spriteRenderer = instantiatedEgg.GetComponent<SpriteRenderer>();
        }

        // ���m��{���A
        coroutineStarted = false;
    }
}
