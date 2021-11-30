using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DanielLochner.Assets.SimpleScrollSnap;

public class MenuStart : Menu
{
	[SerializeField] private GameObject heroesContainer;
	[SerializeField] private SimpleScrollSnap simpleScrollSnap;
	public void OnClickStart()
	{
		Debug.Log("Target: " + simpleScrollSnap.TargetPanel);
		gv.heroPrefab = heroesContainer.transform.GetChild(simpleScrollSnap.TargetPanel).GetComponent<HeroScrollItem>().correspondingHeroPrefab;
		SceneManager.LoadScene("Main");
		// GameObject prefab = null;
		// float closestDist = float.MaxValue;
		// for (int i = 0; i < heroesContainer.transform.childCount; i++)
		// {
		// 	HeroScrollItem hero = heroesContainer.transform.GetChild(i).GetComponent<HeroScrollItem>();
		// 	float dist = Vector2.Distance(Vector2.zero, hero.transform.position);
		// 	if (dist < closestDist)
		// 	{
		// 		closestDist = dist;
		// 		prefab = hero.correspondingHeroPrefab;
		// 	}
		// }
	}
}

