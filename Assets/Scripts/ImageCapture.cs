using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ImageCapture
{
    UnityEngine.Windows.WebCam.PhotoCapture photoCaptureObject = null;
    // Creates PhotoCapture object
    public static string fileName;
    void Start()
    {
        UnityEngine.Windows.WebCam.PhotoCapture.CreateAsync(false, OnPhotoCaptureCreated);
    }

    //Stores object, sets parameters, and starts Photo Mode
    void OnPhotoCaptureCreated(UnityEngine.Windows.WebCam.PhotoCapture captureObject)
    {
        photoCaptureObject = captureObject;

        Resolution cameraResolution = UnityEngine.Windows.WebCam.PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();

        UnityEngine.Windows.WebCam.CameraParameters c = new UnityEngine.Windows.WebCam.CameraParameters();
        c.hologramOpacity = 0.0f;
        c.cameraResolutionWidth = cameraResolution.width;
        c.cameraResolutionHeight = cameraResolution.height;
        c.pixelFormat = UnityEngine.Windows.WebCam.CapturePixelFormat.BGRA32;

        captureObject.StartPhotoModeAsync(c, OnPhotoModeStarted);
    }



    //Takes a photo and stores it to disk
    void OnPhotoModeStarted(UnityEngine.Windows.WebCam.PhotoCapture.PhotoCaptureResult result)  //Changed from private to nothing
    {
        if (result.success)
        {
            fileName = string.Format(@"CapturedImage{0}_n.jpg", Time.time);
            string filePath = System.IO.Path.Combine(Application.persistentDataPath, fileName);

            photoCaptureObject.TakePhotoAsync(filePath, UnityEngine.Windows.WebCam.PhotoCaptureFileOutputFormat.JPG, OnCapturedPhotoToDisk);
        }
        else
        {
            Debug.LogError("Unable to start photo mode!");
        }
    }

    //After capturing the photo to disk, exit photo mode and clens up objects
    void OnCapturedPhotoToDisk(UnityEngine.Windows.WebCam.PhotoCapture.PhotoCaptureResult result)
    {
        if (result.success)
        {
            Debug.Log("Saved Photo to disk!");
            photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
        }
        else
        {
            Debug.Log("Failed to save Photo to disk");
        }
    }

    //Clean up code
    void OnStoppedPhotoMode(UnityEngine.Windows.WebCam.PhotoCapture.PhotoCaptureResult result)
    {
        photoCaptureObject.Dispose();
        photoCaptureObject = null;
    }

}
