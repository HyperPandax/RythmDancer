using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour{
    private bool pressed = false;
    public bool canBePressed = false;


    public void OnMouseDown()
    {
        print("MouseDown");
        //this.transform.Translate(new Vector3(0, -0.1f, 0));
        pressed = true;
        if (canBePressed)
        {
            this.gameObject.SetActive(false);
            GameManager.instance.NoteHit();
        }
    }
    public void OnMouseUp()
    {
        print("MouseUp");
        //this.transform.Translate(new Vector3(0, 0.1f, 0));
        pressed = false;
    }



    private void OnTriggerEnter(Collider other){
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
        if (other.tag == "Missed"){
            gameObject.SetActive(false);
            GameManager.instance.NoteMis();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
        }
    }
}
