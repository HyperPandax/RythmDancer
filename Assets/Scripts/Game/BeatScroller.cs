using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour { 
    [SerializeField] public float _beatTempo;
    [SerializeField] private bool _hasStarted;

    [SerializeField] private float _noteSpeed;

    private List<NoteObject> _notes;
    private NoteObject _note;

    //private float timer;
    public bool startstopwatch = false;

    // Start is called before the first frame update
    void Start(){
        //_beatTempo = _beatTempo / 60f;
        _notes = new List<NoteObject>();
        _note = Resources.Load<NoteObject>("Prefabs/Note");

        //timer = 0;
        //SpawnNote(-2);
        //SpawnNote(-4);
        //measure time untill hit
    }

    // Update is called once per frame
    void Update(){
        /*if (startstopwatch)
        {
            TimerPrint();
        }*/
       
        if (!_hasStarted){
           
        }else{
            //for(var i = 0; i< _notes.Count; i++)
            //{
                //_notes[i].transform.position -= (new Vector3(0f, 0f, (_beatTempo * _noteSpeed) * Time.deltaTime));
                this.transform.position -= (new Vector3(0f, 0f, ((_beatTempo/60f) * _noteSpeed) * Time.deltaTime));

        //    }
        }
    }
    
    public void setHasStarted(bool hasstarted){
        _hasStarted = hasstarted;
    }
    /*public void SpawnNote(float xPos)
    {
        //xpos moet zijn: -6, -4, -2, 0, 2, 4, 6
        NoteObject n = Instantiate(_note, new Vector3(xPos, 0, 54), Quaternion.Euler(0, 0, 0));
        n.gameObject.transform.SetParent(this.gameObject.transform);
        _notes.Add(n);
        startstopwatch = true;
    }
    public void TimerPrint()
    {
        timer += Time.deltaTime;
        print("Seconds: "+timer % 60);
    }*/
}
