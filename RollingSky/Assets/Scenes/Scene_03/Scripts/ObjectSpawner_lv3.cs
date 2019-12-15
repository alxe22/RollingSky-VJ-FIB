using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner_lv3 : MonoBehaviour
{
    /*public GameObject bulletBill;
    public GameObject thwomp;
    public GameObject bobOmb;*/
    public GameObject dragonBall;
    public GameObject stick;
    public GameObject corpCapsule;
    public GameObject kameWall;
    public TextAsset objectsPosition;

    void createTile(char tile, Vector3 pos, ref int dragonBallCount) {
        if(tile == '1') {
            dragonBallCount += 1;
            GameObject objectInstance = Instantiate(dragonBall, pos, dragonBall.transform.rotation) as GameObject;
            objectInstance.name = "dragonBall" + dragonBallCount;
        }
        else if(tile == '2') {
            GameObject objectInstance = Instantiate(stick, pos, stick.transform.rotation) as GameObject;
        }
        else if(tile == '3') {
            GameObject objectInstance = Instantiate(corpCapsule, pos, corpCapsule.transform.rotation) as GameObject;
        }
        else if(tile == '4') {
            GameObject objectInstance = Instantiate(kameWall, pos, kameWall.transform.rotation) as GameObject;
        }
    }

    void Start()
    {
     string[] lines = objectsPosition.text.Split('\n');
     int dragonBallCount = 0;
        for (int i = 0; i < lines.Length-1; ++i) {
            string[] coord = lines[i].Split(' ');
            createTile(char.Parse(coord[0]), new Vector3(float.Parse(coord[1]), float.Parse(coord[2]), float.Parse(coord[3])),ref dragonBallCount);
        }
    }
}
