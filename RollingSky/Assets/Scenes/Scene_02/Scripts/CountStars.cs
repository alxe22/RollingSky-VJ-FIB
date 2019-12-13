using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountStars : MonoBehaviour
{
    public Text text;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
      count = 0;
      text.text = count + " / 5";
    }

    // Update is called once per frame
    void Update()
    {
      count = 0;
      if(GameObject.Find("Star1") == null) count += 1;
      if(GameObject.Find("Star2") == null) count += 1;
      if(GameObject.Find("Star3") == null) count += 1;
      if(GameObject.Find("Star4") == null) count += 1;
      if(GameObject.Find("Star5") == null) count += 1;
      text.text = count + " / 5";
    }
}
