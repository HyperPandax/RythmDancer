
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private int hitNotes;

    private int amountNotes;

    [SerializeField] private GameObject theMusic;
    //[SerializeField] private GameObject theMusicSilent;
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] bool startPlaying = true;
    [SerializeField] BeatScroller BS;

    public static GameManager instance;

    GameObject songInput;
    AudioSource songclip;
    //AudioSource songclipSilent;
    //Music songInputPath;
    


    // Start is called before the first frame update
    void Start(){
        theMusic = GameObject.Find("TransferSong");
        BS._beatTempo = theMusic.GetComponent<Music>().bpm;
        //theMusicSilent = GameObject.Find("Music");

        //theMusicSilent.GetComponent<AudioSource>().clip = theMusic.GetComponent<AudioSource>().clip;
        //theMusicSilent.GetComponent<AudioSource>().time = 10;//theMusicSilent.GetComponent<AudioSource>().clip.length * .5f;
        

        instance = this;
        combo = 0;
        score = 0;
        health = 100;
        hitNotes = 0;

        comboText.text = ("Combo: " + combo);
        scoreText.text = ("Score: " + score);
        healthText.text = ("Health: " + health);

        //print("music length:" + theMusic.clip.length);

        amountNotes = GameObject.FindGameObjectsWithTag("Note").Length;
        print("amountNotes:" + amountNotes);
        scorePerNote = 10000/amountNotes;
    }

    // Update is called once per frame
    void Update(){
        if (!startPlaying) {
            if (Input.anyKeyDown){
                startPlaying = true;
                BS.setHasStarted(true);

                //songclipSilent = theMusicSilent.GetComponent<AudioSource>();
                songclip = theMusic.GetComponent<AudioSource>();
                //songclipSilent.Play();
                songclip.Play();
            }
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

        BS.startstopwatch = false;
    }
    public void NoteMis(){
        print("Note mis");
        
        health -=10;
        combo = 0;
    }

    public void loadscene(int sceneindex)
    {
        songclip.Pause();
        //SceneManager.UnloadSceneAsync(1);
        //SceneManager.LoadScene(sceneindex);

        Destroy(GameObject.Find("TransferSong"));
        SceneManager.LoadScene(sceneindex, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneindex));
        SceneManager.UnloadSceneAsync(1);
       
    }
}
