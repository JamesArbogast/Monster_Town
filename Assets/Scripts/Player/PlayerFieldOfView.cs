using UnityEngine;

public class PlayerFieldOfView : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[3];
        Vector2[] uv = new Vector2[3];
        int[] triangles = new int[3];

        vertices[0] = Vector3.zero;
        vertices[1] = new Vector3();
        vertices[2] = Vector3.zero;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
