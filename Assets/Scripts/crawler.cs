using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;
using UnityEngine.UI;
using System.Linq;
using System.Net;
using System.IO;
public class crawler : MonoBehaviour
{
   
    public Text tx;
    void Start()
    {

        string url = "https://search.shopping.naver.com/search/all?query=의자";
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);
        int num = 0;

        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='basicList_title__3P9Q7']"))
        {
            tx.text += node.InnerText.ToString() + "\n";
            num++;
            if(num == 10)
            {
                return;
            }
        }
        var rawimageObject = new GameObject("Rawimage");
        var rawimage = rawimageObject.AddComponent<RawImage>();
        rawimage.GetComponent<RawImage>().texture = r(cralwer image).GetComponent<RawImage>().texture;

    }
    
}
