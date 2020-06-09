
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;

using System.IO;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour{
    [SerializeField] Text comboText;
    [SerializeField] Text scoreText;
    [SerializeField] Text healthText;

    private int combo;
    private int score;
    private int health;

    private int scorePerNote;

    private int missedNotes;
    private int hitNotes;

    private int amountNotes;

    public static GameManager instance;

    [SerializeField] private GameObject theMusic;
    //[SerializeField] private GameObject theMusicSilent;
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] bool startPlaying = true;
    [SerializeField] BeatScroller BS;

    GameObject songInput;
    public AudioSource songclip;

    [SerializeField] GameObject buttonToPause, pauseScreen;
   


    // Start is called before the first frame update
    void Start(){
        print("constructor GameManager");
        theMusic = GameObject.Find("TransferSong");
        //BS._beatTempo = theMusic.GetComponent<Music>().bpm;
        songclip = theMusic.GetComponent<AudioSource>();
        //BS.songLength = songclip.clip.length;
        
        instance = this;
        combo = 0;
        score = 0;
        health = 100;
        hitNotes = 0;
        missedNotes = 0;


        comboText.text = ("Combo: " + combo);
        scoreText.text = ("Score: " + score);
        healthText.text = ("Health: " + health);

        amountNotes = GameObject.FindGameObjectsWithTag("Note").Length;
        scorePerNote = 10000/amountNotes;

        startPlaying = true;
        BS.setHasStarted(true);
        songclip.Play();
    }

    // Update is called once per frame
    void Update(){
       
        if (!songclip.isPlaying)
        {
            endGame();
        }
        if(health < 100)
        {
            if (combo == 10) { health += 5; }
            if (combo == 20) { health += 10; }
            if (combo == 30) { health += 15; }
            if (combo == 40) { health += 20; }
            if (combo == 50) { health += 25; }
            if (combo == 100) { health += 50; }

        }
       

        comboText.text = ("Combo: " + combo);
        scoreText.text = ("Score: " + score);
        healthText.text = ("Health: " + health);
    }

    public void NoteHit(){
        print("Note Hit");
        hitNotes++;
        score += scorePerNote;
        combo++;
        soundEffect.Play();
        //BS.startstopwatch = false;
    }
    public void NoteMis(){
        print("Note mis");
        missedNotes++;
        health -=10;
        combo = 0;
    }

    public void loadscene(int sceneindex)
    {
        songclip.Pause();


        //Destroy(
        
        SceneManager.LoadSceneAsync(sceneindex, LoadSceneMode.Single);
        //SceneManager.
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneindex));
        SceneManager.UnloadSceneAsync(2);
       
    }
    public void pauseGame()
    {
        if (!pauseScreen.activeSelf && Time.timeScale == 1f)
        {
            buttonToPause.SetActive(false);
            pauseScreen.SetActive(true);
            AudioListener.pause = true;
            Time.timeScale = 0f;
        }
        else if (pauseScreen.activeSelf && Time.timeScale == 0f)
        {
            buttonToPause.SetActive(true);
            pauseScreen.SetActive(false);
            AudioListener.pause = false;
            Time.timeScale = 1f;
        }
    }
    private void endGame()
    {
        print("endgame");
        // save score

        theMusic.name = "SongResults";
        Music TSM = theMusic.GetComponent<Music>();
        TSM.played = true;
        TSM.score = score;
        TSM.missedNotes = missedNotes;
        TSM.hitNotes = hitNotes;
        
        //go to menu
        loadscene(1);
    }
}
