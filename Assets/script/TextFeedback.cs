using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFeedback : MonoBehaviour
{
    Text text;
    public string feedback;
    float seconds;

    void Start(){
        
        
	}

    void Update(){

        this.text = this.GetComponent<Text>();

        text.text = feedback;
        seconds += Time.deltaTime;

        if (seconds >= 1)
        {
            seconds = 0;
            feedback="";
        }
    
	}
}
