using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInSaveFile : MonoBehaviour{
    //list of song objects
    //private List<GameObject> songs = new List<GameObject>();

    public List<string> titles = new List<string>();
    public List<string> urls = new List<string>();
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
    
    private void Start(){
        amountsongs = printMobile.GetComponent<Text>();
        amountsongs.text = "Songs" + titles.Count;
    }
    private void Update(){
        amountsongs.text = "Songs: " + amountSongs; 
    }
    public void AddToList(string title, string url){
        //call this function after import of song
        if (!titles.Contains(title)) {  titles.Add(title);  }
        if (!urls.Contains(url)) { urls.Add(url); }      
    }

    public void SaveSongs(){
        amountSongs = titles.Count;
        print(urls[0]);
        print(titles[0]);
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
        print(amountSongs);

        for (var i = 0; i < data.titles.Length; i++){   titles.Add(data.titles[i]);}
        for (var i = 0; i < data.urls.Length; i++){ urls.Add(data.urls[i]);}             
        for(var i = 0; i< amountSongs; i++){    allsongs += titles[i] +" , ";}

        //display songnames in text object
        printMobileTitles.text = allsongs;
    }
}
