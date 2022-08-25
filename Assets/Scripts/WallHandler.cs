using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class WallHandler : MonoBehaviour
{

    private static WallHandler instance;
    // 데이터 인스턴스들을 다른 스크립트들에 반환하여 사용함.
    public static WallHandler Instance
    {
        get
        {
            if (instance == null)
            {
                //null이면 인스턴스를 생성
                //같은 유형의 타입을 찾고 wallhandler클래스를 찾으면 여기에 해당 인스턴스를 전달함.
                instance = FindObjectOfType<WallHandler>();
            }
            return instance;
            // null이 아니면 instance를 반환
        }
    }
    public ARPlacementInteractable aRPlacementInteractable;
    private Pose p;

    // Start is called before the first frame update
    void Update()
    {
        aRPlacementInteractable.objectPlaced.AddListener(madePoint);
    }

    void madePoint(ARObjectPlacementEventArgs args)
    {
        p.position = args.placementObject.transform.position;
    }
    public Pose GetPosition()
    {
        return p;
    }
}
