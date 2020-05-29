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

    [SerializeField] private AudioSource theMusic;

    //variables for saving
    [SerializeField]
    private LoadInSaveFile loadInSaveFile;
    public string url, songName;
    
    private List<AudioSource> savedSongsAudio;
    private List<string> savedUrls, savedTitles;
        
    //gameobjects for instanciating
    [SerializeField] private GameObject songListContainer;
    private GameObject songbutton;
    private Text title;

    private List<string> allImportedSongNames = new List<string>();

    #region browserimport
    void Awake(){
        //when u select file in browser
        browser.FileSelected += OnFileSelected;
    }
    
    private void OnFileSelected(string path){
        print("function onfileselected");
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
        title = songbutton.GetComponentInChildren<Text>();

        AudioSource audio = songbutton.GetComponent<AudioSource>();

        audio.clip = theMusic.clip;
        title.text = songName;

        if (allImportedSongNames.Contains(title.text))
        {
            print("double " + title.text);
        }
        else
        {
            Instantiate(songbutton, songListContainer.transform);
            //save song
            loadInSaveFile.AddToList(songName, url);
            allImportedSongNames.Add(title.text);

            browser.gameObject.SetActive(false);
            loadInSaveFile.SaveSongs();
        }
    }
    #endregion

    #region importFromSave
        public void importallsaves(){
            print(allImportedSongNames.Count);
            savedTitles = loadInSaveFile.titles;
            savedUrls = loadInSaveFile.urls;

            importsave(0);
        }
        public void importsave(int number){
            print("Importsave Function");
            if(savedUrls[number] != null){StartCoroutine(ImportSave(number));}
        }

        IEnumerator ImportSave( int num){
            print("in IEnum saved url."+num+": "+savedUrls[num]);
            importer.Import(savedUrls[num]);
            while (!importer.isDone)
                yield return null;

            theMusic.clip = importer.audioClip;
            importload(num);
        }
        public void importload(int num){
            songListContainer = GameObject.FindGameObjectWithTag("ContentList");
            songbutton = Resources.Load<GameObject>("Prefabs/Song");
            title = songbutton.GetComponentInChildren<Text>();

            AudioSource audio = songbutton.GetComponent<AudioSource>();

            audio.clip = theMusic.clip;
            title.text = savedTitles[num];

           

        if (allImportedSongNames.Contains(title.text)){
                print("double " + title.text);
            }
            else{
                Instantiate(songbutton, songListContainer.transform);
                loadInSaveFile.AddToList(savedTitles[num], savedUrls[num]);
                allImportedSongNames.Add(title.text);

                print("num " + num + " saved titles: "+ savedTitles.Count);
                if(num < savedTitles.Count- 1){
                    importsave(num + 1);
                }
            }
        }
    #endregion

    

}
