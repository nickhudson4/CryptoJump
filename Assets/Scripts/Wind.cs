using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float speed;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        mat.SetTextureOffset("_MainTex", mat.GetTextureOffset("_MainTex") + new Vector2((-speed)*Time.deltaTime, 0));
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Player player = other.transform.parent.gameObject.GetComponent<Player>();
        if (player && other.gameObject.tag == "BodyCollider")
        {
            if (player.isImmune){ return; }
            ConstantForce2D constantForce2D = player.gameObject.AddComponent<ConstantForce2D>();
            constantForce2D.force = new Vector2(speed * 5, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        Player player = other.transform.parent.gameObject.GetComponent<Player>();
        if (player && other.gameObject.tag == "BodyCollider")
        {
            ConstantForce2D constantForce = player.GetComponent<ConstantForce2D>();
            if (constantForce){ Destroy(constantForce); }
        }
    }
}
