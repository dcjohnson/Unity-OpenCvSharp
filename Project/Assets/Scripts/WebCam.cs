using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class WebCam : MonoBehaviour
{
    OpenCvHandDetection cvHandDetectionFist;
    OpenCvHandDetection cvHandOpenPalm;
    OpenCvVideoCaptureManager cvVideoCapture;
    Texture2D textureToEdit;

    void Start()
    {
        cvVideoCapture = new OpenCvVideoCaptureManager();
        textureToEdit = new Texture2D(cvVideoCapture.Width, cvVideoCapture.Height);
        cvHandDetectionFist = new OpenCvHandDetection();
        cvHandOpenPalm = new OpenCvHandDetection(OpenCvHandDetection.palm);
    }

    void Update()
    {
        var curBuffer = cvVideoCapture.ReadAndGetCurrentBuffer();

        cvHandOpenPalm.HandDetection(curBuffer);
        cvHandDetectionFist.HandDetection(curBuffer);
        var pixArray = cvHandDetectionFist.HandPresent ? cvHandDetectionFist.MarkImageWithRect(curBuffer) : cvHandOpenPalm.MarkImageWithRect(curBuffer);

        textureToEdit.SetPixels(pixArray);
        textureToEdit.Apply();
        renderer.material.mainTexture = textureToEdit;
    }
}