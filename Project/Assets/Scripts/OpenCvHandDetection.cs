using UnityEngine;
using System;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

public class OpenCvHandDetection : MonoBehaviour
{
    CascadeClassifier handDetector;
    public const string fist = "Assets/HaarCascade/fist.xml";
    public const string aGest = "Assets/HaarCascade/aGest.xml";
    public const string closedFrontalPalm = "Assets/HaarCascade/closedFrontalPalm.xml";
    public const string palm = "Assets/HaarCascade/palm.xml";

    private bool handPresent;
    public bool HandPresent
    {
        get
        {
            return handPresent;
        }
        private set
        {
            handPresent = value;
        }
    }
    private OpenCvSharp.CPlusPlus.Rect[] detectionRects;
    public OpenCvSharp.CPlusPlus.Rect[] DetectionRects
    {
        get
        {
            return detectionRects;
        }
        private set
        {
            detectionRects = value;
        }
    }

    public OpenCvHandDetection(string haarCascadeClassifierPath = fist)
    {
        this.HandPresent = false;
        this.handDetector = new CascadeClassifier(haarCascadeClassifierPath);
    }

    public Color[] HandDetectionMarkImage(Mat mat, int widthDivisor = 9, int heightDivisor = 9)
    {
        HandDetection(mat, widthDivisor, heightDivisor);
        return MarkImageWithRect(mat);
    }

    public void HandDetection(Mat mat, int widthDivisor = 9, int heightDivisor = 9)
    {
        DetectionRects = handDetector.DetectMultiScale(mat, minSize: new Size(mat.Width / widthDivisor, mat.Height / heightDivisor));
        HandPresent = DetectionRects.FirstOrDefault() == new OpenCvSharp.CPlusPlus.Rect() ? false : true;
    }

    public Color[] MarkImageWithRect(Mat mat)
    {
        if(!HandPresent)
        {
            return OpenCvConversions.ConvertMatToColorArray(mat);
        }
        var biggestHand = DetectionRects.OrderByDescending(hand => hand.Height * hand.Width).FirstOrDefault();
        mat.Rectangle(biggestHand, 255);
        return OpenCvConversions.ConvertMatToColorArray(mat);
    }
}