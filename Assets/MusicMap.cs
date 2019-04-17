using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicMap
{
    public string songName = "[UNSET]";
    public string audioFilename = "[UNSET]";

    public string songArtist = "[UNSET]";
    public AudioClip song;
    public float bpm;
    public float offset;
    public int beatsPerMeasure;
    public string bpmScriptFilename = "[UNSET]";
    public int audioLeadInMilliSecs;
    public MusicMetadata metadata;
    public List<TimingPoint> timingPoints;

}

//Look for mode 3. 3 means mania
//use audioFilename
//Offset, Milliseconds per Beat, Meter, Sample Set, Sample Index, Volume, Inherited, Kiai Mode


public class MusicMetadata 
{
    public string title = "[UNSET]";
    public string titleUnicode = "[UNSET]";
    public string artist = "[UNSET]";
    public string artistUnicode = "[UNSET]";
    public string creator = "[UNSET]";
}

public class TimingPoint
{
    public int offSetMilliSecs;
    public int beatInterval;//When negative is percentage. if inherited skip
    public int beatsPerMeasure;
}


