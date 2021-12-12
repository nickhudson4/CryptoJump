using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBug : Monster
{	
	protected int tweenID = -1;
	protected override void Start()
	{
		base.Start();
	}

	protected override void Update()
	{
		base.Update();
		if (!isDead){ Move(); }
	}

	private void Move()
	{
		if (!LeanTween.isTweening(tweenID))
		{
			tweenID = LeanTween.moveY(gameObject, transform.position.y + .5f, .2f).setLoopPingPong().id;
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		LeanTween.cancel(gameObject);
	}
}