using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MetroTester : MonoBehaviour
{

    Metronome nome;
    [SerializeField]
    public MusicMap toLoad;
    [SerializeField]
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        nome = GetComponent<Metronome>();
        nome.AddBeatListener(() => cube.SetActive(!cube.active));
        nome.LoadMap(toLoad);//Load a json from streaming assets. link to mp3 file
        nome.Play();

    }

}
