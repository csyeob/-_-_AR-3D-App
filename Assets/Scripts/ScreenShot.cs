using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ScreenShot : MonoBehaviour
{
    public GameObject UI;
    public GameObject Panel;
    public GameObject marker;
    public GameObject inputmanager;
    public GameObject side;
    public ARPlaneManager plane;

    // Start is called before the first frame update
    void Start()
    {
        
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

        string name = "Screenshot_EpicApp" + System.DateTime.Now.ToString("yyyy-mm-dd_HH-mm-ss") + "png";

        NativeGallery.SaveImageToGallery(texture, "Myapp pictures", name);
        Destroy(texture);
        plane.enabled = true;
        UI.SetActive(true);
        Panel.SetActive(true);
        marker.SetActive(true);
        inputmanager.SetActive(true);
        side.SetActive(true);

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
        UI.SetActive(false);
        Panel.SetActive(false);
        marker.SetActive(false);
        inputmanager.SetActive(false);
        side.SetActive(false);
        plane.enabled = false;
        
        StartCoroutine("Screenshot");
    }
}
