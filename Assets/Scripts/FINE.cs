using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image image1;
    public Image image2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwitchImage();
        }
    }

    void SwitchImage()
    {
        if (image1 != null && image2 != null)
        {
            // 切換圖片可見性
            image1.enabled = !image2.enabled;
            image2.enabled = !image1.enabled;
        }
    }
}