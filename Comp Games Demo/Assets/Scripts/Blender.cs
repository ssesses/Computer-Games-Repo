using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{

    public AudioSource sound;
    public AudioClip win;
    public static bool isWon;

    void Start()
    {
        isWon = false;
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag.Equals("Player"))
        {
           sound.PlayOneShot(win);
           isWon = true;
        }
    }
}
