using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class can_Barı : MonoBehaviour
{
    eagle eagle;
  public Slider slider;
    void Start()
    {
        eagle= GetComponent<eagle>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value=eagle.eaglehp;
    }
}
