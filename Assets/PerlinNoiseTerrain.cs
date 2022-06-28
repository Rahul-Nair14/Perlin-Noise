using UnityEngine;

public class PerlinNoiseTerrain : MonoBehaviour
{
  
    public int width = 256;
    public int height = 256;
    public int depth = 20;
    public int scale;

    public float XSpeed;
    public float YSpeed;
    public float XOffset;
    public float YOffset;

    public void Start()
    {

        XOffset = Random.Range(0f, 9999f);
        YOffset = Random.Range(0f, 9999f);

    }

    public void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain);

        XOffset += Time.deltaTime * XSpeed;
        YOffset += Time.deltaTime * YSpeed;

    }

    TerrainData GenerateTerrain(Terrain terrain)
    {
        terrain.terrainData.heightmapResolution = width + 1;

        terrain.terrainData.size = new Vector3(width, depth, height);

        terrain.terrainData.SetHeights(0, 0, GenerateHeights());

        return terrain.terrainData;


    }

    float[,] GenerateHeights()
    {

        float[,] heights = new float[width, height];
        for(int x=0; x<width; x++)
        {
            for(int y=0;y<height;y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }

        }
        return heights;

    }

    float CalculateHeight(int x, int y)
    {
        float XCoord = (float)x / width * scale + XOffset;
        float YCoord = (float)y / height * scale + YOffset;

        return Mathf.PerlinNoise(XCoord, YCoord);

    }
}
