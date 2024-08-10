using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private Checkpoint cp;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag.Equals("Enemy"))
        {
            cp = GameObject.FindGameObjectWithTag("cp").GetComponent<Checkpoint>();
            transform.position = cp.lastCheckPointPos;
        }
    }
}
