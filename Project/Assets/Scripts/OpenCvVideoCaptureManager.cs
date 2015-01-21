using UnityEngine;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System;

public class OpenCvVideoCaptureManager
{
    private VideoCapture VideoCaptureObject { get; set; }
    public Mat Buffer { get; private set; }
    public int Width
    {
        get
        {
            return VideoCaptureObject.FrameWidth;
        }
    }
    public int Height
    {
        get
        {
            return VideoCaptureObject.FrameHeight;
        }
    }
    
    public OpenCvVideoCaptureManager(int index = 0)
    {
        this.VideoCaptureObject = new VideoCapture(index);
        this.Buffer = new Mat();
    }

    public void GetCurrentFrame()
    {
        VideoCaptureObject.Read(Buffer);
    }

    public Color[] GetCurrentFrameAndReturnColorArray()
    {
        VideoCaptureObject.Read(Buffer);
        return OpenCvConversions.ConvertMatToColorArray(Buffer);
    }
}