using UnityEngine;
using System;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

public class OpenCvHandDetection
{
    CascadeClassifier handDetector;
    const string fist = "Assets/HaarCascade/fist.xml";
    const string aGest = "Assets/HaarCascade/aGest.xml";
    const string closedFrontalPalm = "Assets/HaarCascade/closedFrontalPalm.xml";
    const string palm = "Assets/HaarCascade/palm.xml";

    private bool handPresent;
    public bool HandPresent
    {
        get
        {
            return HandPresent;
        }
        private set
        {
            handPresent = value;
        }
    }

    public OpenCvHandDetection(string haarCascadeClassifierPath = fist)
    {
        this.HandPresent = false;
        this.handDetector = new CascadeClassifier(haarCascadeClassifierPath);
    }

    public Color[] HandDetectionMarkImage(Mat mat, int widthDivisor = 9, int heightDivisor = 9)
    {
        var biggestHand = HandDetectionGetRect(mat, widthDivisor, heightDivisor);
        mat.Rectangle(biggestHand, 255);
        return OpenCvConversions.ConvertMatToColorArray(mat);
    }

    public OpenCvSharp.CPlusPlus.Rect HandDetectionGetRect(Mat mat, int widthDivisor = 9, int heightDivisor = 9)
    {
        var hands = handDetector.DetectMultiScale(mat, minSize: new Size(mat.Width / widthDivisor, mat.Height / heightDivisor));
        var biggestHand = hands.OrderByDescending(hand => hand.Height * hand.Width).FirstOrDefault();
        return biggestHand;
    }
}