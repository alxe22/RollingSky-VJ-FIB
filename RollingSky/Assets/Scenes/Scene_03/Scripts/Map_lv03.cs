using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Map_lv03 : MonoBehaviour
{

    public Transform jumpingTile;
    public Transform shenronTile;
    public Transform paprikaTile;
    public Transform movingCobblestoneTile;
    public Transform namekTile;
    public Transform namek2Tile;
    public Transform movingCloudsTile;
    public Transform celulaRingTile;
    public List<Transform> Tiles = new List<Transform>();

    public TextAsset Maptxt;

    void createTile(char tile, float posx, float posy) {
      Vector3 pos = new Vector3((posx-2.0f)*-1,-0.1f,-posy);
      if(tile == '1') {
        Transform newTile = Instantiate(paprikaTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '2') {
        Transform newTile = Instantiate(movingCloudsTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '3') {
        Transform newTile = Instantiate(movingCobblestoneTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '4') {
        Transform newTile = Instantiate(jumpingTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '5') {
        Transform newTile = Instantiate(celulaRingTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '6') {
        Transform newTile = Instantiate(shenronTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '7') {
        Transform newTile = Instantiate(namekTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '8') {
        Transform newTile = Instantiate(namek2Tile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
    }

    // Start is called before the first frame update
    void Start()
    {
          string[] lines = Maptxt.text.Split('\n');
          for (int j = 0; j < lines.Length-1; ++j) {
            for (int i = 0; i < 5; ++i) {
              createTile(lines[j][i],(float)i,(float)j);  //lines[j][i]
            }
          }

    }
}
