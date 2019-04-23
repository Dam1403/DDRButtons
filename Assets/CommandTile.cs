using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTile : MonoBehaviour
{
    public void Awake()
    {
        GetComponent<BoxCollider2D>().size = new Vector2(
            GetComponent<RectTransform>().rect.width,
            GetComponent<RectTransform>().rect.height
     );
    }
}
