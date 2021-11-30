using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    public CanvasGroup cg;
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }

	public void OnClickMainMenu()
	{
        gv.core.LoadNewScene("StartMenu");
	}

    public void OnClickNextLevel()
    {
        gv.core.gameManager.RetryLevel();
        Set(false);
    }

    public virtual void Set(bool set, bool fade = false)
    {
        if (fade && cg)
        {
            if (set){ gameObject.SetActive(set); } //have to make active before doing fade in. (not for fade out)
            StartCoroutine(Utils.C_FadeCanvasGroup(cg, 2, !set));
            return;
        }
        gameObject.SetActive(set);
    }
}
