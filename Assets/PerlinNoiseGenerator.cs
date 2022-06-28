using UnityEngine;

public class PerlinNoiseGenerator : MonoBehaviour
{

    public int TextureWidth, TextureHeight;
    public float PerlinScale, XOffset, YOffset;

    Renderer renderer;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
        XOffset = Random.Range(0f, 99999f);
        YOffset = Random.Range(0f, 99999f);

    }
    void Update()
    {

        renderer.material.mainTexture = GenerateTexture();

    }

    Texture2D GenerateTexture()
    {

        Texture2D texture = new Texture2D(TextureWidth, TextureHeight);

        for(int x=0; x<TextureWidth; x++)
        {
            for(int y=0; y<TextureHeight; y++)
            {
                float XCoord = ((float)x/TextureWidth) * PerlinScale + XOffset;
                float YCoord = ((float)y / TextureHeight) * PerlinScale + YOffset;
                float perlinNoise = Mathf.PerlinNoise(XCoord, YCoord);
                texture.SetPixel(x, y, new Color(perlinNoise,perlinNoise,perlinNoise));

            }
        }

        texture.filterMode = FilterMode.Point;
        texture.Apply();
        return texture;

    }
}
