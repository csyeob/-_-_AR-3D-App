using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContentFilter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalLayoutGroup hg = GetComponent<HorizontalLayoutGroup>();
        //레이아웃 그룹을 가져간 다음 이 구성요소에 얼마나 많은 자식이 있는지 계산
        int childCount = transform.childCount - 1;
        //요소 사이에 있는 빈공간을 새야하므로 ㅁ ㅁ ㅁ 3개있으면 공간사이는 3-1임
        float childWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        float width = hg.spacing * childCount + childCount * childWidth + hg.padding.left;

        GetComponent<RectTransform>().sizeDelta = new Vector2(width, 265);
    }
}
