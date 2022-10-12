using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;
public class InputManager : ARBaseGestureInteractable
{
    //처음엔 monobehaviour를 사용했지만 터치 상호작용 제스처를 위해 바꿈.
    //InputManager은 광(raycast을 사용하여 화면을 탑할 때 광선을 던지고 AR(가구)개체를 생성하여
    // 적중 받을 스크립트임.

    //[SerializeField]private GameObject arobj;
    //시리얼라이즈필드는 private필드임에도 변수지정할 수 있게함
    //윗줄은 이제 Datahandler에서 가져온 객체로 사용할 것이므로 주석

    [SerializeField]private Camera arCam;
    [SerializeField]private ARRaycastManager raycastmanager;
    [SerializeField]private GameObject crosshair;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    RaycastHit hit;

    private Touch touch;
    private Pose pose;

    // 모든 터치를 저장하기 위한 변수 
    //Touch는 그냥 getMouseButtonDown(0)은 첫터치 이지만, 터치 상호작용(가구 회전, 크기 조정 등을 할 수 있음)
    //컴퓨터는 mouse 상호작용을 쓰는 것이 좋고, 모바일은 touch 상호작용을 쓰는 것이 좋음.
    void Start()
    {
        
    }
    /*void Update()
    {
        CrosshairCalculation();

        touch = Input.GetTouch(0);
        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
            return;
        if (IsPointerOverUI(touch)) return;

        //touch가 없을 경우 전으로 돌아감. update 메소드에서 돌거임
        //if (Input.GetMouseButtonDown(0))

        Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);

    }*/
    void FixedUpdate()
    {
        CrosshairCalculation();
    }
    
    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if (gesture.targetObject == null)
            return true;
        return false;
        //이 메소드는 객체가 이미 배치되어 있다면 다른 평면상의 좌표에는 오브젝트를 넣을수 있게 함.
    }

    protected override void OnEndManipulation(TapGesture gesture)
    { // 객체 인스턴스를 생성하여 오브젝트(가구)를 띄우는 메소드
        if (gesture.isCanceled)
        {
            return;
        }
        if (gesture.targetObject != null || IsPointerOverUI(gesture))
        {
            return;
        }
        if (GestureTransformationUtility.Raycast(gesture.startPosition, hits, TrackableType.PlaneWithinPolygon))
        {   // 일반적인 레이케스트 대신임.
            GameObject placeObj = Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);
            //개체를 찾는데 도움이 되는 앵커
            var anchorObject = new GameObject("PlacementAnchor");
            anchorObject.transform.position = pose.position;
            anchorObject.transform.rotation = pose.rotation;
            placeObj.transform.parent = anchorObject.transform;
        }
        
    }

    bool IsPointerOverUI(TapGesture touch) 
        {
        // touch가 있으면을 반환
        // cavas에서 이벤트가 발생하면 이벤트를 가져옴 
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y);
        // 터치가 발생하는 동일한 위치에 이벤트를 배치한 다음 광선을 던짐
        List<RaycastResult> results = new List<RaycastResult>();
        // 레이케스트 결과에 저장
        EventSystem.current.RaycastAll(eventData, results);
        // 레이케스트를 수행 이벤트 데이터를 통해 다시 캐스팅할 데이터는 기본적으로 이 포인터 데이터임.
        // 레이케스트 결과가 있으면 이벤트 시스템 일종의 UI 구성요소를 가지고 있음을 반환.
        return results.Count > 0;

        }

    void CrosshairCalculation()
    {
        // 화면의 중앙에 광선을 쏨.
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        //배열이 던져지기 시작한 곳
        //Ray ray = arCam.ScreenPointToRay(origin);
        //이 ray는 카메라의 스크린에서 마우스 위치를 나타내기 위함
        if (GestureTransformationUtility.Raycast(origin, hits, TrackableType.PlaneWithinPolygon))
        {
            //pose는 열의 위치와 회전을 알려줌 hit[0]는 첫번째 터치 위치임.
            pose = hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
}
