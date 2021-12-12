using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float jumpForce;
    private bool justLaunched = false;


    void Update()
    {
        if (justLaunched)
        {
            if (gv.core.gameManager.playerManager.player.rb.velocity.y < 0)
            {
                justLaunched = false;
                gv.core.gameManager.playerManager.player.isImmune = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Player player = other.transform.parent.gameObject.GetComponent<Player>();
        if (player)
        {
            if (player.rb.velocity.y < 0)
            {
                OnHit(player);
            }
        }
    }

    protected virtual void OnHit(Player player)
    {
        player.isImmune = true;
        player.Jump(jumpForce);
        if (audioSource)
        {
            audioSource.Play();
        }
        justLaunched = true;
    }

    protected void Set(bool set)
    {
        gameObject.SetActive(set);
    }
}
