using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour
{
    public int size_x = 10;
    public int size_z = 10;
    public float tileSize = 1.0f;

    public Texture2D tilesSet;
    private int tileResolution = 32;
    
    void Start()
    {
        BuildMesh();
    }

    Color[][] ChopUpTiles()
    {
        int numTilesPerRow = tilesSet.width / tileResolution;
        int numRows = tilesSet.height / tileResolution;

        Color[][] tiles = new Color[9][];

        for (int y = 0; y < numRows; y++)
        {
            for (int x = 0; x < numTilesPerRow; x++)
            {
                tiles[y * numTilesPerRow + x] = tilesSet.GetPixels(x * tileResolution, y * tileResolution, tileResolution,
                    tileResolution);
            }
        }

        return tiles;
    }

    void BuildTexture()
    {
        int texHeight = size_z * tileResolution;
        int texWidth = size_x * tileResolution;

        Color[][] tiles = ChopUpTiles();
        
        Texture2D texture = new Texture2D(texWidth, texHeight);
        
        // SET CORNERS
        texture.SetPixels(0, 0, tileResolution, tileResolution, tiles[0]);
        texture.SetPixels((size_x - 1) * tileResolution, 0, tileResolution, tileResolution, tiles[2]);
        texture.SetPixels((size_x - 1) * tileResolution, (size_z - 1) * tileResolution, tileResolution, tileResolution, tiles[8]);
        texture.SetPixels(0, (size_z - 1) * tileResolution, tileResolution, tileResolution, tiles[6]);
        
        // SET EDGES
        // Horizontal edges
        for (int y = 1; y < (size_z-1); y++)
        {
            texture.SetPixels(0, y * tileResolution, tileResolution, tileResolution, tiles[3]);
            texture.SetPixels((size_x - 1) * tileResolution, y * tileResolution, tileResolution, tileResolution, tiles[5]);
        }
        
        // Vertical edges
        for (int x = 1; x < (size_x - 1); x++)
        {
            texture.SetPixels(x * tileResolution, 0, tileResolution, tileResolution, tiles[1]);
            texture.SetPixels(x * tileResolution, (size_z - 1) * tileResolution, tileResolution, tileResolution, tiles[7]);
        }
        
        // FILL OUT THE MIDDLE
        for (int y = 1; y < (size_z - 1); y++)
        {
            for (int x = 1; x < (size_x - 1); x++)
            {
                texture.SetPixels(x * tileResolution, y * tileResolution, tileResolution, tileResolution, tiles[4]);
            }
        }


        texture.filterMode = FilterMode.Point;
        texture.Apply();

        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
        mesh_renderer.sharedMaterial.mainTexture = texture;
    }

    void BuildMesh()
    {
        int numTiles = size_x * size_z;
        int numTriangles = numTiles * 2;
        
        int vsize_x = size_x + 1;
        int vsize_z = size_z + 1;
        int numVerts = vsize_x * vsize_z;
        
        // Generate the mesh data
        Vector3[] vertices = new Vector3[numVerts];
        Vector3[] normals = new Vector3[numVerts];
        Vector2[] uv = new Vector2[numVerts];

        int[] triangles = new int[numTriangles * 3];

        int x, z;
        for (z = 0; z < vsize_z; z++)
        {
            for (x = 0; x < vsize_x; x++)
            {
                vertices[z * vsize_x + x] = new Vector3( x*tileSize, 0, z*tileSize );
                normals[z * vsize_x + x] = Vector3.up;
                uv[z * vsize_x + x] = new Vector2((float)x / size_x, (float)z / size_z);
            }
        }

        for (z = 0; z < size_z; z++)
        {
            for (x = 0; x < size_x; x++)
            {
                int squareIndex = z * size_x + x;
                int triIndex = squareIndex * 6;
                triangles[triIndex + 0] = z * vsize_x + x + 0;
                triangles[triIndex + 1] = z * vsize_x + x + vsize_x + 1;
                triangles[triIndex + 2] = z * vsize_x + x + vsize_x + 0;

                triangles[triIndex + 3] = z * vsize_x + x + 0;
                triangles[triIndex + 4] = z * vsize_x + x + 1;
                triangles[triIndex + 5] = z * vsize_x + x + vsize_x + 1;
            }
        }


        // Create a new mesh and populate with data
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        MeshFilter mf = GetComponent<MeshFilter>();
        MeshRenderer mr = GetComponent<MeshRenderer>();
        MeshCollider mc = GetComponent<MeshCollider>();

        mf.mesh = mesh;
        mc.sharedMesh = mesh;

        BuildTexture();
    }
    
}
