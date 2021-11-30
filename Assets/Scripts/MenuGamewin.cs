using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuGamewin : Menu
{
	[SerializeField] private TextMeshProUGUI coinCountTxt;

	public override void Set(bool set, bool fade = false)
	{
		base.Set(set, fade);
		if (set)
		{
			StartCoroutine(CountCoins());

		}
	}

	private IEnumerator CountCoins()
	{
		for (int i = 1; i <= gv.core.gameManager.coinCount; i++)
		{
			coinCountTxt.text = Utils.IntToString(i);

			if (i % 10 == 0)
			{ 
				var seq = LeanTween.sequence();
				seq.append(LeanTween.scale(coinCountTxt.gameObject, new Vector3 (1.5f, 1.5f, 1.5f), 0.2f));
				seq.append(LeanTween.scale(coinCountTxt.gameObject, new Vector3 (1f, 1f, 1f), 0.2f));
			}

			yield return new WaitForSeconds(0.03f);
		}
		yield return new WaitForSeconds(1f);
		var seq2 = LeanTween.sequence();
		seq2.append(LeanTween.scale(gv.core.mainUI.timer.gameObject, new Vector3 (1.5f, 1.5f, 1.5f), 0.2f));
		seq2.append(LeanTween.scale(gv.core.mainUI.timer.gameObject, new Vector3 (1f, 1f, 1f), 0.2f));
		
	}
}
