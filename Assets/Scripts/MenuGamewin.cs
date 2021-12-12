using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class MenuGamewin : Menu
{
	[SerializeField] private TextMeshProUGUI coinCountTxt;
	[SerializeField] private Image coinCountFill;
	private int numTotalCoins;

	public override void Set(bool set, bool fade = false)
	{
		base.Set(set, fade);
		transform.position += new Vector3 (0, 2000, 0);
		LeanTween.moveY(gameObject, transform.position.y - 2000, 0.5f).setEase(LeanTweenType.easeOutQuart);
		if (set)
		{
			SetupCoinCountBar();
			StartCoroutine(CountCoins());
		}
	}

	private void SetupCoinCountBar()
	{
		numTotalCoins = 0;
		foreach (Coin coin in gv.core.gameManager.GetCurrentLevel().coins)
		{
			if (coin == null){ continue; }
			numTotalCoins += coin.worth;
		}
		coinCountTxt.text = "0/" + Utils.IntToString(numTotalCoins);
		coinCountFill.fillAmount = 0;
	}

	private IEnumerator CountCoins()
	{
		for (int i = 1; i <= gv.core.gameManager.coinsCollectedThisLevel; i++)
		{
			float fill = (float)i / (float)numTotalCoins;
			coinCountFill.fillAmount = fill;
			coinCountTxt.text = i + "/" + Utils.IntToString(numTotalCoins);

			if (i % 10 == 0)
			{ 
				var seq = LeanTween.sequence();
				seq.append(LeanTween.scale(coinCountTxt.gameObject, new Vector3 (1.5f, 1.5f, 1.5f), 0.2f));
				seq.append(LeanTween.scale(coinCountTxt.gameObject, new Vector3 (1f, 1f, 1f), 0.2f));
			}

			yield return new WaitForSeconds(0.02f);
		}
		yield return new WaitForSeconds(1f);
		var seq2 = LeanTween.sequence();
		seq2.append(LeanTween.scale(gv.core.mainUI.timer.gameObject, new Vector3 (1.5f, 1.5f, 1.5f), 0.2f));
		seq2.append(LeanTween.scale(gv.core.mainUI.timer.gameObject, new Vector3 (1f, 1f, 1f), 0.2f));
		
	}
}
