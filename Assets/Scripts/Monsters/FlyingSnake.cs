using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSnake : Monster
{
	protected int tweenID = -1;
	protected override void Start()
	{
		base.Start();
		transform.position -= new Vector3(1f, 0, 0);
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
			tweenID = LeanTween.moveX(gameObject, transform.position.x + 2f, 1f).setEase(LeanTweenType.easeInOutCubic).setLoopPingPong().id;
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		LeanTween.cancel(gameObject);
	}
}