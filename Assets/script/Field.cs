using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject cardPrefab;
    public List<Card> cardList = new List<Card>();
    List<CardData> cardDataList = new List<CardData>(){
        new CardData( "RC1", 1, "red", "circle"),
        new CardData( "BR2", 2, "blue", "rect"),
        new CardData( "GT3", 3, "green", "tri"),
        new CardData( "YCr4", 4, "yellow", "cross"),
        new CardData( "test", 0, "a", "b")
    };
    
    void Start(){
     for(int i=0; i<8; i++){

            if(i<4){
                GameObject cardObj = Instantiate(cardPrefab);
                Card card = cardObj.GetComponent<Card>();
                cardObj.name = cardDataList[i].name;
                cardObj.AddComponent<DropObj>();
                card.Load(cardDataList[i]);
                this.Add(card);     
			} else if(4<=i){

                GameObject cardObj = Instantiate(cardPrefab);
                Card card = cardObj.GetComponent<Card>();
                cardObj.tag = "Field"+(i-4);
                cardObj.name = cardDataList[4].name;
                cardObj.AddComponent<DropObj>();
                card.Load(cardDataList[4]);
                this.Add(card);
			}
            
		}      
    }
    void Add(Card _card){
     _card.transform.SetParent(this.transform);
     cardList.Add(_card);
	}
    void Update(){
    
	}
}
