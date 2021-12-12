using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : Platform
{
    public enum Type
    {
        HORIZONTAL,
        VERTICAL,
    }
    public Type type;
    [SerializeField] private ParticleSystem bounceParticles;
    [SerializeField] private float speed;
    [SerializeField] private float minBound;
    [SerializeField] private float maxBound;
    [SerializeField] private float iter = 1;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();    
        Move();
    }

    private void Move()
    {
        switch (type)
        {
            case Type.HORIZONTAL:
            {
                if ((iter > 0 && transform.position.x > maxBound) || (iter < 0 && transform.position.x < minBound))
                {
                    iter = -iter;
                }
                transform.position += new Vector3(iter * (speed * Time.deltaTime), 0, 0);
                break;
            }
            case Type.VERTICAL:
            {
                if ((iter > 0 && transform.position.y > maxBound) || (iter < 0 && transform.position.y < minBound))
                {
                    iter = -iter;
                }
                transform.position += new Vector3(0, iter * (speed * Time.deltaTime), 0);
                break;
            }
        }
    }

    protected override void OnHit(Player player)
    {
        base.OnHit(player);
        if (!isLastPlatform) player.Jump(jumpForce);
        bounceParticles.transform.position = new Vector3(player.transform.position.x, bounceParticles.transform.position.y, bounceParticles.transform.position.z);
        bounceParticles.Play();
    }
}
