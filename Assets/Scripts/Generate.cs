using UnityEngine;
using UnityEditor;
using System.Collections;

public class Generate : MonoBehaviour
{

    private Mesh s;
    public int RoundEdges; // Rounds all edges //
    public int RoundTopLeft; // Rounds Top Left Edge //
    public int RoundTopRight; // Rounds Top Right Edge //
    public int RoundBottomLeft; //Rounds Bottom Left Edge //
    public int RoundBottomRight; //Rounds Bottom Right Edge //

    private Vector3[] vertices = {
       new Vector2(0,0),
       new Vector2(0,1),
       new Vector2(1,1),
       new Vector2(1,0)
   };

    private int[] triangles = {
       0,1,2,
       2,3,0
   };

    public void Create()
    {
        s = new Mesh();
        GetComponent<MeshFilter>().sharedMesh = s;
        s.name = "S";
    }

    void Start()
    {
        Create();
    }
    void Update()
    {
        // Round Edges //
        s.vertices = vertices;
        s.triangles = triangles;
    }
}