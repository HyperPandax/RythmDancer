using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SongData{

    public int[] songNum;

    public string[] urls;
    public string[] titles;
    public int amountsongs;
    public int BPM;

    public int[] score;
    public int[] missedNotes;
    public int[] hitNotes;

    public int[] playedSongs;


    //public float score;
    //public int maxcombo;
    //public int missedNotes;
    //public int goodNotes;
    //public int prefectNotes;

    //public float time;
    //public int[] beatmap;

    public SongData(LoadInSaveFile save){

        songNum = new int[save.amountSongs];

        titles = new string[save.titles.Count];
        urls = new string[save.urls.Count];

        playedSongs = new int[save.playedSongs.Count];
        score = new int[save.score.Count];
        hitNotes = new int[save.hitNotes.Count];
        missedNotes = new int[save.missedNotes.Count];

        amountsongs = save.amountSongs;

        for (var i = 0; i < save.amountSongs; i++)
        {
            songNum[i] = i;
            Debug.Log("Songnum: " + songNum[i]);
        }
        for (var i = 0; i < save.titles.Count; i++) {
            titles[i] = save.titles[i];
        }
        for (var i = 0; i < save.urls.Count; i++) {
            urls[i] = save.urls[i];
        }

        /*if (save.playedSongs[0] != null)
        {
            for (var i = 0; i < save.playedSongs.Count; i++)
            {
                playedSongs[i] = save.playedSongs[i];
                Debug.Log("playedSongs: " + playedSongs[i]);
            }
        }*/


        if (save.score[0] != null)
        {
            for (var i = 0; i < save.score.Count; i++)
            {
                score[i] = save.score[i];
                Debug.Log("score: " + score[i]);
            }
        }
        if (save.hitNotes[0] != null)
        {
            for (var i = 0; i < save.hitNotes.Count; i++)
            {
                hitNotes[i] = save.hitNotes[i];
                Debug.Log("hitNotes: " + hitNotes[i]);
            }
        }
        if (save.missedNotes[0] != null)
        {
            for (var i = 0; i < save.missedNotes.Count; i++)
            {
                missedNotes[i] = save.missedNotes[i];
                Debug.Log("missedNotes: " + missedNotes[i]);
            }
        }
        /*for (var i = 0; i < save.playedSongs.Count; i++)
        {
            playedSongs[i] = save.playedSongs[i];
            Debug.Log("playedSongs: " + playedSongs[i]);
        }*/
        /*for (var i = 0; i < save.hitNotes.Count; i++)
        {
            if(hitNotes[i] != null)
            {
                hitNotes[i] = save.hitNotes[i];
                Debug.Log("hitNotes: " + hitNotes[i]);
            }
            else
            {
                hitNotes[i] = 0;
                Debug.Log("hitNotes["+ i +"] doesnt work");
            }
            
        }
        for (var i = 0; i < save.missedNotes.Count; i++)
        {
            if (missedNotes[i] != null)
            {
                missedNotes[i] = save.missedNotes[i];
                Debug.Log("missedNotes: " + missedNotes[i]);
            }
            else
            {
                missedNotes[i] = 0;
                Debug.Log("missedNotes[" + i + "] doesnt work");
            }
            
        }*/

    }
}
