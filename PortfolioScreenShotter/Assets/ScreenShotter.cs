using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotter : MonoBehaviour
{
    public Transform platform;
    public Vector3 rotateSpeed;
    public int screenShotMultiplier = 2;
    int nr;
    
    void Start()
    {
        if(PlayerPrefs.HasKey("ScreenShotNumber")){
            nr = PlayerPrefs.GetInt("ScreenShotNumber");
        }else{
            nr = 0;
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            if(screenShotMultiplier > 0){
                string name = "PortfolioScreenshot" + nr.ToString()+".jpg";
                ScreenCapture.CaptureScreenshot(name,screenShotMultiplier);
                nr ++;
                PlayerPrefs.SetInt("ScreenShotNumber", nr);
                print($"Screenshot created, can be found in the root of the project named : {name}");
            }else{
                Debug.LogWarning("Je screenShotMultiplier staat te laag, maak groter dan 0!!!");
            }
        }

        platform.Rotate(rotateSpeed * Time.deltaTime);
    }
}
