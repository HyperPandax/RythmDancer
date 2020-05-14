using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour{
    public string songpath;

    void Awake(){
        songpath = "";
        DontDestroyOnLoad(this.gameObject);
    }
}
