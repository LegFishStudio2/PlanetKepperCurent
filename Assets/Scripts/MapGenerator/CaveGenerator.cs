using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MapGenerator
{
    private void Start()
    {
        seed = Random.Range(-10000, 10000);
        GenerateNoiseTexure();
        GenerateCave();
    }
    public void GenerateCave()
    {
        for(int x = 0; x<worldX; x++)
        {
            for(int y = 0; y<worldY; y++)
            {
                if(GenerateVoids==true)
                {
                    if (noiseTexture.GetPixel(x, y).r > SurvaceValue)
                    {
                        PlaceTile(stone, x, -y);
                    }
                }
                else
                {
                    PlaceTile(stone,x,-y);
                }
            }
        }
    }
}
