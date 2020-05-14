using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour{
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Missed"){
            gameObject.SetActive(false);
            GameManager.instance.NoteMis();
        }
    }   
}
