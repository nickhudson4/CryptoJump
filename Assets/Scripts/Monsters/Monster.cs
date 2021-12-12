using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    [SerializeField] private ParticleSystem destroyParticles;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private Animator animator;
    protected bool isDead = false;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (isDead)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (isDead){ return; }
        Player player = other.transform.parent.GetComponent<Player>();
        Bullet bullet = other.transform.parent.GetComponent<Bullet>();
        if (player)
        {
            OnHit(player, other.gameObject);
        }
        else if (bullet)
        {
            OnDeath();
        }
    }

    protected virtual void OnHit(Player player, GameObject hitObj)
    {
        Debug.Log("HIT: " + hitObj.name);
        if (player.rb.velocity.y < 0 && hitObj.tag == "FootCollider")
        {
            OnDeath();
            player.Jump(1200);
        }
        else
        {
            if (!player.isImmune)
            {
                gv.core.gameManager.OnLevelLose();
            }
            else
            {
                OnDeath();
            }
        }
    }

    protected virtual void OnDeath()
    {
        isDead = true;
        destroyParticles.transform.parent = null;
        destroyParticles.Play();
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, 1f);
        Set(false);
    }

    public void OnPause(bool pause)
    {
        if (pause)
        {
            if (animator){ animator.speed = 0; }
        }
        else 
        {
            if (animator){ animator.speed = 1; }
        }
    }

    protected void Set(bool set)
    {
        gameObject.SetActive(set);
    }
}
