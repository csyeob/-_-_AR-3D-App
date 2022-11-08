using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Post_instance : MonoBehaviour
{

    public Text title;
    public RawImage image;
    public Text text;

    public Text t;
    public RawImage i;
    public Text ti;
    public void upload()
    {
        title = ti;
        image = i;
        text = t;
        SceneManager.LoadScene("Main");
        DontDestroyOnLoad(title);
        DontDestroyOnLoad(image);
        DontDestroyOnLoad(text);

    }
}
