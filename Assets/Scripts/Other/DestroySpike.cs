using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpike : MonoBehaviour
{
    public playerMovement hp;
    public HealthBar HPbar;
    public Animator Spikes;
    private int isSpiked = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSpiked == 0)
        {
            if (collision.CompareTag("Player"))
            {
                
                Spikes.SetBool("stop", false);
                Spikes.SetBool("activated", true);
                hp.currentHealth -= 1;
                HPbar.SetHP(hp.currentHealth);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isSpiked == 0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isSpiked = 1;
                Spikes.SetBool("activated", false);
                Spikes.SetBool("stop", true);
                //Destroy(this);


            }
        }
    }
}
