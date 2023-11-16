using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class colorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public CameraDetect camScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToRed()
    {
        Debug.Log("Red");

        camScript.upperCol = new Scalar(10, 255, 255);
        camScript.lowerCol = new Scalar(0, 100, 54);
    }

    public void ChangeToGreen()
    {
        Debug.Log("Green");
        camScript.upperCol = new Scalar(82, 255, 255);
        camScript.lowerCol = new Scalar(35, 50, 34);
    }

    public void ChangeToBlue()
    {
        Debug.Log("Blue");
        camScript.upperCol = new Scalar(120, 255, 255);  // Hue: 120 (blue), Saturation: 255, Value: 255
        camScript.lowerCol = new Scalar(94, 50, 50);    // Hue: 94, Saturation: 50, Value: 50
    }

}
