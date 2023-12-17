using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapGenerator : MonoBehaviour
{
    [Header("Tile Sprites")]
    public Sprite dirt;
    public Sprite stone;
    public Sprite grass;
    public Sprite sandstone;
    [Header("Noise Config")]
    public int noiseSize=200;
    public Texture2D noiseTexture;
    public int seed;
    public float caveFreq = 0.05f;
    public float terrainFreq = 0.05f;
    [Header("World Config")]
    public int worldX;
    public int worldY;
    public int chunkSize=16;
    public bool GenerateVoids;
    public float SurvaceValue = 0.25f;
    
    List<Vector2> worldTiles=new List<Vector2>();
    
    public void GenerateNoiseTexure()
    {

        noiseTexture = new Texture2D(noiseSize, noiseSize);
        for (int x = 0; x < noiseTexture.height; x++)
        {
            for (int y = 0; y < noiseTexture.width; y++)
            {
                float perl = Mathf.PerlinNoise((x + seed) * caveFreq, (y + seed) * caveFreq);
                noiseTexture.SetPixel(x, y, new Color(perl, perl, perl));
            }
        }
        noiseTexture.Apply();
    }

    public void PlaceTile(Sprite tileSprite, float x, float y)
    {
       
        GameObject newTile = new GameObject();
        newTile.transform.parent = this.transform;
        newTile.AddComponent<Rigidbody2D>();
        newTile.GetComponent<Rigidbody2D>().isKinematic = true;
        newTile.AddComponent<BoxCollider2D>();
        newTile.AddComponent<SpriteRenderer>();
        newTile.GetComponent<SpriteRenderer>().sprite = tileSprite;
        newTile.name = tileSprite.name;
        newTile.transform.position = new Vector2(x + 0.5f, y + 0.5f);
        worldTiles.Add(newTile.transform.position-(Vector3.one*0.5f));
    }
}
