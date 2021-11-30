using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalse : Platform
{
    [SerializeField] private Rigidbody2D leftPieceRB;
    [SerializeField] private Rigidbody2D rightPieceRB;

    private int tweenID = -1;
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
        Break();
    }

    private void Break()
    {
        leftPieceRB.isKinematic = false;
        // leftPieceRB.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        rightPieceRB.isKinematic = false;
        // rightPieceRB.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        tweenID = LeanTween.rotateAround(leftPieceRB.gameObject, -Vector3.forward, 90, Random.Range(1f, 3f)).id;
        tweenID = LeanTween.rotateAround(rightPieceRB.gameObject, Vector3.forward, 90, Random.Range(1f, 3f)).id;
    }


}
