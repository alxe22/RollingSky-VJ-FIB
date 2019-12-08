using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Map_lv02 : MonoBehaviour
{

    public Transform brickTile;
    public Transform brownTile;
    public Transform pipeTile;
    public Transform questionTile;
    public Transform grassTile;
    public List<Transform> Tiles = new List<Transform>();

    public TextAsset Maptxt;

    void createTile(char tile, float posx, float posy) {
      Vector3 pos = new Vector3((posx-2.0f)*-1,-0.1f,-posy);
      if(tile == '1') {
        Transform newTile = Instantiate(brickTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '2') {
        Transform newTile = Instantiate(brownTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '3') {
        Transform newTile = Instantiate(pipeTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '4') {
        Transform newTile = Instantiate(questionTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
        Tiles.Add(newTile);
      }
      else if(tile == '5') {
        Transform newTile = Instantiate(grassTile,pos,Quaternion.Euler(Vector3.left*90)) as Transform;
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
