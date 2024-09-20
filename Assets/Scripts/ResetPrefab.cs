using UnityEngine;

public class ResetPrefab : MonoBehaviour
{
    public GameObject prefabToReset; // �n���m���w�s����
    private Vector3 resetPosition; // ���m��m
    private Quaternion resetRotation; // ���m����
    private SpriteRenderer spriteRenderer; // �w�s����SpriteRenderer

    void Start()
    {
        // �x�s��l��m�M����
        resetPosition = prefabToReset.transform.position;
        resetRotation = prefabToReset.transform.rotation;

        // ����w�s����SpriteRenderer
        spriteRenderer = prefabToReset.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // �p�G���U�ť���A���m�w�s���󪺦�m�M���A
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetPrefabTransform();
        }
    }

    // ���m�w�s���󪺦�m�B����M�Ϥ����A
    public void ResetPrefabTransform()
    {
        // �N�w�s���󪺦�m�M����]�m����l��
        prefabToReset.transform.position = resetPosition;
        prefabToReset.transform.rotation = resetRotation;

        // �N���z���׳]�m��100%
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = 1.0f;
            spriteRenderer.color = color;
        }
    }
}