using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountBalls : MonoBehaviour
{
    public Text text;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
      count = 0;
      text.text = count + " / 7";
    }

    // Update is called once per frame
    void Update()
    {
      count = 0;
      if(GameObject.Find("dragonBall1") == null) count += 1;
      if(GameObject.Find("dragonBall2") == null) count += 1;
      if(GameObject.Find("dragonBall3") == null) count += 1;
      if(GameObject.Find("dragonBall4") == null) count += 1;
      if(GameObject.Find("dragonBall5") == null) count += 1;
      if(GameObject.Find("dragonBall6") == null) count += 1;
      if(GameObject.Find("dragonBall7") == null) count += 1;
      text.text = count + " / 7";
    }
}
