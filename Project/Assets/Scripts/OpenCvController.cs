using UnityEngine;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

public class OpenCvController
{
    public Color[] HandDetection(Color[] colorArray, int width, int heigth)
    {
        var mat = OpenCvConversions.ConvertColorArrayToMat(colorArray, width, heigth);
        var newColorArray = OpenCvConversions.ConvertMatToColorArray(mat);
        return newColorArray;
    }
}