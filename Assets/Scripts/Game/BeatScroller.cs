using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour { 
    [SerializeField] private float _beatTempo;
    [SerializeField] private bool _hasStarted;

    [SerializeField] private float _noteSpeed;

    private List<NoteObject> _notes;
    private NoteObject _note;

    // Start is called before the first frame update
    void Start(){
        _beatTempo = _beatTempo / 60f;
        _notes = new List<NoteObject>();
        _note = Resources.Load<NoteObject>("Prefabs/Note");
        SpawnNote(this.transform.position.x);
    }

    // Update is called once per frame
    void Update(){
        if (!_hasStarted){
           
        }else{
            for(var i = 0; i< _notes.Count; i++)
            {
                _notes[i].transform.position -= (new Vector3(0f, 0f, (_beatTempo * _noteSpeed) * Time.deltaTime));

            }
        }
    }
    
    public void setHasStarted(bool hasstarted){
        _hasStarted = hasstarted;
    }
    public void SpawnNote(float xPos)
    {
        NoteObject n = Instantiate(_note, new Vector3(xPos, 1.0f, 30), Quaternion.Euler(0, 0, 0));
        _notes.Add(n);
    }
}
