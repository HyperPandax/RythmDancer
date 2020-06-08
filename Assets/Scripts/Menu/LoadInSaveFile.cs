using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInSaveFile : MonoBehaviour{
    //list of song objects
    //private List<GameObject> songs = new List<GameObject>();

    public List<string> titles = new List<string>();
    public List<string> urls = new List<string>();
    public List<int> playedSongs = new List<int>();
    public List<int> score = new List<int>();
    public List<int> hitNotes = new List<int>();
    public List<int> missedNotes = new List<int>();
    public int amountSongs;

    [SerializeField] private GameObject songListContainer;
    private GameObject songbutton;
    private Text title;

    [SerializeField]
    GameObject printMobile;
    [SerializeField]
    Text printMobileTitles;

    private Text amountsongs;

    public string allsongs;

    private SongSelected songSelected;
    private GameObject selectedSong;


    private void Start(){
        amountsongs = printMobile.GetComponent<Text>();
        amountsongs.text = "Songs" + titles.Count;

       
    }
    private void Update(){
        amountsongs.text = "Songs: " + amountSongs;
    }
    public void AddToList(string title, string url /*, int songNum*/){
        //call this function after import of song
        if (!titles.Contains(title)) {  titles.Add(title);  }
        if (!urls.Contains(url)) { urls.Add(url); }
        
        /*score.Add(0);
        hitNotes.Add(0);
        missedNotes.Add(0);*/

        SaveSongs();
    }
    public void RemoveFromList(string title, string url/*, int songnum*/){
        print("Removefromlist");
        
        print(title);
        if (titles.Contains(title)) { titles.Remove(title); }
        if (urls.Contains(url)) { urls.Remove(url); }

        //if (playedSongs.Contains(songnum)) { playedSongs.Remove(songnum); }

        SaveSongs();
    }
    public void SongPlayed(int songnum)
    {
        print("Songplayed");
        if (!playedSongs.Contains(songnum)) { playedSongs.Add(songnum); } else
        {
            playedSongs.Add(0);
        }
        // addscore

        SaveSongs();
    }

    public void SaveSongs(){
        amountSongs = titles.Count;
        print(amountSongs);
        SaveSystem.SaveSongs(this);
    }

    public void loadSongs(){
        SongData data = SaveSystem.loadSongs();
        //make variables empyt
        titles.Clear();
        urls.Clear();
        allsongs = " ";

        //fillvariables with save data
        amountSongs = data.amountsongs;
        
        for (var i = 0; i < data.titles.Length; i++){   titles.Add(data.titles[i]);}
        for (var i = 0; i < data.urls.Length; i++){ urls.Add(data.urls[i]);}

        /*for (var i = 0; i < data.playedSongs.Length; i++) { playedSongs.Add(data.playedSongs[i]); }
        for (var i = 0; i < data.score.Length; i++) { score.Add(data.score[i]); }
        for (var i = 0; i < data.hitNotes.Length; i++) { hitNotes.Add(data.hitNotes[i]); }
        for (var i = 0; i < data.missedNotes.Length; i++) { missedNotes.Add(data.missedNotes[i]); }
        */
        for (var i = 0; i< amountSongs; i++){    allsongs += titles[i] +" , ";}

        

        //display songnames in text object
        printMobileTitles.text = allsongs;
    }

    public void SaveSongData(Music music)
    {
        print("num: "+ music.songNum +" mis: "+ music.missedNotes);

        /*playedSongs.Add(music.songNum);
        score.Add(music.score);
        hitNotes.Add(music.hitNotes);
        missedNotes.Add(music.missedNotes);
        SaveSystem.SaveSongs(this);*/
    }
}
