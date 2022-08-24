using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;
using TMPro;
public class LineManager : MonoBehaviour
{
    public LineRenderer lineRenderer;
    // 객체가 올바르게 배치된 시점을 파악하는 기능을 사용
    public ARPlacementInteractable aRPlacementInteractable;
    public TextMeshPro mText;
    private int pointCount = 0;
    LineRenderer line;
    public bool continuous;
    public TextMeshProUGUI buttonText;

    void Start()
    {
        aRPlacementInteractable.objectPlaced.AddListener(DrawLine);  
    }

    public void ToggleBetweenDiscreteAndContinuous()
    {
        continuous = !continuous;
        if (continuous)
        {
            buttonText.text = "Discrete";
        }
        else
        {
            buttonText.text = "Continuous";
        }
    }

    void DrawLine(ARObjectPlacementEventArgs args)
    {
        pointCount++;

        if(pointCount < 2)
        {
            line = Instantiate(lineRenderer);
            line.positionCount = 1;
        }
        else
        {
            line.positionCount = pointCount;
            if(!continuous)
              pointCount = 0;
        }

        // 2. 라인렌더러 위치 설정
        line.SetPosition(line.positionCount-1, args.placementObject.transform.position);
        //점 과 점 사의 거리 계산
        if(line.positionCount > 1)
        {
            Vector3 pointA = line.GetPosition(line.positionCount - 1);
            Vector3 pointB = line.GetPosition(line.positionCount - 2);
            float dist = Vector3.Distance(pointA, pointB);

            TextMeshPro distText = Instantiate(mText);
            distText.text = "" + dist * 100 +"cm"; // 길이 나타내는 text

            Vector3 directionVector = (pointB - pointA);
            Vector3 normal = args.placementObject.transform.up;

            Vector3 upd = Vector3.Cross(directionVector, normal).normalized;
            Quaternion rotation = Quaternion.LookRotation(-normal, upd); // 숫자 표시가 줄위에 있게 하기 위함.

            distText.transform.rotation = rotation;
            distText.transform.position = (pointA + (directionVector * 0.5f)) + (upd * 0.05f);
            

        }
    }
}
