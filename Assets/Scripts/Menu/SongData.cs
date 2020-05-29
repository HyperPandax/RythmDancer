using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SongData{

    public string[] urls;
    public string[] titles;
    public int amountsongs;
    public int BPM;

    //public bool played;
    //public float score;
    //public int maxcombo;
    //public int missedNotes;
    //public int goodNotes;
    //public int prefectNotes;

    //public float time;
    //public int[] beatmap;

    public SongData(LoadInSaveFile save){
        titles = new string[save.titles.Count];
        urls = new string[save.urls.Count];

        amountsongs = save.amountSongs;

        for (var i = 0; i < save.titles.Count; i++) {
            titles[i] = save.titles[i];
        }
        for (var i = 0; i < save.urls.Count; i++) {
            urls[i] = save.urls[i];
        }
    }
}
