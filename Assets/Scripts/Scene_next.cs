using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_next : MonoBehaviour
{
 
   public void scene_next(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
