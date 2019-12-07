using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDiamonds : MonoBehaviour
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
      if(GameObject.Find("Diamond1") == null) count += 1;
      if(GameObject.Find("Diamond2") == null) count += 1;
      if(GameObject.Find("Diamond3") == null) count += 1;
      if(GameObject.Find("Diamond4") == null) count += 1;
      if(GameObject.Find("Diamond5") == null) count += 1;
      text.text = count + " / 5";
    }
}
