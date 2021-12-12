using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUI : MonoBehaviour
{
	public TextMeshProUGUI instructionTxt;
	public TextMeshProUGUI lvlText;

	public MenuGamewin gamewinMenu;
	public MenuGameover gameoverMenu;

	public ControlsUI controlsUI;
	public HealthUI healthUI;

	public Timer timer;
	public CoinCountUI coinCountUI;
	public Crosshair crosshair;

	[SerializeField] private GameObject complimentUIPrefab;

	public void OnLevelStart() 
	{
		coinCountUI.Set(true);
		timer.ResetTimer();
		lvlText.gameObject.SetActive(true);
		crosshair.Set(true);
	}

	public void OnGameplayStart()
	{
		timer.Set(true);
		timer.StartTimer();
		controlsUI.Set(true);
	}

	public void OnGameOver()
	{
		gameoverMenu.Set(true, true);
		timer.Pause(true);
		controlsUI.Set(false);
		crosshair.Set(false);
	}

	public void OnGameWin()
	{
		gamewinMenu.Set(true, true);
		timer.Pause(true);
		controlsUI.Set(false);
		crosshair.Set(false);
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

	public void OnPause(bool pause)
	{
		timer.Pause(pause);
	}
}
