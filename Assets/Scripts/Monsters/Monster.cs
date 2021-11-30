using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    [SerializeField] private ParticleSystem destroyParticles;
    [SerializeField] private AudioClip deathSound;
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
        Player player = other.transform.parent.GetComponent<Player>();
        Bullet bullet = other.transform.parent.GetComponent<Bullet>();
        if (player)
        {
            OnHit(player);
        }
        else if (bullet)
        {
            OnDeath();
        }
    }

    protected virtual void OnHit(Player player)
    {
        if (player.rb.velocity.y < 0)
        {
            OnDeath();
            player.Jump(1200);
        }
        else
        {
            gv.core.gameManager.OnLevelLose();
        }
    }

    protected virtual void OnDeath()
    {
        isDead = true;
        Debug.Log("MOSTER DEATH");
        // col.enabled = false;
        // rb.isKinematic = false;
        destroyParticles.transform.parent = null;
        destroyParticles.Play();
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, 1f);
        Set(false);
    }

    protected void Set(bool set)
    {
        gameObject.SetActive(set);
    }
}
