using UnityEngine;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System.Linq;

public static class OpenCvHandDetection
{

    //I will get to this later.
    public static Color[] HandDetection(Mat mat)
    {
        Mat dst = new Mat();
        mat.CopyTo(dst);


        Cv2.CvtColor(mat, dst, ColorConversion.RgbToGray);
        Cv2.GaussianBlur(dst, dst, new Size(11, 11), 0);
        ThreshHoldMat(dst, dst);
        Mat[] contours;
        OutputArray contourData = OutputArray.Create(new Mat());
        dst.FindContours(out contours, contourData, ContourRetrieval.FloodFill, ContourChain.ApproxNone);





        int max = 0;
        for (var index = 0; index < contours.Length; index++)
        {
            if (Cv2.ContourArea(contours[index]) > Cv2.ContourArea(contours[max]))
            {
                max = index;
            }
        }

        //mat.DrawContours(mat, contours, -1, 255);

        //var convexContours = from contour in contours
        //                     where Cv2.IsContourConvex(contour)
        //                     select contour;
        //mat.DrawContours(mat, convexContours, -1, 255);

        mat.DrawContours(mat, new[] { contours[max] }, -1, 255);
        return OpenCvConversions.ConvertMatToColorArray(mat);
    }


    public static void ThreshHoldMat(Mat src, Mat dst)
    {
        //Cv2.Threshold(src, dst, 80, 255, ThresholdType.Otsu);
        Cv2.Threshold(src, dst, 95, 255, ThresholdType.BinaryInv);
    }
}