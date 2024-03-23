using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    static public float timerDelay = 0.05f;
    static public float scaleSmall = 1f;
    static public float scaleBig = 2f;
    static public string nameSmall = "SmallCenter";
    static public string nameBig = "BigCenter";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void setScaleBig(float newScale) {
        scaleBig = newScale;
    }
}
