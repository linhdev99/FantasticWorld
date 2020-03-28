using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterTiles : Tile {

    [SerializeField]
    private Sprite[] waterSprites;

    [SerializeField]
    private Sprite preview;

#if UNITY_EDITOR
[MenuItem("Assets/Create/Tiles/WaterTiles")]

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int y = -1; y <= 1; y++)
            for(int x = -1; x <= 1; x++)
            {
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);
                if(hasWater(tilemap,nPos))
                {
                    tilemap.RefreshTile(nPos);
                }
            }
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        string composition = string.Empty;
        for (int y = -1; y <= 1 ; y++)
            for(int x = -1; x <= 1; x++)
            {
                if (x != 0 || y != 0)
                {
                    if (hasWater(tilemap, new Vector3Int(position.x + x, position.y + y, position.z)))
                    {
                        composition += 'W';
                    }
                    else
                    {
                        composition += 'E';
                    }
                }
            }
        tileData.sprite = waterSprites[48];


        if (composition == "WWWWWWWW")
        {
            tileData.sprite = waterSprites[0];
        }
        int randomVal = Random.Range(0, 100);
        if (randomVal < 15)
        {
            tileData.sprite = waterSprites[1];
        }
        else if (randomVal >= 15 && randomVal < 35)
        {
            tileData.sprite = waterSprites[0];
        }
        else
        {
            tileData.sprite = waterSprites[0];
        }

        if (composition[1] == 'E' && composition[5] == 'W' && composition[6] == 'W' && composition[7] == 'W')
        {
            tileData.sprite = waterSprites[6];
        }
        if (composition[4] == 'E' && composition[3] == 'W' && composition[5] == 'W' && composition[0] == 'W')
        {
            tileData.sprite = waterSprites[3];
        }
        if (composition[3] == 'E' && composition[2] == 'W' && composition[4] == 'W' && composition[7] == 'W')
        {
            tileData.sprite = waterSprites[9];
        }
        if (composition[6] == 'E' && composition[0] == 'W' && composition[1] == 'W' && composition[2] == 'W')
        {
            tileData.sprite = waterSprites[11];
        }
        if (composition[1] == 'E' && composition[4] == 'E' && composition[3] == 'W' && composition[5] == 'W' && composition[6] == 'W')
        {
            tileData.sprite = waterSprites[4];
        }
        if (composition[3] == 'E' && composition[1] == 'E' && composition[6] == 'W' && composition[7] == 'W' && composition[4] == 'W')
        {
            tileData.sprite = waterSprites[8];
        }
        if (composition[1] == 'W' && composition[2] == 'W' && composition[4] == 'W' && composition[3] == 'E' && composition[6] == 'E')
        {
            tileData.sprite = waterSprites[14];
        }
        if (composition[3] == 'W' && composition[0] == 'W' && composition[1] == 'W' && composition[6] == 'E' && composition[4] == 'E')
        {
            tileData.sprite = waterSprites[13];
        }
        if (composition == "WWEWWWWW")
        {
            tileData.sprite = waterSprites[5];
        }
        if (composition == "EWWWWWWW")
        {
            tileData.sprite = waterSprites[7];
        }
        if (composition == "WWWWWWWE")
        {
            tileData.sprite = waterSprites[10];
        }
        if (composition == "WWWWWEWW")
        {
            tileData.sprite = waterSprites[12];
        }
        if (composition[3] == 'E' && composition[1] == 'E' && composition[6] == 'E' && composition[4] == 'W')
        {
            tileData.sprite = waterSprites[17];
        }
        if (composition[3] == 'W' && composition[1] == 'E' && composition[6] == 'E' && composition[4] == 'E')
        {
            tileData.sprite = waterSprites[15];
        }
        if (composition[3] == 'E' && composition[1] == 'W' && composition[6] == 'E' && composition[4] == 'E')
        {
            tileData.sprite = waterSprites[18];
        }
        if (composition[3] == 'E' && composition[1] == 'E' && composition[6] == 'W' && composition[4] == 'E')
        {
            tileData.sprite = waterSprites[16];
        } 
        if (composition[3] == 'E' && composition[4] == 'W' && composition[1] == 'W' && composition[6] == 'E' && composition[2] == 'E')
        {
            tileData.sprite = waterSprites[21];
        }
        if (composition[3] == 'W' && composition[4] == 'E' && composition[1] == 'W' && composition[6] == 'E' && composition[0] == 'E')
        {
            tileData.sprite = waterSprites[22];
        }
        if (composition[3] == 'E' && composition[4] == 'W' && composition[1] == 'E' && composition[6] == 'W' && composition[7] == 'E')
        {
            tileData.sprite = waterSprites[23];
        }
        if (composition[3] == 'W' && composition[4] == 'E' && composition[1] == 'E' && composition[6] == 'W' && composition[5] == 'E')
        {
            tileData.sprite = waterSprites[24];
        }
        if (composition[3] == 'W' && composition[4] == 'E' && composition[1] == 'W' && composition[6] == 'W' && composition[5] == 'E' && composition[0] == 'E')
        {
            tileData.sprite = waterSprites[25];
        }
        if (composition[3] == 'W' && composition[4] == 'W' && composition[1] == 'E' && composition[6] == 'W' && composition[5] == 'E' && composition[7] == 'E')
        {
            tileData.sprite = waterSprites[26];
        }
        if (composition[3] == 'E' && composition[4] == 'W' && composition[1] == 'W' && composition[6] == 'W' && composition[7] == 'E' && composition[2] == 'E')
        {
            tileData.sprite = waterSprites[27];
        }
        if (composition[3] == 'W' && composition[4] == 'W' && composition[1] == 'W' && composition[6] == 'E' && composition[0] == 'E' && composition[2] == 'E')
        {
            tileData.sprite = waterSprites[28];
        }
        if (composition == "EWEWWEWE")
        {
            tileData.sprite = waterSprites[29];
        }
        if (composition == "WWEWWWWE")
        {
            tileData.sprite = waterSprites[30];
        }
        if (composition == "EWEWWWWW")
        {
            tileData.sprite = waterSprites[31];
        }
        if (composition == "EWWWWEWW")
        {
            tileData.sprite = waterSprites[32];
        }
        if (composition == "WWWWWEWE")
        {
            tileData.sprite = waterSprites[33];
        }
        if (composition[1] == 'W' && composition[3] == 'W' && composition[0] == 'W' && composition[6] == 'W' && composition[4] == 'E' && composition[5] == 'E')
        {
            tileData.sprite = waterSprites[34];
        }
        if (composition[1] == 'W' && composition[3] == 'W' && composition[5] == 'W' && composition[6] == 'W' && composition[4] == 'E' && composition[0] == 'E')
        {
            tileData.sprite = waterSprites[35];
        }
        if (composition[3] == 'W' && composition[4] == 'W' && composition[7] == 'W' && composition[6] == 'W' && composition[1] == 'E' && composition[5] == 'E')
        {
            tileData.sprite = waterSprites[36];
        }
        if (composition[3] == 'W' && composition[4] == 'W' && composition[5] == 'W' && composition[6] == 'W' && composition[1] == 'E' && composition[7] == 'E')
        {
            tileData.sprite = waterSprites[37];
        }
        if (composition[1] == 'W' && composition[3] == 'E' && composition[4] == 'W' && composition[7] == 'W' && composition[6] == 'W' && composition[2] == 'E')
        {
            tileData.sprite = waterSprites[38];
        }
        if (composition[1] == 'W' && composition[3] == 'E' && composition[4] == 'W' && composition[2] == 'W' && composition[6] == 'W' && composition[7] == 'E')
        {
            tileData.sprite = waterSprites[39];
        }
        if (composition[0] == 'E' && composition[1] == 'W' && composition[2] == 'W' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'E')
        {
            tileData.sprite = waterSprites[40];
        }
        if (composition[0] == 'W' && composition[1] == 'W' && composition[2] == 'E' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'E')
        {
            tileData.sprite = waterSprites[41];
        }
        if (composition[3] == 'E' && composition[4] == 'E' && composition[1] == 'W' && composition[6] == 'W')
        {
            tileData.sprite = waterSprites[19];
        }
        if (composition[3] == 'W' && composition[4] == 'W' && composition[1] == 'E' && composition[6] == 'E')
        {
            tileData.sprite = waterSprites[20];
        }
        if (composition == "EWEWWWWE")
        {
            tileData.sprite = waterSprites[42];
        }
        if (composition == "EWEWWEWW")
        {
            tileData.sprite = waterSprites[43];
        }
        if (composition == "EWWWWEWE")
        {
            tileData.sprite = waterSprites[44];
        }
        if (composition == "WWEWWEWE")
        {
            tileData.sprite = waterSprites[45];
        }
        if (composition == "WWEWWEWW")
        {
            tileData.sprite = waterSprites[46];
        }
        if (composition == "EWWWWWWE")
        {
            tileData.sprite = waterSprites[47];
        }
        if (composition == "EEEEEEEE")
        {
            tileData.sprite = waterSprites[48];
        }

    }

    private bool hasWater(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }
    public static void CreateWaterTiles()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save WaterTile", "New WaterTile", "asset", "Save watertile", "Assets");
        if (path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WaterTiles>(), path);
    }


#endif
}
