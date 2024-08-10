using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]

public class Point : MonoBehaviour
{

    private Checkpoint cp;
    private GameObject pl;
    public MeshRenderer meshrender;
    public Material collided;

    void Start()
    {
        cp = GameObject.FindGameObjectWithTag("cp").GetComponent<Checkpoint>();
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
            cp.lastCheckPointPos = transform.position;
            meshrender.material = collided;
        }
    }
}
