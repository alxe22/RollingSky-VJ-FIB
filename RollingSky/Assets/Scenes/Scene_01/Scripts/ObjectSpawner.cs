using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject diamond;
    public TextAsset objectsPosition;

    void createTile(char tile, Vector3 pos) {
        if(tile == '1') {
            GameObject objectInstance = Instantiate(diamond,pos,Quaternion.Euler(Vector3.left*90)) as GameObject;
        }
    }

    void Start()
    {
     string[] lines = objectsPosition.text.Split('\n');
        for (int i = 0; i < lines.Length; ++i) {
            //createTile(lines[j][i],(float)i,(float)j);  //lines[j][i]
            string[] coord = lines[i].Split(' ');
            char tileType = char.Parse(coord[0]);
            // [object, x, y, z]
            createTile(char.Parse(coord[0]), new Vector3(float.Parse(coord[1]), float.Parse(coord[2]), float.Parse(coord[3])));
        }
    }
}
