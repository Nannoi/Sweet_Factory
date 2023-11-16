using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class CameraDetect : MonoBehaviour
{
    [SerializeField] private FlipMode imageFlip;
    [SerializeField] private bool shouldFlipImage = true;
    [SerializeField] private float Threshold = 180f;
    [SerializeField] private bool ShowProcessingImage = true;
    [SerializeField] private float CurveAccuracy = 10f;
    [SerializeField] private float MinArea = 5000f;
    [SerializeField] private PolygonCollider2D PolygonCollider;

    WebCamTexture WebCam;
    Texture2D texture;
    private Point[][] contours;
    private HierarchyIndex[] hierachy;
    private Vector2[] vectorList;
    public Scalar upperCol;
    public Scalar lowerCol;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCam = new WebCamTexture(devices[1].name);

        // Set the desired resolution
        WebCam.requestedWidth = 1280;  // Set to your desired width
        WebCam.requestedHeight = 720;  // Set to your desired height

        WebCam.Play();

        lowerCol = new Scalar(0, 0, 0);  // Adjust these values based on your specific case
        upperCol = new Scalar(0, 0, 0);

        texture = new Texture2D(WebCam.width, WebCam.height, TextureFormat.RGBA32, false);
    }

    void Update()
    {
        GetComponent<Renderer>().material.mainTexture = WebCam;
        ThresholdCommand();
    }

   public void ThresholdCommand()
{
    Mat image = OpenCvSharp.Unity.TextureToMat(WebCam);
    if (shouldFlipImage)
    {
        Cv2.Flip(image, image, (FlipMode)imageFlip);
    }

    // Convert BGR image to HSV
    Mat hsv = new Mat();
    Cv2.CvtColor(image, hsv, ColorConversionCodes.BGR2HSV);

        // Define a range for blue color in HSV
        


        // Threshold the image to get a binary mask of the skin color
        Mat skinMask = new Mat();
    Cv2.InRange(hsv, lowerCol, upperCol, skinMask);

    // Find contours in the skin mask
    Cv2.FindContours(skinMask, out contours, out hierachy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, null);

    PolygonCollider.pathCount = 0;

    foreach (Point[] contour in contours)
    {
        Point[] points = Cv2.ApproxPolyDP(contour, CurveAccuracy, true);
        var area = Cv2.ContourArea(contour);
        if (area > MinArea)
        {
            DrawContour(image, new Scalar(127, 127, 127), 2, points);

            PolygonCollider.pathCount++;
            PolygonCollider.SetPath(PolygonCollider.pathCount - 1, toVector2(points));
        }
    }

    if (ShowProcessingImage)
    {
        OpenCvSharp.Unity.MatToTexture(image, texture);
        GetComponent<Renderer>().material.mainTexture = texture;
    }
}


    private Vector2[] toVector2(Point[] points)
    {
        vectorList = new Vector2[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            vectorList[i] = new Vector2(points[i].X, points[i].Y);
        }
        return vectorList;
    }

    private void DrawContour(Mat Image, Scalar Color, int Thickness, Point[] Points)
    {
        for (int i = 1; i < Points.Length; i++)
        {
            Cv2.Line(Image, Points[i - 1], Points[i], Color, Thickness);
        }
        Cv2.Line(Image, Points[Points.Length - 1], Points[0], Color, Thickness);
    }

}