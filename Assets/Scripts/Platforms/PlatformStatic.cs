using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStatic : Platform
{
    [SerializeField] private ParticleSystem bounceParticles;
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
        if (!isLastPlatform) player.Jump(jumpForce);
        bounceParticles.transform.position = new Vector3(player.transform.position.x, bounceParticles.transform.position.y, bounceParticles.transform.position.z);
        bounceParticles.Play();
    }
}
