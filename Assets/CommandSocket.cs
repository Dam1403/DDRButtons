using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CommandSocket : MonoBehaviour
{
    [SerializeField]
    private Image commandBorder;

    [SerializeField]
    private Image commandColor;





    public void SetColor(Color color)
    {
        commandColor.color = color;
    }
}
