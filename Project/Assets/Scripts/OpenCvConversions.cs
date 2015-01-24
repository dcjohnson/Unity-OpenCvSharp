using UnityEngine;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

public static class OpenCvConversions
{
    public static Color[] ConvertMatToColorArray(Mat mat)
    {
        var mat3b = new MatOfByte3(mat);
        var indexer = mat3b.GetIndexer();
        var width = mat.Width;
        var heigth = mat.Height;
        var colorArray = new Color[width * heigth];
        for (var y = 0; y < heigth; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var newColor = new Color();
                newColor.r = indexer[y, x].Item2 / 255.0f;
                newColor.g = indexer[y, x].Item1 / 255.0f;
                newColor.b = indexer[y, x].Item0 / 255.0f;
                colorArray[y * width + x] = newColor;
            }
        }
        return colorArray;
    }
}