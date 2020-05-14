using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour{
    public string songpath;

    void Awake(){
        songpath = " E:/..workSpace/Jaar3/Periode4/KICK PUNCH SOUND EFFECTS.mp3";
        DontDestroyOnLoad(this.gameObject);
    }
}
