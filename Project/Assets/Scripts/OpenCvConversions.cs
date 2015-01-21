using UnityEngine;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

public class OpenCvConversions
{
    public static Mat ConvertColorArrayToMat(Color[] colorArray, int width, int heigth)
    {
        var img = new Mat(heigth, width, MatType.CV_8UC4);

        for (var y = 0; y < heigth; y++)
        {
            for (var x = 0; x < width; x++)
            {
                img.Set<Color>(y, x, colorArray[y * width + x]);
            }
        }

        return img;
    }

    public static Color[] ConvertMatToColorArray(Mat mat)
    {
        var colorArray = new Color[mat.Width * mat.Height];
        var width = mat.Width;
        var heigth = mat.Height;
        for (var y = 0; y < heigth; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var newColor = new Color();
                newColor.r = mat.Get<Vec3b>(y, x).Item2 / 255.0f;
                newColor.g = mat.Get<Vec3b>(y, x).Item1 / 255.0f;
                newColor.b = mat.Get<Vec3b>(y, x).Item0 / 255.0f;
                colorArray[y * width + x] = newColor;
            }
        }
        return colorArray;
    }
}