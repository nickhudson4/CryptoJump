using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUI : MonoBehaviour
{
	public TextMeshProUGUI instructionTxt;

	public MenuGamewin gamewinMenu;
	public MenuGameover gameoverMenu;

	public Timer timer;
	public CoinCountUI coinCountUI;

	[SerializeField] private GameObject complimentUIPrefab;

	public void OnLevelStart()
	{
		coinCountUI.Set(true);
		coinCountUI.SetCount(0);
		timer.ResetTimer();
	}

	public void OnGameOver()
	{
		// gameoverMenu.Set(true);
		coinCountUI.Set(false);
	}

	public void OnGameWin()
	{
		gamewinMenu.Set(true, true);
		coinCountUI.Set(false);
		timer.Pause(true);
	}

	public void SetInstructionTxt(bool set)
	{
		instructionTxt.gameObject.SetActive(set);
	}


	public void ShowPopupTxt(Vector3 pos, string text)
    {
		pos.z = -2f;
        GameObject complimentGO = Instantiate(complimentUIPrefab, pos, Quaternion.identity);
        UIPopper complimentUIPopper = complimentGO.GetComponent<UIPopper>();

        complimentUIPopper.SetText(text);
        complimentUIPopper.Pop(0.5f, 20, 0.4f, 0.05f);
    }
}
