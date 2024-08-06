using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private Animator openDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    
    private bool isLowered = false;

    public AudioSource audioSource;
    public AudioClip lower;

    private void OnTriggerEnter(Collider player)
    {
        if(player.CompareTag("Player"))
        {
            if(openTrigger)
            {
                //if(isLowered == false)
                {
                    isLowered = true;
                    audioSource.PlayOneShot(lower);
                    openDoor.Play("Door", 0, 0.0f);
                    //gameObject.SetActive(false);
                }
            }

            else if(closeTrigger)
            {
                //if(isLowered == true)
                {
                    isLowered = false;
                    audioSource.PlayOneShot(lower);
                    openDoor.Play("Door Close", 0, 0.0f);
                    //gameObject.SetActive(false);
                }
            }
        }
    }
}
