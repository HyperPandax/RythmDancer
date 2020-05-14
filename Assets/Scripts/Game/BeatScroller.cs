using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour { 
    [SerializeField] private float beatTempo;
    [SerializeField] private bool hasStarted;

    [SerializeField] private float noteSpeed;

    // Start is called before the first frame update
    void Start(){
        beatTempo = beatTempo / 60f;
        
    }

    // Update is called once per frame
    void Update(){
        if (!hasStarted){
           
        }else{
            transform.position -= (new Vector3(0f, 0f, (beatTempo * noteSpeed) * Time.deltaTime));
        }
    }
    
    public void setHasStarted(bool hasstarted){
        hasStarted = hasstarted;
    }
}
