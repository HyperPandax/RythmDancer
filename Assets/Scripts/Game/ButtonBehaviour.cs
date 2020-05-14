using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour{ 
    private bool pressed;
    private bool canBePressed;

    private GameObject currentNote;


    // Start is called before the first frame update
    void Start(){
        pressed = false;
        canBePressed = false;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OnMouseDown(){ 
        print("MouseDown");
        this.transform.Translate(new Vector3(0, -0.1f, 0));
        pressed = true;
        if (canBePressed){
            currentNote.gameObject.SetActive(false);
            GameManager.instance.NoteHit();
        }
    }
    public void OnMouseUp(){
        print("MouseUp");
        this.transform.Translate(new Vector3(0, 0.1f, 0));
        pressed = false;
    }

    private void OnTriggerEnter(Collider other){
        if (other.tag == "Note"){
            canBePressed = true;
            currentNote = other.gameObject;
        }
        
    }
    private void OnTriggerExit(Collider other){
        if (other.tag == "Note"){
            canBePressed = false;
        }
    }
}
