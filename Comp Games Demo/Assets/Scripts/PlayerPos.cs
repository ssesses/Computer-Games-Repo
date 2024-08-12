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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            cp = GameObject.FindGameObjectWithTag("cp").GetComponent<Checkpoint>();
            transform.position = cp.lastCheckPointPos + new Vector3(0, 5, 0);
        }
    }
}
