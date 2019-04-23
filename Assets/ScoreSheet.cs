using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSheet : MonoBehaviour
{
    [SerializeField] private RectTransform timingBar;
    private Metronome metronome;
    private List<CommandTile> scrollingTiles;



    private Vector3 position;
    private float barOffset;
    private float scoreWidth;

    private int currBeat = 0;
    // Start is called before the first frame update
    void Start()
    {
        metronome = Metronome.Instance;
        position = new Vector3();
        position.y = 0.0F;
        position.z = 0.0F;
        scoreWidth = timingBar.parent.GetComponent<RectTransform>().rect.width;
        barOffset = timingBar.anchorMin.x;
        Debug.Log(scoreWidth);


    }

    // Update is called once per frame
    void Update()
    {
        
        position.x = ((1 - metronome.BeatFloat) + barOffset) % 1  *  scoreWidth;
        position.y = 0.0F;
        position.z = 0.0F;
        timingBar.localPosition = position;
        //Debug.Log(metronome.BeatFloat);
        for(int i = 0; i < scrollingTiles.Count; i++)
        {
            scrollingTiles[i].transform.localPosition = position;//Fix this
        }
    }
}
