using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VR_capture : MonoBehaviour
{
    public RawImage[] capture_vr;
    int i = 0;
    public RectTransform rectT; // Assign the UI element which you wanna capture
    int width; // width of the object to capture
    int height; // height of the object to capture

    // Start is called before the first frame update
    void Start()
    {
        width = System.Convert.ToInt32(rectT.rect.width);
        height = System.Convert.ToInt32(rectT.rect.height);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        /*Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();*/
        Vector2 temp = rectT.transform.position;
        var startX = temp.x - width / 2;
        var startY = temp.y - height / 2;

        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
        tex.Apply();

        string name = "Screenshot_EpicApp" + System.DateTime.Now.ToString("yyyy-mm-dd_HH-mm-ss") + "png";
        //GameObject r = Instantiate(parent_img, this.transform.position, Quaternion.identity);
        Sprite r_sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        capture_vr[i].name = i.ToString();
        capture_vr[i].texture = r_sprite.texture;
        i++;
        //NativeGallery.SaveImageToGallery(texture, "Myapp pictures", name);
        //Destroy(texture);
        

    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void TakeScreenShot()
    {
        StartCoroutine("Screenshot");
    }
}
