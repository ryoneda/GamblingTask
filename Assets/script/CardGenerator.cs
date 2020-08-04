using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {
    public GameObject cardPrefab;
    public GameObject Hand;
    public int hand_num;
    public string hand_name;
    // Use this for initialization 
    List<CardData> cardDataList = new List<CardData>(){
        new CardData( "a", 1, "test", "circle"),
        new CardData( "b", 2, "test2", "triangle"),
        new CardData( "c", 3, "test2", "triangle"),
        new CardData( "d", 3, "test3", "star")

    };
    
    public void Start () {
        int i = Random.Range(0, 4);
        hand_num = i;
        GameObject cardObj = Instantiate(cardPrefab);
        cardObj.name = cardDataList[i].name;
        hand_name = cardDataList[i].name;
        cardObj.transform.SetParent(Hand.transform);

        Card card = cardObj.GetComponent<Card>();
        card.Load(cardDataList[i]);
        cardObj.AddComponent<DragObj>();
        cardObj.tag = "hand";


    }
}