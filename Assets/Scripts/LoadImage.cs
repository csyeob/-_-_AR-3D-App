using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadImage : MonoBehaviour
{
    public RawImage image;
    public void onclickimageLoad()
    {
        NativeGallery.GetImageFromGallery((file) => {

            // 갤러리를 여는 함수
            FileInfo selected = new FileInfo(file);
            //용량제한
            if (selected.Length > 50000000)
            {
                return;
            }

            //불러오기
            if (!string.IsNullOrEmpty(file))
            {
                //불러와라.
                StartCoroutine(loadImage(file));
            }

        });
    }

    IEnumerator loadImage(string path)
    {
        yield return null;
        byte[] fileData  = File.ReadAllBytes(path);
        string filename = Path.GetFileName(path).Split('.')[0];
        string savePath = Application.persistentDataPath + "/Image";
        //경로를 확인하고 싶으면 Debug.log()안에 path 넣어보셈
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
        File.WriteAllBytes(savePath + filename + ".png", fileData);
        var temp = File.ReadAllBytes(savePath + filename + ".png");
        Texture2D tex = new Texture2D(0, 0);
        //temp가 byte파일이기때문에 img texture에 삽입 불가 따라서 texture 형식으로 변환해야함
        tex.LoadImage(temp);

        image.texture = tex;
        image.SetNativeSize();
        ImageSizeSetting(image, 420, 669);
    }

    void ImageSizeSetting(RawImage img, float x, float y)
    {
        var imgX = img.rectTransform.sizeDelta.x;
        var imgY = img.rectTransform.sizeDelta.y;

        if(x / y > imgX / imgY) //이미지 세로가 더 길때
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imgX * (y / imgY));
        }
        else //가로가 더 길때
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, imgY * (x / imgX));
        }
    }

    
}