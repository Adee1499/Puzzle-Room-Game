using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This class is used to initialize the minigame with random values. It should be replaced if the minigame is used on an actual game.
public class GameSetup : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private CodeMatrix codeMatrix;

    [SerializeField]
    private Buffer buffer;

    [SerializeField]
    private CodeSequence codeSequence;

    [SerializeField]
    [Range(25, 45)]
    private float minTime = 45;

    [SerializeField]
    [Range(25, 99)]
    private float maxTime = 60;

    [SerializeField]
    [Range(8, 8)]
    private int codeMatrixMinSize = 8;

    [SerializeField]
    [Range(8, 8)]
    private int codeMatrixMaxSize = 8;

    [SerializeField]
    [Range(3, 8)]
    private int bufferMinSize = 8;

    [SerializeField]
    [Range(6, 8)]
    private int bufferMaxSize = 8;

    [SerializeField]
    [Range(1, 1)]
    private int codeSequenceMinItemCount = 1;

    [SerializeField]
    [Range(1, 1)]
    private int codeSequenceMaxItemCount = 1;

    [SerializeField]
    [Range(7, 8)]
    private int codeSequenceMinCodeSize = 7;

    [SerializeField]
    [Range(7, 8)]
    private int codeSequenceMaxCodeSize = 8;

    private void Awake()
    {
        timer.Time = Random.Range(minTime, maxTime + 1);
        codeMatrix.Size = Random.Range(codeMatrixMinSize, codeMatrixMaxSize + 1);
        buffer.Size = Random.Range(bufferMinSize, bufferMaxSize + 1);
        codeSequence.ItemCount = Random.Range(codeSequenceMinItemCount, codeSequenceMaxItemCount + 1);
        codeSequence.MinCodeSize = codeSequenceMinCodeSize;
        codeSequence.MaxCodeSize = Mathf.Min(buffer.Size, codeSequenceMaxCodeSize);
    }
}
