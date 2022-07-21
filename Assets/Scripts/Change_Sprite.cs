using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Sprite : MonoBehaviour
{
    //Bottom Panel
    public Button home;
    public Button posting;
    public Button AR;
    public Button Wish_list;
    public Button My_page;

    public Sprite home_sprite;
    public Sprite posting_sprite;
    public Sprite ar_sprite;
    public Sprite wish_list;
    public Sprite mypage_sprite;

    //Up
    public Button All;
    public Button Pop;
    public Sprite all_s;
    public Sprite pop_s;

    public void Change_Sprite_bottom()
    {
        this.home.GetComponent<Image>().sprite = this.home_sprite;
        this.posting.GetComponent<Image>().sprite = this.posting_sprite;
        this.AR.GetComponent<Image>().sprite = this.ar_sprite;
        this.Wish_list.GetComponent<Image>().sprite = this.wish_list;
        this.My_page.GetComponent<Image>().sprite = this.mypage_sprite;
        
    }

    public void Change_Sprite_Up()
    {
        this.All.GetComponent<Image>().sprite = this.all_s;
        this.Pop.GetComponent<Image>().sprite = this.pop_s;
    }

}
