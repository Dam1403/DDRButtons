using System;
using System.IO;
using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class OsuParser
{
    private delegate void Parser(string line, ref MusicMap map);


    public static MusicMap LoadOsuMap(string folderpath)
    {
        MusicMap newMap = new MusicMap();
        newMap.metadata = new MusicMetadata();
        newMap.timingPoints = new List<TimingPoint>();


        string osuFilepath = GetOsuFilePaths(folderpath)[0];
        string[] fileLines = File.ReadAllLines(osuFilepath);


        Parser parserDelegate = ParseGeneral;

        for(int i = 0; i < fileLines.Length; i++)
        {
            if(fileLines[i][0] == '[')
            {
                parserDelegate = GetParser(fileLines[i]);
            }
            parserDelegate(fileLines[i], ref newMap);
        }

        return newMap;
    }


    private static List<string> GetOsuFilePaths(string folderpath)
    {
        string[] allFiles = Directory.GetFiles(folderpath);
        List<string> osuFiles = new List<string>();

        for(int i = 0; i < allFiles.Length; i++)
        {
            if(Path.GetExtension(allFiles[i]) == "osu")
            {
                osuFiles.Add(allFiles[i]);
            }
        }
        return osuFiles;
    }
    
    private static Parser GetParser(string line)
    {
        switch (line.Trim())
        {
            case "[General]":
                return ParseGeneral;


            case "[Metadata]":
                return ParseMetadata;


            case "[TimingPoints]":
                return ParseTimingPoints;

        }

        return null;
    }
    private static void ParseGeneral(string line, ref MusicMap map)
    {
        string[] parts = line.Split(':');
        string value = parts[1].Trim();
        switch (parts[0])
        {
            case "AudioFileName":
                map.audioFilename = value;
                break;
            case "AudioLeadIn":
                map.audioLeadInMilliSecs = Int32.Parse(value);
                break;
        }
    }

    private static void ParseMetadata(string line, ref MusicMap map)
    {
        string[] parts = line.Split(':');
        string value = parts[1].Trim(); 
        switch (parts[0])
        {
            case "Title":
                map.metadata.title = value;
                break;
            case "TitleUnicode":
                map.metadata.titleUnicode = value;
                break;
            case "Artist":
                map.metadata.artist = value;
                break;
            case "ArtistUnicode":
                map.metadata.artistUnicode = value;
                break;
            case "Creator":
                map.metadata.creator = value;
                break;
        }
    }

    private static void ParseTimingPoints(string line, ref MusicMap map)
    {
        TimingPoint newPoint = new TimingPoint();
        string[] values = line.Split(',');
        newPoint.offSetMilliSecs = Int32.Parse(values[0]);
        newPoint.beatInterval = Int32.Parse(values[1]);
        newPoint.beatsPerMeasure = Int32.Parse(values[2]);
        map.timingPoints.Add(newPoint);
    }
}
