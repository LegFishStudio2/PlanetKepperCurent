using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MapGenerator
{
    [Header("Terrain heigth config")]
    public int grassLayerHeigth = 1;
    public int dirtLayerHeigth=5;
    public float heightMultipler = 4f;
    public int heightAdition = 4;
    private void Start()
    {
        seed = Random.Range(-10000, 10000);
        GenerateNoiseTexure();
        GenerateTerrain();
    }
    
    public void GenerateTerrain()
    {
        for(int x = 0;x < worldX; x++)
        {
            float height = Mathf.PerlinNoise((x + seed) * terrainFreq, seed * terrainFreq) * heightMultipler+heightAdition;
            for(int y = 0;y < height; y++)
            {
                Sprite tileSprite;
                if (y < height - dirtLayerHeigth)
                {
                    tileSprite = stone;
                }
              
                else if (y > height - grassLayerHeigth)
                {
                    tileSprite = grass;
                }
                    
                else
                {
                    tileSprite=dirt;
                }
               
                if (GenerateVoids==true)
                {
                    if (noiseTexture.GetPixel(x, y).r > SurvaceValue)
                    {
                        PlaceTile(tileSprite, x, y);
                    }
                }
                
                else
                {
                    PlaceTile(tileSprite,x,y);
                }
            }
        }
    }
}
