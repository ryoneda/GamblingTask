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
    GameObject gameFinish;
    public GameObject FinishPrefab;
    public GameObject PlayCanvasPrefab;

    float time;
    GameObject WriteCSV;
    ExportCSV ExportCSV;

    GameObject cgObj;
    CardGenerator cgScript;
    public GameObject coinPrefab;

    List<CardData> displayCardList = new List<CardData>(){
        new CardData( "RC1", 1, "red", "circle"),
        new CardData( "BR2", 2, "blue", "rect"),
        new CardData( "GT3", 3, "green", "tri"),
        new CardData( "YCr4", 4, "yellow", "cross")

    };

    void Start(){
        ansType = Random.Range(1, 4);
        WriteCSV = GameObject.Find("WriteCSV");
        ExportCSV = WriteCSV.GetComponent<ExportCSV>();
        cgObj = GameObject.Find ("CardGenerator");
        cgScript = cgObj.GetComponent<CardGenerator>();
    }

    void Update(){
        if (Input.GetKey(KeyCode.Escape)) FinishButton();
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
        time += Time.deltaTime;

        if(displayCardList[i].number == ans){
            textFeedback.feedback="正解";
            continuous++;
            Debug.Log("正解数　" + continuous);
            ExportCSV.WriteCSV(time.ToString(), ansType.ToString(), i.ToString(), cgScript.hand_num.ToString(), "OK");
            makeCoin();
		} else {
            textFeedback.feedback="はずれ";
            Debug.Log("はずれ");
            continuous = 0;
            ExportCSV.WriteCSV(time.ToString(), ansType.ToString(), i.ToString(), cgScript.hand_num.ToString(), "Out");
	    }
	}

    void AnsCheckColor(int i, string ans){

        textFeedback = GameObject.Find ("Text").GetComponent<TextFeedback>();
        time += Time.deltaTime;

        if(displayCardList[i].color == ans){
            textFeedback.feedback="正解";
            continuous++;
            Debug.Log("正解数　" + continuous);
            ExportCSV.WriteCSV(time.ToString(), ansType.ToString(), i.ToString(), cgScript.hand_num.ToString(), "OK");
            makeCoin();
		} else {
            textFeedback.feedback="はずれ";
            Debug.Log("はずれ");
            continuous = 0;
            ExportCSV.WriteCSV(time.ToString(), ansType.ToString(), i.ToString(), cgScript.hand_num.ToString(), "Out");
	    }
	}
    
    void AnsCheckShape(int i, string ans){

        textFeedback = GameObject.Find ("Text").GetComponent<TextFeedback>();
        time += Time.deltaTime;

        if(displayCardList[i].shape == ans){
            textFeedback.feedback="正解";
            continuous++;
            Debug.Log("正解数　" + continuous);
            makeCoin();
            ExportCSV.WriteCSV(time.ToString(), ansType.ToString(), i.ToString(), cgScript.hand_num.ToString(), "OK");
		} else {
            textFeedback.feedback="はずれ";
            Debug.Log("はずれ");
            continuous = 0;
            ExportCSV.WriteCSV(time.ToString(), ansType.ToString(), i.ToString(), cgScript.hand_num.ToString(), "Out");
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
        continuous=0;
        Debug.Log("totalCategory "+totalCategory);
        if (totalCategory==10) GameFinish();

	}

    void GameFinish(){
    
        gameFinish = Instantiate(FinishPrefab);
        ExportCSV.FinishWritingCSV();
        Destroy(PlayCanvasPrefab);
        //button = gameFinish.GetComponentsInChildren<Button>();
        //buttons[0].onClick.AddListener(FinishButton);
	}

    void makeCoin(){
        for(int i=0; i<100; i++){
            var vec1 = new Vector3(2.6f,3f,1.4f);
            GameObject coinObj = Instantiate(coinPrefab, vec1, new Quaternion(Random.Range(0f, 64f), Random.Range(0f, 64f), Random.Range(0f, 64f), 1.0f));
	    }
	}

    void FinishButton(){
        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }
}
