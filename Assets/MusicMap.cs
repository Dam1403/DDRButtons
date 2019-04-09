using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MusicMap", menuName = "MusicMap", order = 51)]
public class MusicMap : ScriptableObject
{
    public string songName;

    public string songArtist;
    public AudioClip song;
    public int bpm;
    public float offset;
    public string bpmScriptFilename;

}
