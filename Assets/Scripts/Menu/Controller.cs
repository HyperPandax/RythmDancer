using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Browser browser;
    public MobileImporter importer;
    public AudioSource audioSource;

    [SerializeField] private GameObject spinner;

    [SerializeField] private AudioSource theMusic;

    //variables for saving
    [SerializeField]
    private LoadInSaveFile loadInSaveFile;
    public string url, songName;
    public int BPM, songNum = 0, hitNotes = 0, missedNotes = 0, scoree = 0;
    
    private List<AudioSource> savedSongsAudio;
    private List<string> savedUrls, savedTitles;
        
    //gameobjects for instanciating
    [SerializeField] private GameObject songListContainer;
    private GameObject songbutton;
    private List<GameObject> songbuttons = new List<GameObject>();
    private Text title, bpm, songnum, played, score, hit, missed;

    private List<string> allImportedSongNames = new List<string>();

    private void Start()
    {
        // make a circle spin
        spinner.SetActive(true);
    }
    private void Update()
    {
        if (savedUrls.Count != 0)
        {
            RectTransform rectTransform = spinner.GetComponent<RectTransform>();
            rectTransform.Rotate(new Vector3(0, 0, -45));
        }
        else
        {
            spinner.SetActive(false);
        }
       
    }

    #region browserimport
    void Awake(){
        //when u select file in browser
        browser.FileSelected += OnFileSelected;
    }
    
    private void OnFileSelected(string path){
        //print("function onfileselected");
        if (importer.isDone)
            Destroy(audioSource.clip);

        StartCoroutine(Import(path));
        songName = Path.GetFileNameWithoutExtension(path);
        url = path;
    }

    IEnumerator Import(string path){
        importer.Import(path);
        while (!importer.isDone)
            yield return null;

        theMusic.clip = importer.audioClip;
        importSong2();
    }

    public void importSong2(){
        songListContainer = GameObject.FindGameObjectWithTag("ContentList");
        songbutton = Resources.Load<GameObject>("Prefabs/Song");
        title = songbutton.transform.GetChild(0).GetComponentInChildren<Text>();
        bpm = songbutton.transform.GetChild(1).GetComponentInChildren<Text>();

        songnum = songbutton.transform.GetChild(2).GetComponentInChildren<Text>();
        played  = songbutton.transform.GetChild(3).GetComponentInChildren<Text>();
        score = songbutton.transform.GetChild(4).GetComponentInChildren<Text>();
        hit  = songbutton.transform.GetChild(5).GetComponentInChildren<Text>();
        missed = songbutton.transform.GetChild(6).GetComponentInChildren<Text>();

        songnum.text = "songNum: " + songNum;


        AudioSource audio = songbutton.GetComponent<AudioSource>();

        audio.clip = theMusic.clip;
        title.text = songName;

        BPM = UniBpmAnalyzer.AnalyzeBpm(audio.clip);
        bpm.text = "bpm: " + BPM;

        if (allImportedSongNames.Contains(title.text))
        {
           // print("double " + title.text);
        }
        else
        {
            Instantiate(songbutton, songListContainer.transform);
            
            //save song
            loadInSaveFile.AddToList(songName, url/*, songNum*/);
            songNum++;
            allImportedSongNames.Add(title.text);

            browser.gameObject.SetActive(false);
            loadInSaveFile.SaveSongs();
        }
    }

    
    #endregion

    #region importFromSave
        public void importallsaves(){ 
            savedTitles = loadInSaveFile.titles;
            savedUrls = loadInSaveFile.urls;

            importsave(0);
        }
        public void importsave(int number){
            if(savedUrls[number] != null){StartCoroutine(ImportSave(number));}
        }

        IEnumerator ImportSave( int num){
            importer.Import(savedUrls[num]);
            while (!importer.isDone)
                yield return null;

            theMusic.clip = importer.audioClip;
            importload(num);
        }
        public void importload(int num){
            songListContainer = GameObject.FindGameObjectWithTag("ContentList");
            songbutton = Resources.Load<GameObject>("Prefabs/Song");

            title = songbutton.transform.GetChild(0).GetComponent<Text>();
            bpm = songbutton.transform.GetChild(1).GetComponent<Text>();
            songnum = songbutton.transform.GetChild(2).GetComponent<Text>();
            played = songbutton.transform.GetChild(3).GetComponent<Text>();
            score = songbutton.transform.GetChild(4).GetComponent<Text>();
            hit = songbutton.transform.GetChild(5).GetComponent<Text>();
            missed = songbutton.transform.GetChild(6).GetComponent<Text>();

            AudioSource audio = songbutton.GetComponent<AudioSource>();

            audio.clip = theMusic.clip;
            title.text = savedTitles[num];
            BPM = UniBpmAnalyzer.AnalyzeBpm(audio.clip);
            bpm.text = /*"bpm: " +*/ BPM.ToString();
            songNum++;
            songnum.text = songNum.ToString();

            /*if (loadInSaveFile.playedSongs.Contains(songNum)){
                for(int i = 0; i< loadInSaveFile.playedSongs.Count; i++){
                    if(loadInSaveFile.playedSongs[i] == songNum){
                        played.text = "true";
                        score.text = "Score: " + loadInSaveFile.score[i];
                        hit.text = "Hit: " + loadInSaveFile.hitNotes[i];
                        missed.text = "Mis: " + loadInSaveFile.missedNotes[i];
                    }
                }
                
            }
            else
            {    
                played.text = "false";
                score.text = "Score: " + loadInSaveFile.score[songNum];
                hit.text = "Hit: " + loadInSaveFile.hitNotes[songNum];
                missed.text = "Mis: " + loadInSaveFile.missedNotes[songNum];
                   
                
            }*/
            
            if (allImportedSongNames.Contains(title.text)){
                    //print("double " + title.text);
            }
            else{
                GameObject button = Instantiate(songbutton, songListContainer.transform);
                songbuttons.Add(button);
                loadInSaveFile.AddToList(savedTitles[num], savedUrls[num]);
                allImportedSongNames.Add(title.text);

                //print("num " + num + " saved titles: "+ savedTitles.Count);
                if(num < savedTitles.Count- 1){
                    importsave(num + 1);
                }
                else
                {
                //remove spinnning circle
                spinner.SetActive(false);
                }
            }
        }

    public void removeSong()
    {
        print(songbuttons.Count);
        for(int i =0; i < songbuttons.Count; i++)
        {
            if(songbuttons[i].GetComponent<SongSelected>().selectedSong != null)
            {
                print(savedTitles[i]);
                loadInSaveFile.RemoveFromList(savedTitles[i], savedUrls[i]/*, saved*/);
                Destroy(songbuttons[i]);
            }
        }
    }

    public void editSong( int num)
    {

        GameObject songbutton = songbuttons[num];
        //loadInSaveFile.SaveSongData
    }
    #endregion



}
