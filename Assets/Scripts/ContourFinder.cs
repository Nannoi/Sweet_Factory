using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp.Demo;
using OpenCvSharp;

public class ContourFinder : WebCamera
// Start is called before the first frame update
{
    private Mat image;
    protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
    {
        image = OpenCvSharp.Unity.TextureToMat(input);

        if (output == null)
            output = OpenCvSharp.Unity.MatToTexture(image);
        else
            OpenCvSharp.Unity.MatToTexture(image,output);

        return true;
    }
}
