using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOneHitBreak : Platform
{
    [SerializeField] private ParticleSystem destroyParticles;
    [SerializeField] private AudioClip jumpSound;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();    
    }

    protected override void OnHit(Player player)
    {
        base.OnHit(player);
        player.Jump(jumpForce);
        destroyParticles.transform.parent = null;
        destroyParticles.Play();
        AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position, 0.6f);
        Set(false);
    }
}
