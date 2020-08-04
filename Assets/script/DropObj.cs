using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropObj : MonoBehaviour, IDropHandler
{
    Field fieldScript;
    CardGenerator cgScript;
    GameObject fieldObj;
    GameObject cgObj;
    GameObject handObj;
    public GameObject cardPrefab;

    List<CardData> cardDataList = new List<CardData>(){
        new CardData( "a", 1, "test", "circle"),
        new CardData( "b", 2, "test2", "triangle"),
        new CardData( "c", 3, "test2", "triangle"),
        new CardData( "d", 3, "test3", "star")
    };


       public void OnDrop ( PointerEventData data )
    {
        //Debug.Log("OnDrop");
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll ( data, raycastResults );
        //Debug.Log(raycastResults);
        foreach ( var hit in raycastResults )
        {
            if ( hit.gameObject.CompareTag ( "Field0" ) )
            {             
                ChangeField(0, hit);
                ChangeHand();

                

            } else if ( hit.gameObject.CompareTag ( "Field1" ) )
            {
                ChangeField(1, hit);
                ChangeHand();

            } else if ( hit.gameObject.CompareTag ( "Field2" ) )
            {
                ChangeField(2, hit);
                ChangeHand();

            } else if ( hit.gameObject.CompareTag ( "Field3" ) )
            {
                ChangeField(3, hit);
                ChangeHand();

            }
        }
    }

    void ChangeField(int i, RaycastResult hit){
     //transform.position = hit.gameObject.transform.position;
                
                Card card = hit.gameObject.GetComponent<Card>();
                //fieldにあるカードの情報を取得
                fieldObj = GameObject.Find ("Field");
                fieldScript = fieldObj.GetComponent<Field>();
                List<Card> fieldCardList = fieldScript.cardList;         

                //handにあるカードの情報を取得
                cgObj = GameObject.Find ("CardGenerator");
                cgScript = cgObj.GetComponent<CardGenerator>();
                int cardNum = cgScript.hand_num;

                //handの情報をdrop先のfieldへ格納
                card.Load(cardDataList[cardNum]);
                hit.gameObject.name = cardDataList[cardNum].name;
                fieldCardList[i] = card;
                
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

        /*
        Card card =handObj.GetComponent<Card>();

        int i = Random.Range(0, 4);
        card.Load(cardDataList[i]);
        handObj.name = cardDataList[i].name;
        */
    
	}
}
