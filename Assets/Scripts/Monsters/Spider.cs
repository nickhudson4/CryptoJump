using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Monster
{
	[SerializeField] private Transform connectWebTo;
	[SerializeField] private LineRenderer web;
	protected int tweenID = -1;
	protected override void Start()
	{
		base.Start();
	}

	protected override void Update()
	{
		base.Update();
		if (!isDead)
		{ 
			UpdateWeb();
			Move(); 
		}
	}

	private void Move()
	{
		if (!LeanTween.isTweening(tweenID))
		{
			tweenID = LeanTween.moveY(gameObject, transform.position.y - 2f, 1f).setLoopPingPong().id;
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		LeanTween.cancel(gameObject);
	}

	private void UpdateWeb()
	{
		Vector3[] points = new Vector3[]{transform.position, connectWebTo.position};
		web.SetPositions(points);
	}
}