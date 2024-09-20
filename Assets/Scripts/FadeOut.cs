using UnityEngine;

public class FadeOutObject : MonoBehaviour
{
    public GameObject egg;
    public float duration = 1.5f; // �H�X�һݪ�??

    private float elapsedTime = 0f;
    private Renderer[] eggRenderers;
    private Color[] originalColors;

    void Start()
    {
        // ?�� egg ?�H���Ҧ� Renderer ?��
        eggRenderers = egg.GetComponentsInChildren<Renderer>();
        originalColors = new Color[eggRenderers.Length];

        // �s?�Ҧ� Renderer ����l?��
        for (int i = 0; i < eggRenderers.Length; i++)
        {
            if (eggRenderers[i].material.HasProperty("_Color"))
            {
                originalColors[i] = eggRenderers[i].material.color;
            }
        }
    }

    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

            // ��s�Ҧ� Renderer ��?��
            for (int i = 0; i < eggRenderers.Length; i++)
            {
                if (eggRenderers[i].material.HasProperty("_Color"))
                {
                    Color newColor = originalColors[i];
                    newColor.a = alpha;
                    eggRenderers[i].material.color = newColor;
                }
            }
        }
    }
}