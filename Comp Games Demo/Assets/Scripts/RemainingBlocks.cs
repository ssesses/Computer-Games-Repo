using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainingBlocks : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI remainingBlocks;
    [SerializeField] public float blockCount;
    public KeyCode throwKey;

    void Start()
    {
        remainingBlocks.text = "100";
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(throwKey))
        {
            if(blockCount > 0)
            {
                blockCount -= 1;
            }
            else if(blockCount < 1)
            {
                blockCount = 0;
                remainingBlocks.color = Color.red;
            }
            remainingBlocks.text = string.Format("{0}", blockCount);
        }
    }
}