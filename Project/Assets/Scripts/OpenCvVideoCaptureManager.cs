using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System;

public class OpenCvVideoCaptureManager
{
    private VideoCapture VideoCaptureObject;
    private Mat buffer;

    public Mat Buffer
    {
        get
        {
            return buffer;
        }
        private set
        {
            buffer = value;
        }
    }
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

    public void ReadCurrentFrame()
    {
        VideoCaptureObject.Read(Buffer);
    }

    public Mat ReadAndGetCurrentBuffer()
    {
        ReadCurrentFrame();
        return Buffer;
    }
}