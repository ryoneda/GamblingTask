using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchChanger : MonoBehaviour
{
    AudioSource audioSource;
    float maxPitch=1.5f;
    float minPitch=0.5f;
    float startingPitch = 1;
    double sdnn;
    double baseline;
    double max;
    float score;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = startingPitch;
    }

    // Update is called once per frame
    void Update()
    {
        sdnn = GameObject.Find ("Database").GetComponent<ToMySQL>().sdnn;
        baseline = GameObject.Find ("Database").GetComponent<ToMySQL>().baseline;
        max = GameObject.Find ("Database").GetComponent<ToMySQL>().max;
        
        //score=(float)((sdnn)/(max))*1.5f;  
        score=(float)(sdnn/baseline);
		
        audioSource.pitch = score;
    }
}
