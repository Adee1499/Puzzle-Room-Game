using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// This helper class is used to represent a game object with a text field.

public class TextItem : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public Text TextObject { get => text; }
}
