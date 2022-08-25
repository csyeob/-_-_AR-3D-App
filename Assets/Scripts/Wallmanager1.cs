using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class Wallmanager1 : MonoBehaviour
{

    List<Vector3> point_p = new List<Vector3>();
    Pose p;

    private ARRaycastManager aRRaycastManager;
    private Vector2 touchPosition;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject gameObjectToinstatiate;
    private GameObject spawnObject;
    public Text m_Text;
    private int num;
    [SerializeField] private Button btn1;
    void Start()
    {
        num = 0;
        btn1.onClick.AddListener(() => madeWall());

    }
    public void madeWall()
    {
        p = WallHandler.Instance.GetPosition();
        point_p.Add(p.position);
        Debug.Log(point_p[num]);
        Debug.Log(num);
        m_Text.text = num.ToString() + "\n" + point_p[num];
        num++;
    }
}
