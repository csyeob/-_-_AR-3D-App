using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private GraphicRaycaster raycaster;
    private PointerEventData pData;
    private EventSystem eventSystem;

    public Transform selectionPoint;
    //cavas에서 중심 너비를 가져온 다음 작동하는 중심을 계산

    //다른 스크립트에서 이 스크립트를 불러올 수 있도록 하는 인스턴스
    public static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                //null이면 인스턴스를 생성
                //같은 유형의 타입을 찾고 UIManager클래스를 찾으면 여기에 해당 인스턴스를 전달함.
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
            // null이 아니면 instance를 반환
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        //canvas의 구성요소를 가져와서 동작을 처리하는 이벤트 시스템
        pData = new PointerEventData(eventSystem);
        pData.position = selectionPoint.position;
        //데이터 이벤트 시스템에 의해 정상적으로 인식되고 선택 지점에 있어야 하므로 중앙 위치로 변경 
    }

    public bool OnEntered(GameObject button)
    {
        //버튼관리자에서 버튼값을 줄거임.
        //레이캐스트의 결과값을 넣을 리스트
        //기본적으로 results가 레이케스트 정보를 가지고 있기 때문에 목록을 통해 탐색이 가능
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pData, results);
        // 목록을 검색 하는데 만약 버튼을 발견하면 true 반환 
        foreach (RaycastResult result in results)
        {
            if(result.gameObject == button)
            {
                return true;
            }
        }
        return false;
    }
}
