using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {
    public GameObject cardPrefab;
    public GameObject Hand;
    // Use this for initialization 
    public List<CardData> cardDataList = new List<CardData>(){
        new CardData( "a", 1, "test", "circle"),
        new CardData( "b", 2, "test2", "triangle"),
        new CardData( "c", 3, "test2", "triangle"),
        new CardData( "d", 3, "test3", "star")

    };
    
    void Start () {
        int i = Random.Range(0, 4);
        GameObject cardObj = Instantiate(cardPrefab);
        cardObj.name = cardDataList[i].name;
        cardObj.transform.SetParent(Hand.transform);

        Card card = cardObj.GetComponent<Card>();
        card.Load(cardDataList[i]);
        cardObj.AddComponent<DragObj>();

    }

}