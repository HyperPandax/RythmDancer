using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour { 
    [SerializeField] public float _beatTempo;
    [SerializeField] private bool _hasStarted;

    [SerializeField] private float _noteSpeed;

    private List<NoteObject> _notes;
    private NoteObject _note;
    public float _songLength = 0;
    private int _amountNotes = 0;

    [SerializeField] private Material _red, _orange, _yellow, _green, _blue, _violet, _indigo;
   
    // Start is called before the first frame update
    void Start(){
        print("constructor BeatScroller");
        _notes = new List<NoteObject>();
        _note = Resources.Load<NoteObject>("Prefabs/NoteGreen");

        _beatTempo = GameObject.Find("TransferSong").GetComponent<Music>().bpm;
        _noteSpeed = GameObject.Find("TransferSong").GetComponent<Music>().speed;
        _songLength = GameObject.Find("TransferSong").GetComponent<AudioSource>().clip.length;
        print(_songLength);
        spawnNotes();
    }

    void Update(){
        
        if (!_hasStarted){
           
        }else{
            this.transform.position -= (new Vector3(0f, 0f, ((_beatTempo/60f) * _noteSpeed) * Time.deltaTime));
            
        }
    }
    
    public void setHasStarted(bool hasstarted){
        _hasStarted = hasstarted;
    }

    void spawnNotes()
    {
        //need song length - few sec

        //distance between notes

        //change notespeed?

        int[] lanecoords = { -6, -4, -2, 0, 2, 4, 6};
        Material[] materials = { _red, _orange, _yellow, _green, _blue, _violet, _indigo };


        //print("lanecoords 3: "+ lanecoords[3]);

        int zpos = 0;
        //float songLength = GameManager.instance.songclip.clip.length;
        float amountnotes = ((_songLength / 60 * (_beatTempo)) / _noteSpeed); // 276 ;
        print("_beatTempo/60: "+ _beatTempo/60 + " _songLength in min: " + _songLength/60 + " amountNotes: " +amountnotes );
        //amountNotes = amountnotes.toInt
        
        _amountNotes = (int)amountnotes;
        _amountNotes -= 16;


        //space betwee
        for (var i = 0;i < _amountNotes; i++)
        {
            //randomize a lane num
            int lane = Random.Range(0, 6);
            zpos += 4;
            
            var newNote = GameObject.Instantiate(_note, new Vector3(lanecoords[lane], 0.3f, (zpos + this.gameObject.transform.position.z)*_noteSpeed), _note.transform.rotation);
            newNote.transform.parent = this.gameObject.transform;

            //newNote.gameObject.GetComponent<MeshRenderer>().material = materials[lane];
            var cilinder = newNote.transform.GetChild(0);
            cilinder.gameObject.GetComponent<MeshRenderer>().material = materials[lane];
        }
    }
    
}
