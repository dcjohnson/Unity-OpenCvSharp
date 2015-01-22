using UnityEngine;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

public static class OpenCvHandDetection
{
    //I will get to this later.
    public static Color[] HandDetection(Mat mat)
    {
        var greyBuffer = OpenCvConversions.GetGrayScale(mat);
        var blurredGreyBuffer = OpenCvConversions.BlurMat(greyBuffer);
        var thresholdedBuffer = OpenCvConversions.ThreshHoldMat(blurredGreyBuffer);

        return OpenCvConversions.ConvertMatToColorArray(blurredGreyBuffer);
    }
}