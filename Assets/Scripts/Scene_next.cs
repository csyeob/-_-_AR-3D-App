using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class Scene_next : MonoBehaviour
{
 
   public void scene_next(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void VR_next(string scene)
    {
        SceneManager.LoadScene(scene);
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
