using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour{

    void Update()
    {

        // Move the object forward along its z axis 5 unit/second.
        // 20 units total
        
        //if song started
        //transform.Translate(Vector3.back * Time.deltaTime * 5);

        
    }
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Missed"){
            gameObject.SetActive(false);
            GameManager.instance.NoteMis();
        }
    }   
}
