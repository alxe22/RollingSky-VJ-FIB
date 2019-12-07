using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
      slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
      slider.value = - GameObject.Find("Player").transform.position.z;
    }
}
