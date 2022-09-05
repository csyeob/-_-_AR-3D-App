using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class Generate : MonoBehaviour
{
    public RectTransform rectT; // Assign the UI element which you wanna capture
    int width; // width of the object to capture
    int height; // height of the object to capture
    public Material m;
    public GameObject sphere;
    public GameObject panel;
    // Use this for initialization
    void Start()
    {
        width = System.Convert.ToInt32(rectT.rect.width);
        height = System.Convert.ToInt32(rectT.rect.height);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void Sphere()
    {
        panel.SetActive(true);
        StartCoroutine(takeScreenShot());
    }
    public IEnumerator takeScreenShot()
    {
        yield return new WaitForEndOfFrame(); // it must be a coroutine 
        Vector2 temp = rectT.transform.position;
        var startX = temp.x - width / 2;
        var startY = temp.y - height / 2;

        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
        tex.Apply();
        Sprite r_sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        m.SetTexture("_MainTex", r_sprite.texture);
        sphere.GetComponent<MeshRenderer>().material = m;
        panel.SetActive(false);


    }
}