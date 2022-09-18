using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VR_capture : MonoBehaviour
{
    //public RawImage[] capture_vr;
    public Material[] Panel_material;
    public Material Skybox_VR;
    public GameObject[] p;
    public GameObject b;
    public GameObject b1;
    public GameObject m;
    int i = 0;
    public RawImage[] r_image;

    public RectTransform rectT; // Assign the UI element which you wanna capture
    int width; // width of the object to capture
    int height; // height of the object to capture
    // Start is called before the first frame update
    void Start()
    {
        width = System.Convert.ToInt32(rectT.rect.width);
        height = System.Convert.ToInt32(rectT.rect.height);
        m.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();

        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        //string name = "Screenshot_EpicApp" + System.DateTime.Now.ToString("yyyy-mm-dd_HH-mm-ss") + "png";
        Sprite r_sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        Panel_material[i].SetTexture("_MainTex", r_sprite.texture);
        r_image[i].texture = r_sprite.texture;
        i++;
    }
    private IEnumerator Final()
    {
        m.SetActive(true);
        
        yield return new WaitForEndOfFrame(); // it must be a coroutine 
        Vector2 temp = rectT.transform.position;
        var startX = temp.x - width / 2;
        var startY = temp.y - height / 2;

        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
        tex.Apply();
        string name = "Screenshot_EpicApp" + System.DateTime.Now.ToString("yyyy-mm-dd_HH-mm-ss") + "png";
        Sprite r_sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        Skybox_VR.SetTexture("_MainTex", r_sprite.texture);
        NativeGallery.SaveImageToGallery(tex, "Myapp pictures", name);


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
    public void FinishCaputre()
    {
        StartCoroutine("Final");
    }
}
