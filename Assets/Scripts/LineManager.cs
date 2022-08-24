using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class LineManager : MonoBehaviour
{
    public LineRenderer lineRenderer;
    // 객체가 올바르게 배치된 시점을 파악하는 기능을 사용
    public ARPlacementInteractable aRPlacementInteractable;

    void Start()
    {
        aRPlacementInteractable.objectPlaced.AddListener(DrawLine);  
    }
    void DrawLine(ARObjectPlacementEventArgs args)
    {
        // 1. 포인트 카운트 늘리기 점 늘린다고 생각하면됨
        lineRenderer.positionCount++;
        // 2. 라인렌더러 위치 설정
        lineRenderer.SetPosition(lineRenderer.positionCount-1, args.placementObject.transform.position);
    }
}
