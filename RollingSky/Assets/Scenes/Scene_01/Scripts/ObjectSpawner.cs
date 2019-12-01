using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject diamond;
    public GameObject identityDisc;
    public GameObject blueWall;
    public GameObject greenWall;
    public GameObject yellowWall;
    public GameObject orangeWall;
    public GameObject redWall;
    public GameObject floatingCube;
    public TextAsset objectsPosition;

    void createTile(char tile, Vector3 pos) {
        if(tile == '1') {
            GameObject objectInstance = Instantiate(diamond, pos, Quaternion.Euler(Vector3.left*90)) as GameObject;
        }
        else if(tile == '2') {
            GameObject objectInstance = Instantiate(identityDisc, pos, identityDisc.transform.rotation) as GameObject;
        }
        else if(tile == '3') {
            GameObject objectInstance = Instantiate(blueWall, pos, blueWall.transform.rotation) as GameObject;
        }
        else if(tile == '4') {
            GameObject objectInstance = Instantiate(greenWall, pos, greenWall.transform.rotation) as GameObject;
        }
        else if(tile == '5') {
            GameObject objectInstance = Instantiate(yellowWall, pos, yellowWall.transform.rotation) as GameObject;
        }
        else if(tile == '6') {
            GameObject objectInstance = Instantiate(orangeWall, pos, orangeWall.transform.rotation) as GameObject;
        }
        else if(tile == '7') {
            GameObject objectInstance = Instantiate(redWall, pos, redWall.transform.rotation) as GameObject;
        }
        else if(tile == '8') {
            GameObject objectInstance = Instantiate(floatingCube, pos, floatingCube.transform.rotation) as GameObject;
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
