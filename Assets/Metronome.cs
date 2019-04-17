using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Metronome : Singleton<Metronome>
{
    private MusicMap _map;
    private UnityEvent BeatEvent;
    private float beatFloat;
    private AudioSource _audioSource;

    public float BeatFloat
    {
        get
        {
            return beatFloat;
        }
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        BeatEvent = new UnityEvent();
    }
    public void LoadMap(MusicMap map)
    {
        _map = map;
        _audioSource.clip = (AudioClip)Resources.Load(map.audioFilename);
    }

    public void Play()
    {
        StartCoroutine(PlayLoop());
    }

   

    private IEnumerator PlayLoop()
    {
        float elaspedTime = 0;
        float nextbeat = _map.offset;
        float beatInterval = 60.0F / _map.bpm;
        _audioSource.Play();
        
        while (_audioSource.isPlaying)
        {

            elaspedTime += Time.deltaTime;

            if(elaspedTime >= nextbeat)
            {

                BeatEvent.Invoke();
                nextbeat += beatInterval;

            }
            beatFloat = (elaspedTime - _map.offset) % beatInterval;//Optomize later. 
            beatFloat = beatFloat / beatInterval;
            //Debug.Log((elaspedTime - _map.offset) / beatInterval);
            Debug.Log(beatInterval);

            yield return null;

        }
    }


    public void AddBeatListener(UnityAction OnBeat)
    {
        BeatEvent.AddListener(OnBeat);
    }
}
