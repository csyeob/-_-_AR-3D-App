using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Item1", menuName = "AddItem/Item")]
public class Item : ScriptableObject
{
    // 스크립팅이 가능한 오브젝트로 만들 것이므로 scriptableobject로 상속
    public float price;
    public GameObject itemPrefab;
    public Sprite itemImage;
    
}
