using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Post_get : MonoBehaviour
{
    public Text id;
    public RawImage image;
    public Text text;
    public Text title;

    Post_instance set_post;

    void Start()
    {
        title.text = set_post.title.text;
        text.text = set_post.text.text;
        image.texture = set_post.image.texture;
    }

}
