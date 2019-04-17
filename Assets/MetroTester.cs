using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MetroTester : MonoBehaviour
{

    Metronome nome;
    public MusicMap toLoad;
    [SerializeField]
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        toLoad = new MusicMap();
        toLoad.audioFilename = "resistance";
        //toLoad.bpm = 30.0F;
        toLoad.bpm = 148.0F;
        toLoad.offset = 0.0F;
        toLoad.beatsPerMeasure = 4;
        nome = GetComponent<Metronome>();
        nome.AddBeatListener(() => cube.SetActive(!cube.active));
        nome.LoadMap(toLoad);//Load a json from streaming assets. link to mp3 file
        nome.Play();
        Debug.Log("Done");
    }

}
