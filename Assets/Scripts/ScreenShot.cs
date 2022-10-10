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
    public GameObject side;
    public ARPlaneManager plane;
    public ARPlane arplane;
    public GameObject sidebutton;
    public Material mat;

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
        side.SetActive(true);
        arplane.enabled = true;
        sidebutton.SetActive(true);

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
    public void deleteUI()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {}
        else
        {
            UI.SetActive(false);
            Panel.SetActive(false);
            marker.SetActive(false);
            side.SetActive(false);
            plane.enabled = false;
            arplane.enabled = false;
            sidebutton.SetActive(false);
            TakeScreenShot();
        }
        
    }
}
