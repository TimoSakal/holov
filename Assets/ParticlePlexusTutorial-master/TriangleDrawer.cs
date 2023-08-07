using UnityEngine;

public class TriangleDrawer : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    Mesh mesh;
    private void Start()
    {
        // Create a new mesh
         mesh = new Mesh();

        // Define the vertices of the triangle
        Vector3[] vertices = new Vector3[3];
        vertices[0] = pointA.position;
        vertices[1] = pointB.position;
        vertices[2] = pointC.position;

        // Define the triangle's indices
        int[] indices = new int[] { 0, 1, 2 };

        // Assign the vertices and indices to the mesh
        mesh.vertices = vertices;
        mesh.triangles = indices;

        // Create a new mesh renderer and assign the mesh to it
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = mesh;
    }

    private void Update()
    {
        Vector3[] vertices = new Vector3[3];
        vertices[0] = pointA.position;
        vertices[1] = pointB.position;
        vertices[2] = pointC.position;

        // Встановити нові вершини в сітку
        mesh.vertices = vertices;

        // Оновити малюнок
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
