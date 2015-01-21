using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class WebCam : MonoBehaviour
{
    OpenCvController cvController;
    OpenCvVideoCaptureManager cvVideoCapture;
    Texture2D textureToEdit;

    void Start()
    {
        cvController = new OpenCvController();
        cvVideoCapture = new OpenCvVideoCaptureManager();
        textureToEdit = new Texture2D(cvVideoCapture.Width, cvVideoCapture.Height);
    }

    void Update()
    {
        var pixArray = cvVideoCapture.GetCurrentFrameAndReturnColorArray();

        //cvVideoCapture.GetCurrentFrame();


        //var buffer = cvVideoCapture.Buffer;

        //print("test");
        //print(buffer.Get<Vec3b>(0, 0).Item0);

        //var tempBuffer = cvVideoCapture.Buffer;
        //print("Hello World");
        //print(tempBuffer.Get<Color>(0, 0).r);
        //print(pixArray[0].r);
        //print(tempBuffer.Get<Color>(0, 0).g);
        //print(pixArray[0].g);
        //print(tempBuffer.Get<Color>(0, 0).b);
        //print(pixArray[0].b);
        //print(tempBuffer.Get<>(0,0));




        textureToEdit.SetPixels(pixArray);
        textureToEdit.Apply();





        renderer.material.mainTexture = textureToEdit;
    }
}