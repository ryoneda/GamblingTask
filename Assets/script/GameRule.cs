using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    int ansType;
    int totalCorrects;
    int totalErrors;
    public int fieldNum;
    public int ansNumber;
    public string ansColor;
    public string ansShape;
    public DropObj dropObj;

    int continuous;
    int totalCategory;

    TextFeedback textFeedback;

    List<CardData> displayCardList = new List<CardData>(){
        new CardData( "RC1", 1, "red", "circle"),
        new CardData( "BR2", 2, "blue", "rect"),
        new CardData( "GT3", 3, "green", "tri"),
        new CardData( "YCr4", 4, "yellow", "cross")

    };

    void Start(){
        ansType = Random.Range(1, 4);
    }

    public void MainRule(){
    
        if(continuous==5){
            CategoryChange();  
		}
        
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
            continuous++;
		} else {
            textFeedback.feedback="はずれ";
            Debug.Log("はずれ");
            continuous = 0;
	    }
	}

    void AnsCheckColor(int i, string ans){

        textFeedback = GameObject.Find ("Text").GetComponent<TextFeedback>();

        if(displayCardList[i].color == ans){
            textFeedback.feedback="正解";
            Debug.Log("正解");
            continuous++;
		} else {
            textFeedback.feedback="はずれ";
            Debug.Log("はずれ");
            continuous = 0;
	    }
	}
    
    void AnsCheckShape(int i, string ans){

        textFeedback = GameObject.Find ("Text").GetComponent<TextFeedback>();

        if(displayCardList[i].shape == ans){
            textFeedback.feedback="正解";
            Debug.Log("正解");
            continuous++;
		} else {
            textFeedback.feedback="はずれ";
            Debug.Log("はずれ");
            continuous = 0;
	    }
	}

    void CategoryChange(){
        
        if(ansType==1){
            if(Random.Range(0, 2)==0){
                ansType=2;     
			} else {
                ansType=3;     
			}
        } else if(ansType==2){
            if(Random.Range(0, 2)==0){
                ansType=1;     
			} else {
                ansType=3;     
			}
		} else if(ansType==3) {
            if(Random.Range(0, 2)==0){
                ansType=2;     
			} else {
                ansType=1;     
			}  
		}
        totalCategory++;
	}

}
