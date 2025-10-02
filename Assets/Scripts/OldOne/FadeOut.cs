using UnityEngine;

public class FadeOutObject : MonoBehaviour
{
    public GameObject egg;
    public float duration = 1.5f; // 淡出所需的??

    private float elapsedTime = 0f;
    private Renderer[] eggRenderers;
    private Color[] originalColors;

    void Start()
    {
        // ?取 egg ?象的所有 Renderer ?件
        eggRenderers = egg.GetComponentsInChildren<Renderer>();
        originalColors = new Color[eggRenderers.Length];

        // 存?所有 Renderer 的初始?色
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

            // 更新所有 Renderer 的?色
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