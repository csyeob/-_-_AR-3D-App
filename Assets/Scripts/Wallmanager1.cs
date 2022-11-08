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
    Vector3 v;
    Vector3 pos;

    private int num;
    [SerializeField] private Button btn1;
    [SerializeField] private Button btn2;
    Mesh mesh;
    private int[] indices;

    public Material m;
    public Sprite change;

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
        //m_Text.text = num.ToString() + "\n" + point_p[num];
        num++;
    }

    public void Doit()
    {
        DrawFilled(num);
        m.SetTexture("_MainTex", change.texture);
    }

    private int[] DrawFilledIndices(Vector3[] vertices)
    {
        int triangleCount = vertices.Length - 2;
        List<int> indices = new List<int>();

        for (int i = 0; i < triangleCount; ++i)
        {
            indices.Add(0);
            indices.Add(i + 2);
            indices.Add(i + 1);
        }

        return indices.ToArray();
    }
    private void DrawFilled(int sides)
    {
        // 정점 정보
        vertices = GetCircumferencePoints(sides);
        // 정점을 잇는 폴리곤 정보
        indices = DrawFilledIndices(vertices);
        // 메시 생성
        GeneratePolygon(vertices, indices);

    }
    private Vector3[] GetCircumferencePoints(int sides)
    {
        Vector3[] points = new Vector3[sides];
        for (int i = 0; i < sides; ++i)
        {
            points[i] = new Vector3((float)point_p[i].x,(float)point_p[i].y,(float)point_p[i].z);
        }

        return points;
    }
    private void GeneratePolygon(Vector3[] vertices, int[] indices)
    {
        // 점, 반지름 정보에 따라 Update()에서
        // 지속적으로 업데이트하기 떄문에 기존 mesh 정보를 초기화
        mesh.Clear();
        // 정점, 폴리곤, uv 설정
        mesh.vertices = vertices;
        mesh.triangles = indices;
        
    }

}
