using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{
    Light lt;
    //MySQL mysqlScript;
    //GameObject mySQLObj;
    double sdnn;
    double baseline;
    double max;
    float red=0;
    float blue=0;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        //mySQLObj = GameObject.Find ("MySQL");
        //mysqlScript = mySQLObj.GetComponent<MySQL>();
        sdnn = GameObject.Find ("Database").GetComponent<ToMySQL>().sdnn;
        baseline = GameObject.Find ("Database").GetComponent<ToMySQL>().baseline;
        max = GameObject.Find ("Database").GetComponent<ToMySQL>().max;
        float score=(float)((sdnn-baseline)/(max-baseline))*255;
        //Debug.Log(score);
        if(score>0){
            blue=0;
            if(score>255){
                score=255;     
			}
            if(red <= score){
                lt.color = new Color(red, 0, 0);
                //Debug.Log(red);
                red+=0.1f;
			}
		}
        if(score<0){
            red=0;
            if(score<-255){
                score=-255;     
			}
            if(score <= blue){
                lt.color = new Color(0, 0, -blue);
                //Debug.Log(blue);
                blue-=0.1f;
			}
		}
    }
}
