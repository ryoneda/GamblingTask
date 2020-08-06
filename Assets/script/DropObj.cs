using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropObj : MonoBehaviour, IDropHandler
{
    int cardNum;

    Field fieldScript;
    CardGenerator cgScript;
    GameRule gameRule;
    GameObject fieldObj;
    GameObject cgObj;
    GameObject handObj;
    public GameObject cardPrefab;
    public CardData ansCardData;
    public int droppedField;
    List<CardData> cardDataList;


    void Start(){
        cgObj = GameObject.Find ("CardGenerator");
        cgScript = cgObj.GetComponent<CardGenerator>();
        cardDataList = cgScript.cardDataList;
	}


    public void OnDrop ( PointerEventData data )
    {
        
        gameRule = GameObject.Find ("Rule").GetComponent<GameRule>();

        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll ( data, raycastResults );

        foreach ( var hit in raycastResults )
        {
            if ( hit.gameObject.CompareTag ( "Field0" ) )
            {             
                ChangeField(0, hit);
                ChangeHand();
                Rule(gameRule, 0);
                

            } else if ( hit.gameObject.CompareTag ( "Field1" ) )
            {
                ChangeField(1, hit);
                ChangeHand();
                Rule(gameRule, 1);
                

            } else if ( hit.gameObject.CompareTag ( "Field2" ) )
            {
                ChangeField(2, hit);
                ChangeHand();
                Rule(gameRule, 2);
                

            } else if ( hit.gameObject.CompareTag ( "Field3" ) )
            {
                ChangeField(3, hit);
                ChangeHand();
                Rule(gameRule, 3);
                

            }
        }
    }

    void ChangeField(int i, RaycastResult hit){
                
        //fieldにあるカードの情報を取得
        fieldObj = GameObject.Find ("Field");
        fieldScript = fieldObj.GetComponent<Field>();
        List<Card> fieldCardList = fieldScript.cardList;         

        //handにあるカードの情報を取得
        cgObj = GameObject.Find ("CardGenerator");
        cgScript = cgObj.GetComponent<CardGenerator>();
        cardNum = cgScript.hand_num;

        //handの情報をdrop先のfieldへ格納
        Card card = hit.gameObject.GetComponent<Card>();
        card.Load(cardDataList[cardNum]);
        hit.gameObject.name = cardDataList[cardNum].name;
        fieldCardList[i] = card;
        
        //handの情報を答えに
        ansCardData = cardDataList[cardNum];
        droppedField = i;
	}

    void ChangeHand(){

        cgObj = GameObject.Find ("CardGenerator");
        //Card card = cgObj.GetComponent<Card>();
        cgScript = cgObj.GetComponent<CardGenerator>();
        string handName = cgScript.hand_name;
        handObj = GameObject.FindGameObjectWithTag("hand");
        Debug.Log("handObj: "+handObj);
        Destroy(handObj);

        cgScript.Start();
	}

    void Rule(GameRule gameRule, int i){
        gameRule.fieldNum = i;
        gameRule.ansNumber = cardDataList[cardNum].number;
        gameRule.ansColor = cardDataList[cardNum].color;
        gameRule.ansShape = cardDataList[cardNum].shape;
        gameRule.MainRule();
	}
}
