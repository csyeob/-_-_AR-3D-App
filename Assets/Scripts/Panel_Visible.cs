using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Visible : MonoBehaviour
{
    public GameObject panel;

    public void visible_panel()
    {
        panel.SetActive(true);
    }
    public void hidepanel(GameObject p)
    {
        p.SetActive(false);
    }

    public void like()
    {
        
    }
}
