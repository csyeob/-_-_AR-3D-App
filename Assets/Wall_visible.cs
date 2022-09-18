using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall_visible : MonoBehaviour
{
    public GameObject picker;
    public GameObject btn_x;
    public GameObject FlexPickerUI;

    public FlexibleColorPicker fcp;
    public Material material;

    private void Start()
    {
        Button b = picker.GetComponent<Button>();
        b.onClick.AddListener(() => PickerVisible());
        Button b1 = btn_x.GetComponent<Button>();
        b1.onClick.AddListener(() => DelPicker());
    }
    private void Update()
    {
        material.color = fcp.color;
    }

    public void PickerVisible()
    {
        picker.SetActive(false);
        FlexPickerUI.SetActive(true);
        btn_x.SetActive(true);
    }

    public void DelPicker()
    {
        picker.SetActive(true);
        FlexPickerUI.SetActive(false);
        btn_x.SetActive(false);
    }
}
