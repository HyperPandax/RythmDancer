using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour{
    public string songpath;
    public int bpm, speed;
    public bool played;
    public int songNum, score, hitNotes, missedNotes;


    void Awake(){
        songpath = "";
        DontDestroyOnLoad(this.gameObject);
    }
    public void changespeed(Slider slider){
        float value = slider.value;
        speed = (int)value;
    }
}
