using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;



[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Wallmanager1 : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;

    List<Vector3> point_p = new List<Vector3>();
    Pose p;

    public Text m_Text;
    private int num;
    [SerializeField] private Button btn1;
    [SerializeField] private Button btn2;
    public GameObject wall;
    Mesh mesh;
    //MeshRenderer mes;
    //public Material mater;

    private void Awake()
    {
        mesh = new Mesh();
        //mes.material = mater;   
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;

    }
    void Start()
    {
        num = 0;
        btn1.onClick.AddListener(() => madeWall());
        btn2.onClick.AddListener(() => Doit());
 
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

    public void Doit()
    {
        CreateShape();
        UpdateMesh();
    }
    void CreateShape()
    {
        Debug.Log(point_p[1]);
        vertices = new Vector3[]
        {
            new Vector3((float)point_p[0].x,(float)point_p[0].y,(float)point_p[0].z),
            new Vector3((float)point_p[1].x,(float)point_p[1].y,(float)point_p[1].z),
            new Vector3((float)point_p[2].x,(float)point_p[2].y,(float)point_p[2].z)
        };
        triangles = new int[]
        {
            0,1,2
        };
        m_Text.text = "createshape 여기까지 돌아가긴함.";
    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        m_Text.text = "update mesh 여기까지 돌아가긴함.";
    }


}
