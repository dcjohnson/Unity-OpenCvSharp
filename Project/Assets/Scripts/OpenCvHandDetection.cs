using UnityEngine;
using System;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

public class OpenCvHandDetection
{
    CascadeClassifier handDetector;
    static const string[] haarCascades = new string[]{"Assets/HaarCascade/fist.xml"};

    public OpenCvHandDetection(string haarCascadeClassifierPath = "Assets/HaarCascade/fist.xml")
    {
        this.handDetector = new CascadeClassifier(haarCascadeClassifierPath);
    }

    public Color[] HandDetection(Mat mat)
    {
        var hands = handDetector.DetectMultiScale(mat);
        
        foreach(var hand in hands)
        {
            mat.Rectangle(hand,255);
        }
        
        //if (hands.Length != 0)
        //{
        //    mat.Rectangle(AverageRectPoints(hands), 255);
        //}
        return OpenCvConversions.ConvertMatToColorArray(mat);
    }

    public OpenCvSharp.CPlusPlus.Rect AverageRectPoints(OpenCvSharp.CPlusPlus.Rect[] rects)
    {
        int x = 0;
        int y = 0;
        int height = 0;
        int width = 0;

        foreach(var rect in rects)
        {
            x += rect.X;
            y += rect.Y;
            height += rect.Height;
            width += rect.Width;
        }

        x /= rects.Length;
        y /= rects.Length;
        height /= rects.Length;
        width /= rects.Length;

        var averageRect = new OpenCvSharp.CPlusPlus.Rect(new Point(x, y), new Size(width, height));

        return averageRect;
    }
}