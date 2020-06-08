using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SongSelected : MonoBehaviour{
    public bool todestroy = true;
    
    public GameObject selectedSong;
    private AudioSource audioSelected;
    public GameObject songTransfer;
    public int bpm;

    private Music someScript;

    //removing songs
    private GameObject controller;
    [SerializeField] private GameObject confirmationPopup;
    
    public void selectSong() {
        //get pressed button GO
        selectedSong = EventSystem.current.currentSelectedGameObject;
        //print(selectedSong);
        var songImage = selectedSong.GetComponent<Button>().colors;

        // make pressed GO magenta
        songImage.selectedColor = Color.magenta;
        selectedSong.GetComponent<Button>().colors = songImage;

        //get audio from pressed button GO
        audioSelected = selectedSong.GetComponent<AudioSource>();
        //print(audioSelected.clip.name);

        //put audio in transferable GO
        songTransfer = GameObject.Find("TransferSong");
        AudioSource ST = songTransfer.GetComponent<AudioSource>();
        ST.clip = audioSelected.clip;

        Text bpmText = selectedSong.transform.GetChild(1).GetComponent<Text>();
        string bpmm = bpmText.text;
        int.TryParse(bpmm, out bpm);
                
        someScript = songTransfer.GetComponent<Music>();
        someScript.bpm = bpm;
        int.TryParse(selectedSong.transform.GetChild(2).GetComponent<Text>().text, out someScript.songNum);

    }
    public void popup(){
        selectedSong = EventSystem.current.currentSelectedGameObject;
        if (!confirmationPopup.activeSelf){
            confirmationPopup.SetActive(true);
        }else{
            confirmationPopup.SetActive(false);
        }
    }
    public void removeSong(){
        controller = GameObject.Find("Controller");
        Controller controllerr = controller.GetComponent<Controller>();
        controllerr.removeSong();
    }
    
}
