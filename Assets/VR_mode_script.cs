using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_mode_script : MonoBehaviour
{
    public GameObject[] g;
    public GameObject[] VR;
    public Material m;
    public Sprite s;
    public void visible_obj()
    {
        for(int i = 0; i<g.Length; i++)
        {
            g[i].SetActive(false);
        }

        for (int i = 0; i < VR.Length; i++)
        {
            VR[i].SetActive(true);
        }
        m.SetTexture("_MainTex", s.texture);
    }



}
