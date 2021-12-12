using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level : MonoBehaviour
{
    public Transform startPos;
    public List<Monster> monsters;
    public ParticleSystem showerParticles;
    public Color playerBounceParticleColor;
    public List<Coin> coins;

    void Start()
    {
        showerParticles.transform.parent = gv.core.cameraController.transform;
        StartCoroutine(DelayedStart(0.1f));
    }

    public IEnumerator DelayedStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        monsters = GameObject.FindObjectsOfType<Monster>().ToList();
		coins = FindObjectsOfType<Coin>().ToList();
    }

    void Update()
    {
        
    }

    public void OnPause(bool pause)
    {
        foreach (Monster m in monsters)
        {
            m.OnPause(pause);
        }
    }

    public void DestroyLevel()
    {
        Destroy(showerParticles);
        Destroy(gameObject);
    }
}
