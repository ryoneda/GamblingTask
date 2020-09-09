using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreFeedback : MonoBehaviour
{
    Text text;
    public string scorefeedback;

    void Start(){
     
	}

    void Update(){

        this.text = this.GetComponent<Text>();
        text.text = "Score: " + scorefeedback;
    
	}
}
