using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Visible : MonoBehaviour
{
    public GameObject panel;
    public GameObject hide;
    public GameObject look;

    public void visible_panel()
    {
        panel.SetActive(true);
        hide.SetActive(true);
        look.SetActive(false);
    }
    public void hidepanel(GameObject p)
    {
        p.SetActive(false);
        hide.SetActive(false);
        look.SetActive(true);
    }

    public void like()
    {
        
    }
}
