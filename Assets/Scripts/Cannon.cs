using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform shootFrom;
    [SerializeField] private ParticleSystem shootParticles;
    private int tweenID = -1;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Shoot(Vector3 dir)
    {
        LeanTween.cancel(gameObject);
        transform.up = dir;

		var seq = LeanTween.sequence();
		seq.append(LeanTween.scaleY(gameObject, 0.65f, 0.008f));
		seq.append(LeanTween.scaleY(gameObject, 1f, 0.2f));

        shootParticles.Play();
    }

    public void ResetRotation()
    {
        LeanTween.rotateZ(gameObject, 0, .5f);
    }
}
