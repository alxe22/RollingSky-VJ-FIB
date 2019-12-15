using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner_lv2 : MonoBehaviour
{
    public GameObject bulletBill;
    public GameObject thwomp;
    public GameObject bobOmb;
    public GameObject star;
    public TextAsset objectsPosition;
    void createTile(char tile, Vector3 pos, ref int starCount) {
        if(tile == '1') {
            starCount += 1;
            GameObject objectInstance = Instantiate(star, pos, star.transform.rotation) as GameObject;
            objectInstance.name = "Star" + starCount;
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
    }

    void Start()
    {
     string[] lines = objectsPosition.text.Split('\n');
     int starCount = 0;
        for (int i = 0; i < lines.Length-1; ++i) {
            string[] coord = lines[i].Split(' ');
            createTile(char.Parse(coord[0]), new Vector3(-float.Parse(coord[1]), float.Parse(coord[2]), float.Parse(coord[3])+1),ref starCount);
        }
    }
}
