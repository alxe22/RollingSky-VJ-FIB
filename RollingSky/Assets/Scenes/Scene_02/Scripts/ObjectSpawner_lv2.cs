using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner_lv2 : MonoBehaviour
{
    public GameObject bulletBill;
    public GameObject thwomp;
    public GameObject bobOmb;
    public TextAsset objectsPosition;
    void createTile(char tile, Vector3 pos, ref int Diamond_count) {
        if(tile == '1') {
            /*Diamond_count += 1;
            GameObject objectInstance = Instantiate(diamond, pos, Quaternion.Euler(Vector3.left*90)) as GameObject;
            objectInstance.name = "Diamond" + Diamond_count;*/
        }
        else if(tile == '2') {
            GameObject objectInstance = Instantiate(bulletBill, pos, bulletBill.transform.rotation) as GameObject;
        }
        else if(tile == '3') {
            GameObject objectInstance = Instantiate(thwomp, pos, thwomp.transform.rotation) as GameObject;
        }
        else if(tile == '4') {
            GameObject objectInstance = Instantiate(bobOmb, pos, bobOmb.transform.rotation) as GameObject;
        }
        /*else if(tile == '5') {
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
        }*/
    }

    void Start()
    {
     string[] lines = objectsPosition.text.Split('\n');
     int Diamond_count = 0;
        for (int i = 0; i < lines.Length-1; ++i) {
            //createTile(lines[j][i],(float)i,(float)j);  //lines[j][i]
            string[] coord = lines[i].Split(' ');
            // [object, x, y, z]
            createTile(char.Parse(coord[0]), new Vector3(float.Parse(coord[1]), float.Parse(coord[2]), float.Parse(coord[3])),ref Diamond_count);
        }
    }
}
