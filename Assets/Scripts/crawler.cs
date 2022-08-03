using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;
using UnityEngine.UI;
using System.Linq;
using System.Net;
using System.IO;
using UnityEngine.Networking;
using DG.Tweening;

public class crawler : MonoBehaviour
{

    List<string> image_links = new List<string>();
    List<string> item_name = new List<string>();
    List<string> item_price = new List<string>();
    List<string> item_brand = new List<string>();
    List<GameObject> items = new List<GameObject>();
    List<GameObject> name = new List<GameObject>();
    List<GameObject> price = new List<GameObject>();
    List<GameObject> brand = new List<GameObject>();
    List<string> img = new List<string>();
    public Text tx;
    public Font font;
    public GameObject scorl;
    int i = 0;
    List<Button> button_items = new List<Button>();
    void Start()
    {
     
    }
    public void makeImgUrl(string link)
    {
        string url = link;
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);
        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='thumbnail_thumb_wrap__1pEkS _wrapper']//a[@class='thumbnail_thumb__3Agq6']"))
        {
            img.Add(node.GetAttributeValue("href",""));
        }

    }
    public void makeItems(string html_img)
    {
        string url = html_img;
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);
        HtmlNode link = doc.DocumentNode.SelectSingleNode("//div[@class='image_thumb__20xyr']//img");
        image_links.Add(link.GetAttributeValue("src", ""));
    }

    IEnumerator GetTexture(RawImage img, string link)
    {
        var url = link;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
          img.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }

    public void SideScorll(string url)
    {
        makeImgUrl(url);

        for(int i = 0; i< img.Count; i++)
        {
            var rawimageObject = new GameObject("RawImage");
            rawimageObject.AddComponent<RawImage>();
            items.Add(rawimageObject);
            var textObj = new GameObject("name");
            textObj.AddComponent<Text>();
            name.Add(textObj);
            var textObj_p = new GameObject("price");
            textObj_p.AddComponent<Text>();
            price.Add(textObj_p);
            var textObj_b = new GameObject("brand");
            textObj_b.AddComponent<Text>();
            brand.Add(textObj_b);

        }
        //아이템 프리팹의 트랜스폼
        RectTransform sideRectTrans = items[0].GetComponent<RectTransform>();
        //컨테이너(스크롤 리스트)의 트랜스폼
        RectTransform containerRectTrans = scorl.GetComponent<RectTransform>();
        //높이 = 컨테이너->로컬렉트크기 ->높이
        float height = 450;
        //기준비율 = 콘테이너 높이/ 아이템프리팹의 높이 
        float ratio = 4;
        //너비 = 아이템프리팹의 너비 * 비율
        float width = sideRectTrans.rect.width * ratio;
        //스크롤 너비 = 너비 * 개수
        float ScrollWidth = width * img.Count;
        //오프셋 최소 = - 스크롤의 길이/ 2  ,  컨테이너 오프셋 최소 y
        containerRectTrans.offsetMin = new Vector2(-ScrollWidth/2, containerRectTrans.offsetMin.y);
        //오프셋 최소 = - 스크롤의 길이/ 2  ,  컨테이너 오프셋 최소 y
        containerRectTrans.offsetMax = new Vector2(ScrollWidth/2, containerRectTrans.offsetMax.y);
        for (int i = 0; i < img.Count; i++)
        {
            //프리팹 생성
            //아이템 이름 지정

            makeItems(img[i]);
            makeHead(url);
            makePrice(url);
            makeBrand(url);
            
            StartCoroutine(GetTexture(items[i].GetComponent<RawImage>(),image_links[i]));
            items[i].name = item_name[i].ToString();
           
            //items[i].GetComponent<Text>().text = item_name[i].ToString();
            //아이템의 부모를 현재 오브젝트로 지정

            //상품 이름 text 지
            name[i].GetComponent<Text>().text = item_name[i].ToString();
            name[i].GetComponent<Text>().fontSize = 30;
            name[i].GetComponent<Text>().color = Color.black;
            name[i].GetComponent<Text>().font = font;

            //상품 가격 text
            price[i].GetComponent<Text>().text = item_price[i].ToString();
            price[i].GetComponent<Text>().fontSize = 45;
            price[i].GetComponent<Text>().color = Color.black;
            price[i].GetComponent<Text>().font = font;
            price[i].GetComponent<Text>().fontStyle = FontStyle.Bold;

            brand[i].GetComponent<Text>().text = item_brand[i].ToString();
            brand[i].GetComponent<Text>().fontSize = 50;
            brand[i].GetComponent<Text>().color = Color.black;
            brand[i].GetComponent<Text>().font = font;
            brand[i].GetComponent<Text>().fontStyle = FontStyle.Bold;

            items[i].transform.parent = scorl.transform;
            //items[i].GetComponent<RectTransform>().sizeDelta = new Vector2(500, 550);


            name[i].transform.parent = items[i].transform;  
            name[i].GetComponent<RectTransform>().sizeDelta = new Vector2(310, 100);
            name[i].transform.position = new Vector3(name[i].transform.position.x+360, name[i].transform.position.y);

            price[i].transform.parent = items[i].transform;
            price[i].GetComponent<RectTransform>().sizeDelta = new Vector2(280, 61);
            price[i].transform.position = new Vector3(price[i].transform.position.x+350, price[i].transform.position.y - 155);

            brand[i].transform.parent = items[i].transform;
            brand[i].GetComponent<RectTransform>().sizeDelta = new Vector2(300, 70);
            brand[i].transform.position = new Vector3(brand[i].transform.position.x + 350, brand[i].transform.position.y + 165);

            //아이템의 트랜스폼 컴포넌트를 가지고옴
            RectTransform rectTrans = items[i].GetComponent<RectTransform>();

            //x = - 컨테이너의 넓이/2 + 넓이 * i
            float x = -containerRectTrans.rect.width / 3 + width * i;
            float y = containerRectTrans.rect.height / 2 - height;
             rectTrans.offsetMin = new Vector2(x, y);
              x = rectTrans.offsetMin.x + width;
              y = rectTrans.offsetMin.y + height;
             rectTrans.offsetMax = new Vector2(x, y);
        }

    }
    public void makePrice(string link)
    {
        string url = link;
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);
        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span[@class='price_num__2WUXn']"))
        {
           item_price.Add(node.InnerText.ToString());
        }
    }
    public void makeHead(string link)
    {
      
       string url = link;
       HtmlWeb web = new HtmlWeb();
       HtmlDocument doc = web.Load(url);
       foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='basicList_title__3P9Q7']"))
       {
           item_name.Add(node.InnerText.ToString());
       }
       
    }
    public void makeBrand(string link)
    {
        string url = link;
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);
        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span[@class='basicList_mall_name__1XaKA']"))
        {
            item_brand.Add(node.InnerText.ToString());
        }
    }
}
