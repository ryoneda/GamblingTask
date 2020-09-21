using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFace : MonoBehaviour
{
SpriteRenderer MainSpriteRenderer;
    double sdnn;
    double baseline;
    double max;
    public Sprite Normal;
    public Sprite Smile1;
    public Sprite Smile2;
    public Sprite Smile3;
    public Sprite Smile4;
    public Sprite Smile5;
    public Sprite Disgust1;
    public Sprite Disgust2;
    public Sprite Disgust3;
    public Sprite Disgust4;
    public Sprite Disgust5;


    void Start ()
    {
       // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

        void Update()
    {
        sdnn = GameObject.Find ("Database").GetComponent<ToMySQL>().sdnn;
        baseline = GameObject.Find ("Database").GetComponent<ToMySQL>().baseline;
        max = GameObject.Find ("Database").GetComponent<ToMySQL>().max;
        float score=(float)((sdnn-baseline)/(max-baseline))*100;

        Change(score);
        Debug.Log(score);
        
    }

    // 何かしらのタイミングで呼ばれる
    void Change(float score)
    {
       if(80<=score){
           MainSpriteRenderer.sprite = Smile5;
	   }else if(60<=score && score<80){
           MainSpriteRenderer.sprite = Smile4;
	   }else if(40<=score && score<60){
           MainSpriteRenderer.sprite = Smile3;
	   }else if(20<=score && score<40){
           MainSpriteRenderer.sprite = Smile2;
	   }else if(0<=score && score<20){
           MainSpriteRenderer.sprite = Smile1;
	   }else if(-20<=score && score<0){
           MainSpriteRenderer.sprite = Disgust1;
	   }else if(-40<=score && score<-20){
           MainSpriteRenderer.sprite = Disgust2;
	   }else if(-60<=score && score<-40){
           MainSpriteRenderer.sprite = Disgust3;
	   }else if(-80<=score  && score<-60){
           MainSpriteRenderer.sprite = Disgust4;
	   }else if(score<-80){
           MainSpriteRenderer.sprite = Disgust5;
	   }
       // SpriteRenderのspriteを設定済みの他のspriteに変更
       // 例) HoldSpriteに変更
       if (Input.GetKey(KeyCode.Space)) {
            MainSpriteRenderer.sprite = Smile1;
        }
    }
}