using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitParticles;
    [SerializeField] private AudioClip coinSound;
    public int worth;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Player player = other.transform.parent.gameObject.GetComponent<Player>();
        if (player)
        {
            if (other.gameObject.tag == "FootCollider"){ return; }
            hitParticles.transform.parent = null;
            hitParticles.Play();
            gv.core.gameManager.OnCollectCoin(this);
            AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position, 1f);
            Set(false);
        }
    }

    public void Set(bool set)
    {
        gameObject.SetActive(set);
    }
}
