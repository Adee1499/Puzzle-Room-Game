using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// This class is used to represent a code item (a string) in the code matrix.

public class CodeMatrixItem : TextItem
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private EventTrigger eventTrigger;

    public Button ButtonObject { get => button; }

    public EventTrigger EventTrigger { get => eventTrigger; }

    public Vector2Int Location { get; set; }

    public void MarkAsUsed()
    {
        TextObject.text = string.Empty;
        ButtonObject.interactable = false;
    }
}
