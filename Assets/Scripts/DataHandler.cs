using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHandler : MonoBehaviour
{
    private GameObject furniture;
    // 가구를 저장하는 변수
    // 클래스 인스턴스를 생성할 것임.

    [SerializeField]private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> items;
    [SerializeField] private Button btn1;
    [SerializeField] private Button btn2;
    // 버튼에 대한 정보를 담고 있는 버튼메니저와 그 버튼들을 포함을 버튼컨테이너
    private int current_id = 0;

    private static DataHandler instance;
    // 데이터 인스턴스들을 다른 스크립트들에 반환하여 사용함.
    public static DataHandler Instance
    {
        get
        {
           if (instance == null)
            {
                //null이면 인스턴스를 생성
                //같은 유형의 타입을 찾고 datahandler클래스를 찾으면 여기에 해당 인스턴스를 전달함.
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
            // null이 아니면 instance를 반환
        }
    }
    
    public void Start()
    {
       LoadCategoryItems("default");
        btn1.onClick.AddListener(() => LoadCategoryItems("bed_item"));
        btn2.onClick.AddListener(() => LoadCategoryItems("sofa_item"));
    }

    public void LoadItems(string furniture)
    {
        var items_obj = Resources.LoadAll(furniture, typeof(Item));
        foreach(var item in items_obj)
        {
            items.Add(item as Item);
        }
        CreateButton();
        
    }
    public void LoadCategoryItems(string furniture)
    {
        current_id = 0;
        DestroyButton();
        items.Clear();
        var items_obj = Resources.LoadAll(furniture, typeof(Item));
        foreach (var item in items_obj)
        {
            items.Add(item as Item);
        }
        CreateButton();
    }
    public void CreateButton()
    {
        
        foreach (Item i in items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
            // rawimage 애들이 다 버튼화로 하기 위함.
            b.ItemId = current_id;
            b.ButtonTexture = i.itemImage;
            current_id++;
        }
    }
    public void DestroyButton()
    {
        foreach(Transform child in buttonContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void SetFurniture(int id)
    {
        // 목록에 있는 숫자를 버튼메니저에 넘겨줌.
        furniture = items[id].itemPrefab;

    }
    public GameObject GetFurniture()
    {
        return furniture;
    }
}
