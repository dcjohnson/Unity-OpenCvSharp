using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class WebCam : MonoBehaviour
{
    OpenCvHandDetection cvHandDetection;
    OpenCvVideoCaptureManager cvVideoCapture;
    Texture2D textureToEdit;

    void Start()
    {
        cvVideoCapture = new OpenCvVideoCaptureManager();
        textureToEdit = new Texture2D(cvVideoCapture.Width, cvVideoCapture.Height);
        cvHandDetection = new OpenCvHandDetection();
    }

    void Update()
    {
        var curBuffer = cvVideoCapture.ReadAndGetCurrentBuffer();
        var pixArray = cvHandDetection.HandDetection(curBuffer);

        textureToEdit.SetPixels(pixArray);
        textureToEdit.Apply();
        renderer.material.mainTexture = textureToEdit;
    }
}