using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SongSelected : MonoBehaviour{
    public bool todestroy = true;
    // Start is called before the first frame update

    public GameObject selectedSong;
    private AudioSource audioSelected;
    public GameObject songTransfer;
    public int bpm;

    private Music someScript;

    public void selectSong() {
        //get pressed button GO
        selectedSong = EventSystem.current.currentSelectedGameObject;
        print(selectedSong);
        var songImage = selectedSong.GetComponent<Button>().colors;

        // make pressed GO magenta
        songImage.selectedColor = Color.magenta;
        selectedSong.GetComponent<Button>().colors = songImage;

        //get audio from pressed button GO
        audioSelected = selectedSong.GetComponent<AudioSource>();
        print(audioSelected.clip.name);

        //put audio in transferable GO
        songTransfer = GameObject.Find("TransferSong");
        AudioSource ST = songTransfer.GetComponent<AudioSource>();
        ST.clip = audioSelected.clip;

        Text bpmText = selectedSong.transform.GetChild(1).GetComponent<Text>();
        string bpmm = bpmText.text;
        int.TryParse(bpmm, out bpm);//UniBpmAnalyzer.AnalyzeBpm(ST.clip);
        //Debug.Log("BPM is " + bpm);
        
        someScript = songTransfer.GetComponent<Music>();
        someScript.bpm = bpm;

    }
}
