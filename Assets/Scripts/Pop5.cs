using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop5 : MonoBehaviour
{
    public Button btn1; public Button btn2; public Button btn3;
    public Sprite s1;   public Sprite s2;   public Sprite s3;

    public void Change_Sprite_bottom()
    {
        this.btn1.GetComponent<Image>().sprite = this.s1;
        this.btn2.GetComponent<Image>().sprite = this.s2;
        this.btn3.GetComponent<Image>().sprite = this.s3;
    }
    //가구 url
    string funiture = "https://search.shopping.naver.com/search/all?frm=NVSHATC&origQuery=가구&pagingIndex=1&pagingSize=40&productSet=total&query=가구&sort=review_rel&timestamp=&viewType=list#";
    //가전제품 url

    //deco url

    //brand url

    public void search_url()
    {

    }
}
