using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HtmlAgilityPack;

public class crawler : MonoBehaviour
{
    string html = "https://search.shopping.naver.com/search/all?query=게이밍의자";
    HtmlWeb web = new HtmlWeb();

    public void parser()
    {
        HtmlDocument htmlDoc = web.Load(html);
        
    }
}
