using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ButtonManager : MonoBehaviour
{
    //특정 가구를 선택하는 스크립트 
    private Button btn;
    [SerializeField]private RawImage buttonImage;

    //public GameObject furniture;
    
    private int itemId;
    private Sprite _buttonTexture;
    public Sprite ButtonTexture {
        set
        {
            _buttonTexture = value;
            buttonImage.texture = _buttonTexture.texture;
        }
    }

    public int ItemId
    {
        set{itemId = value;}
    }

    void Start()
    {
        btn = GetComponent<Button>();
        //버튼의 컴포넌트들을 가져옴 안드로이드 버튼 선언이라고 생각하면됨.
        btn.onClick.AddListener(SelectObject);
    }

   
    void Update()
    {
        if (UIManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 2, 0.4f);
            // 0.2f가 작을수록 애니메이션이 빨라짐 DG Tweening으로 세련된 애니메이션을 줄 수 있음.
            //transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.DOScale(Vector3.one, 0.4f);
            //transform.localScale = Vector3.one;
        }
    }

    void SelectObject()
    {
       DataHandler.Instance.SetFurniture(itemId);
    }
}
