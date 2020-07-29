using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject cardPrefab;
    public List<Card> cardList = new List<Card>();
    List<CardData> cardDataList = new List<CardData>(){
        new CardData( "a", 1, "test", "circle"),
        new CardData( "b", 2, "test2", "triangle"),
        new CardData( "c", 3, "test2", "triangle"),
        new CardData( "d", 3, "test3", "star")

    };
    
    void Start(){
        for(int i=0; i<4; i++){
            GameObject cardObj = Instantiate(cardPrefab);
            Card card = cardObj.GetComponent<Card>();
            cardObj.tag = "DroppableField";
            cardObj.name = cardDataList[i].name;
            cardObj.AddComponent<DropObj>();
            card.Load(cardDataList[i]);
            this.Add(card);
            Debug.Log ("cardList " + cardList);
		}   
    }
    void Add(Card _card){
     _card.transform.SetParent(this.transform);
     cardList.Add(_card);
	}
}
