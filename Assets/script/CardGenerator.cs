using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {
    public GameObject cardPrefab;
    public GameObject Hand;
    public int hand_num;
    public string hand_name;
    // Use this for initialization 
    public List<CardData> cardDataList = new List<CardData>(){
        new CardData( "BC1", 1, "blue", "circle"),
        new CardData( "BC2", 2, "blue", "circle"),
        new CardData( "BC3", 3, "blue", "circle"),
        new CardData( "BC4", 4, "blue", "circle"),
        new CardData( "BR1", 1, "blue", "rect"),
        new CardData( "BR2", 2, "blue", "rect"),
        new CardData( "BR3", 3, "blue", "rect"),
        new CardData( "BR4", 4, "blue", "rect"),
        new CardData( "BT1", 1, "blue", "tri"),
        new CardData( "BT2", 2, "blue", "tri"),
        new CardData( "BT3", 3, "blue", "tri"),
        new CardData( "BT4", 4, "blue", "tri"),
        new CardData( "BCr1", 1, "blue", "cross"),
        new CardData( "BCr2", 2, "blue", "cross"),
        new CardData( "BCr3", 3, "blue", "cross"),
        new CardData( "BCr4", 4, "blue", "cross"),
        new CardData( "RC1", 1, "red", "circle"),
        new CardData( "RC2", 2, "red", "circle"),
        new CardData( "RC3", 3, "red", "circle"),
        new CardData( "RC4", 4, "red", "circle"),
        new CardData( "RR1", 1, "red", "rect"),
        new CardData( "RR2", 2, "red", "rect"),
        new CardData( "RR3", 3, "red", "rect"),
        new CardData( "RR4", 4, "red", "rect"),
        new CardData( "RT1", 1, "red", "tri"),
        new CardData( "RT2", 2, "red", "tri"),
        new CardData( "RT3", 3, "red", "tri"),
        new CardData( "RT4", 4, "red", "tri"),
        new CardData( "RCr1", 1, "red", "cross"),
        new CardData( "RCr2", 2, "red", "cross"),
        new CardData( "RCr3", 3, "red", "cross"),
        new CardData( "RCr4", 4, "red", "cross"),
        new CardData( "GC1", 1, "green", "circle"),
        new CardData( "GC2", 2, "green", "circle"),
        new CardData( "GC3", 3, "green", "circle"),
        new CardData( "GC4", 4, "green", "circle"),
        new CardData( "GR1", 1, "green", "rect"),
        new CardData( "GR2", 2, "green", "rect"),
        new CardData( "GR3", 3, "green", "rect"),
        new CardData( "GR4", 4, "green", "rect"),
        new CardData( "GT1", 1, "green", "tri"),
        new CardData( "GT2", 2, "green", "tri"),
        new CardData( "GT3", 3, "green", "tri"),
        new CardData( "GT4", 4, "green", "tri"),
        new CardData( "GCr1", 1, "green", "cross"),
        new CardData( "GCr2", 2, "green", "cross"),
        new CardData( "GCr3", 3, "green", "cross"),
        new CardData( "GCr4", 4, "green", "cross"),
        new CardData( "YC1", 1, "yellow", "circle"),
        new CardData( "YC2", 2, "yellow", "circle"),
        new CardData( "YC3", 3, "yellow", "circle"),
        new CardData( "YC4", 4, "yellow", "circle"),
        new CardData( "YR1", 1, "yellow", "rect"),
        new CardData( "YR2", 2, "yellow", "rect"),
        new CardData( "YR3", 3, "yellow", "rect"),
        new CardData( "YR4", 4, "yellow", "rect"),
        new CardData( "YT1", 1, "yellow", "tri"),
        new CardData( "YT2", 2, "yellow", "tri"),
        new CardData( "YT3", 3, "yellow", "tri"),
        new CardData( "YT4", 4, "yellow", "tri"),
        new CardData( "YCr1", 1, "yellow", "cross"),
        new CardData( "YCr2", 2, "yellow", "cross"),
        new CardData( "YCr3", 3, "yellow", "cross"),
        new CardData( "YCr4", 4, "yellow", "cross")
    };
    
    public void Start () {
        int i = Random.Range(0, 64);
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