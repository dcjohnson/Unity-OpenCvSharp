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

    public OpenCvHandDetection(string haarCascadeClassifierPath = palm)
    {
        this.handDetector = new CascadeClassifier(haarCascadeClassifierPath);
    }

    public Color[] HandDetection(Mat mat)
    {
        var hands = handDetector.DetectMultiScale(mat);
        var biggestHand = hands.OrderByDescending(hand => hand.Height * hand.Width).FirstOrDefault(); // Somewhat rough but I will improve it soon.
        mat.Rectangle(biggestHand, 255);
        return OpenCvConversions.ConvertMatToColorArray(mat);
    }
}