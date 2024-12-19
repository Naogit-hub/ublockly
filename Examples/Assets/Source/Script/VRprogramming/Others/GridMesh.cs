using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridMesh : MonoBehaviour
{
    public float cellSize = 1f; // グリッドの1マスのサイズ
    public int gridWidth = 10; // 横方向のグリッド数
    public int gridHeight = 10; // 縦方向のグリッド数

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[(gridWidth + 1) * (gridHeight + 1)];
        int[] indices = new int[gridWidth * (gridHeight + 1) * 2 + gridHeight * (gridWidth + 1) * 2];

        // 頂点の設定
        int index = 0;
        for (int z = 0; z <= gridHeight; z++)
        {
            for (int x = 0; x <= gridWidth; x++)
            {
                vertices[index++] = new Vector3(x * cellSize, 0, z * cellSize);
            }
        }

        // インデックスの設定
        index = 0;
        for (int z = 0; z <= gridHeight; z++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                indices[index++] = z * (gridWidth + 1) + x;
                indices[index++] = z * (gridWidth + 1) + x + 1;
            }
        }
        for (int x = 0; x <= gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                indices[index++] = z * (gridWidth + 1) + x;
                indices[index++] = (z + 1) * (gridWidth + 1) + x;
            }
        }

        mesh.vertices = vertices;
        mesh.SetIndices(indices, MeshTopology.Lines, 0);

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
