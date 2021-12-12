using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    [SerializeField] protected float jumpForce;
    public bool isLastPlatform;
    [SerializeField] private AudioSource audioSource;
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Player player = other.transform.parent.gameObject.GetComponent<Player>();
        if (player)
        {
            if (other.gameObject.tag == "FootCollider" && player.rb.velocity.y < 0)
            {
                OnHit(player);
            }
        }
    }

    protected virtual void OnHit(Player player)
    {
        if (isLastPlatform)
        {
            gv.core.gameManager.OnHitLastPlatform(this);
        }
        if (audioSource)
        {
            audioSource.Play();
        }
    }

    protected void Set(bool set)
    {
        gameObject.SetActive(set);
    }
}
