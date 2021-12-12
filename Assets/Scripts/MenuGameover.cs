using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuGameover : Menu
{
	[SerializeField] private GameObject heartLeft;
	[SerializeField] private GameObject heartRight;

	public override void Set(bool set, bool fade = false)
	{
		base.Set(set, fade);
		transform.position += new Vector3 (0, 2000, 0);
		LeanTween.moveY(gameObject, transform.position.y - 2000, 0.5f).setEase(LeanTweenType.easeOutQuart);
		if (set)
		{
			// PlayHeartAnim();
		}
	}

	public void PlayHeartAnim()
	{
		LeanTween.rotateZ(heartLeft, 7, 0.6f);
		LeanTween.moveX(heartLeft, transform.position.x - 70, 0.6f);
		LeanTween.rotateZ(heartRight, -7, 0.6f);
		LeanTween.moveX(heartRight, transform.position.x + 70, 0.6f);
	}

}
