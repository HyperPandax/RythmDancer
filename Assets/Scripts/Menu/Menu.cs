using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour{
    [SerializeField] private GameObject _fileExplorer;

    [SerializeField] private LoadInSaveFile _loadInSaveFile;
    [SerializeField] private Controller _controller;

    private Music _songresults;

    private void Start(){
        if(GameObject.Find("SongResults") != null)
        {
            _songresults = GameObject.Find("SongResults").GetComponent<Music>();
            _loadInSaveFile.SaveSongData(_songresults);
        }

        _loadInSaveFile.loadSongs();
        _controller.importallsaves();
    }
    
    public void loadscene(int sceneindex){
        SceneManager.LoadScene(sceneindex);
    }

    public void importSong(){
        _fileExplorer.SetActive(true);
    }

    public void Quit(){
        Application.Quit();
    }
}
