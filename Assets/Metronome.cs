using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Metronome : MonoBehaviour
{
    private MusicMap _map;
    private UnityEvent BeatEvent;
    private AudioSource _audioSource;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        BeatEvent = new UnityEvent();
    }
    public void LoadMap(MusicMap map)
    {
        _map = map;
        _audioSource.clip = map.song;
    }

    public void Play()
    {
        StartCoroutine(PlayLoop());
    }

   

    private IEnumerator PlayLoop()
    {
        float elaspedTime = 0;
        float nextbeat = _map.offset;
        _audioSource.Play();
        
        while (_audioSource.isPlaying)
        {

            elaspedTime += Time.deltaTime;

            if(elaspedTime >= nextbeat)
            {

                BeatEvent.Invoke();
                nextbeat += (60.0F / _map.bpm);
            }
            
            yield return null;

        }
    }


    public void AddBeatListener(UnityAction OnBeat)
    {
        BeatEvent.AddListener(OnBeat);
    }
}
