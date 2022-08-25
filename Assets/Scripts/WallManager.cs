using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class WallManager : MonoBehaviour
{
    public Text m_Text;
   // float [] posX;
   // float [] posY;
   // private int i = 0;
   // public GameObject wall;
    //public ARPlacementInteractable aRPlacementInteractable;

    public GameObject gameObjectToinstatiate;
    private GameObject spawnObject;
    private ARRaycastManager aRRaycastManager;
    private Vector2 touchPosition;
    private int num = 0;
    private string num_s;
    Pose[] hits_;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }
    bool TryGetTouchPosition(out Vector2 touchposition)
    {
        if(Input.touchCount > 0)
        {
            touchposition = Input.GetTouch(0).position;
            return true;
        }
        touchposition = default;
        return false;
    }

    void Start()
    {
      
    }
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
             //hits_[num] = hits[0].pose;
          
               // float x = hits[3].pose.position.x - hits[0].pose.position.x;
               // float z = hits[0].pose.position.z - hits[1].pose.position.z; // y로 해야함
               // float aver_x = (hits[3].pose.position.x + hits[0].pose.position.x) / 2;
               // float aver_z = (hits[0].pose.position.z + hits[2].pose.position.z) / 2;
               // Vector3 local = new Vector3(x, 0, z);
                spawnObject = Instantiate(gameObjectToinstatiate, hitPose.position, hitPose.rotation);
            // spawnObject.transform.localScale = local;
            m_Text.text = spawnObject.transform.position + " ";
        }
    }
    public void drawWall()
    {
        num++;
        num_s = num.ToString();
        m_Text.text = num_s;

    }
   /* public void drawWall()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //m_Text.text = "Touch Position : " + touch.position;
            posX[i] = touch.position.x;
            posY[i] = touch.position.y;
            i++;
            GameObject g = Instantiate(wall);
            m_Text.text = i + "번째" + " " + posX[i] + " " + posY[i];
        }
        if (i == 3)
        {
            GameObject g = Instantiate(wall);
            RectTransform rectTran = g.GetComponent<RectTransform>();
            g.transform.position = new Vector3(posX[0], posY[0]);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, posX[4] - posX[0]);
            rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, posY[0] - posY[1]);
            i = 0;
        }   
    }*/
}