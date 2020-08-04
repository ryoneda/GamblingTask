using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    int ansType;
    int correct;
    public DropObj dropObj;

    List<CardData> displayCardList = new List<CardData>(){
        new CardData( "a", 1, "test", "circle"),
        new CardData( "b", 2, "test2", "triangle"),
        new CardData( "c", 3, "test2", "triangle"),
        new CardData( "d", 3, "test3", "star")

    };

    void Start(){
        ansType = Random.Range(1, 4);
    }

    void MainRule(){
        
        if(ansType==1){

          int fieldNum = dropObj.droppedField;
          Debug.Log("droppedField is " + fieldNum);

		} else if(ansType==2){
        
		} else if(ansType==3){
        
		}
    }

    
}
