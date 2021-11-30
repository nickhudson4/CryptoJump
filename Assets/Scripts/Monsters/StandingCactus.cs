using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingCactus : Monster
{
	protected int tweenID = -1;
	protected override void Start()
	{
		base.Start();
		transform.position -= new Vector3(0.25f, 0, 0);
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
			tweenID = LeanTween.moveX(gameObject, transform.position.x + 0.5f, .5f).setLoopPingPong().id;
			tweenID = LeanTween.moveY(gameObject, transform.position.y + 0.25f, .25f).setLoopPingPong().id;
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		LeanTween.cancel(gameObject);
	}
}