using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostingHandler : MonoBehaviour
{

    int like_value = 0;
    public GameObject panel_size;
    int r_position_x = 2;
    int r_position_y = 4300;
    int t_position_x = 2;
    int t_position_y = 3650;

    public void like(Text t)
    {
        like_value++;
        t.GetComponent<Text>().text = like_value.ToString();
    }

    public void makeRawImage(RawImage r)
    {

        var rawimageObject = new GameObject("RawImage1");
        var rawimage = rawimageObject.AddComponent<RawImage>();
        rawimage.GetComponent<RawImage>().texture = r.GetComponent<RawImage>().texture;
        //14 , 970
        rawimage.rectTransform.sizeDelta = new Vector2(850, 1050);
        rawimage.rectTransform.parent = panel_size.transform;
        rawimage.rectTransform.anchoredPosition = new Vector2(r_position_x, r_position_y);
        r_position_y -= 1300;
       
    }
    public void makeText(Text t)
    {
        var textObject = new GameObject("Text1");
        var text = textObject.AddComponent<Text>();
        text.GetComponent<Text>().text = t.GetComponent<Text>().text;
        textObject.transform.parent = panel_size.transform;
        //float widthSize = panel_size.GetComponent<RectTransform>().rect.width;
        //float heightSize = panel_size.GetComponent<RectTransform>().rect.height;
        //// 오브젝트 이동 
        //Vector3 text_position = text.transform.localPosition;
        //text_position.x = widthSize + 50;
        //text_position.y = heightSize;
        //text.transform.localPosition = text_position;
        text.rectTransform.sizeDelta = new Vector2(850, 200);
        //text.rectTransform.sizeDelta = Vector2.zero;
        //text.rectTransform.anchorMin = Vector2.zero;
        //text.rectTransform.anchorMax = Vector2.one;
        text.rectTransform.anchoredPosition = new Vector2(t_position_x,t_position_y);
        text.font = Resources.FindObjectsOfTypeAll<Font>()[0];
        text.fontSize = 40;
        text.color = Color.black;
        t_position_y -= 1300;
    }
}

