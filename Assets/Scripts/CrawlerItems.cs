using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrawlerItems : MonoBehaviour
{
    public GameObject gameobject;
    public Text name;
    public Text price;
    public Button craw_btn;
    public RawImage craw_img;

    public void makeObj()
    {
        gameObject.AddComponent<Text>().text = name.text;
       // gameObject.AddComponent<Button>();
        gameObject.AddComponent<RawImage>().texture = craw_img.texture;
       // gameObject.AddComponent<Text>();
        Vector3 position = gameObject.transform.localPosition;
        position.x = 0;
        position.y = 100;
        gameObject.GetComponent<Text>().transform.localPosition = position;
        Vector3 position_img = gameObject.transform.localPosition;
        position.x = 0;
        position.y = 0;
        gameObject.GetComponent<RawImage>().transform.localPosition = position_img;
    }

    

}
