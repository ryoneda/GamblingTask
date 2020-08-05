using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    int ansType;
    int correct;
    public int fieldNum;
    public int ansNumber;
    public string ansColor;
    public string ansShape;
    public DropObj dropObj;

    TextFeedback textFeedback;

    List<CardData> displayCardList = new List<CardData>(){
        new CardData( "a", 1, "test", "circle"),
        new CardData( "b", 2, "test2", "triangle"),
        new CardData( "c", 3, "test2", "triangle"),
        new CardData( "d", 3, "test3", "star")

    };

    void Start(){
        ansType = Random.Range(1, 4);
        ansType=1;
    }

    public void MainRule(){
        
        if(ansType==1){
            
            if(fieldNum==0){

                AnsCheckNum(fieldNum, ansNumber);
            
			} else if(fieldNum==1){

                AnsCheckNum(fieldNum, ansNumber);
            
			} else if(fieldNum==2){

                AnsCheckNum(fieldNum, ansNumber);
            
			} else if(fieldNum==3){

                AnsCheckNum(fieldNum, ansNumber);     
			}
		} else if(ansType==2){

            if(fieldNum==0){

                AnsCheckColor(fieldNum, ansColor);
            
			} else if(fieldNum==1){

                AnsCheckColor(fieldNum, ansColor);
            
			} else if(fieldNum==2){

                AnsCheckColor(fieldNum, ansColor);
            
			} else if(fieldNum==3){

                AnsCheckColor(fieldNum, ansColor);   
			}
        
		} else if(ansType==3){

            if(fieldNum==0){

                AnsCheckShape(fieldNum, ansShape);
            
			} else if(fieldNum==1){

                AnsCheckShape(fieldNum, ansShape);
            
			} else if(fieldNum==2){

                AnsCheckShape(fieldNum, ansShape);
            
			} else if(fieldNum==3){

                AnsCheckShape(fieldNum, ansShape);
			}
        }
    }

    void AnsCheckNum(int i, int ans){

        textFeedback = GameObject.Find ("Text").GetComponent<TextFeedback>();

        if(displayCardList[i].number == ans){
            textFeedback.feedback="正解";
            Debug.Log("正解");
		} else {
            textFeedback.feedback="はずれ";
            Debug.Log("はずれ");
	    }
	}

    void AnsCheckColor(int i, string ans){
        if(displayCardList[i].color == ans){
            textFeedback.feedback="正解";
            Debug.Log("正解");
		} else {
            textFeedback.feedback="はずれ";
            Debug.Log("はずれ");
	    }
	}
    
    void AnsCheckShape(int i, string ans){
        if(displayCardList[i].shape == ans){
            textFeedback.feedback="正解";
            Debug.Log("正解");
		} else {
            textFeedback.feedback="はずれ";
            Debug.Log("はずれ");
	    }
	}

}
