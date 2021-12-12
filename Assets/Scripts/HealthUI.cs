using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> hearts;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetHealth(int health)
    {
        int removeHearts = GameManager.TOTAL_LIVES - health;
        for (int i = 0; i < removeHearts; i++)
        {
            hearts[i].SetActive(false);
        }
    }

    public void ResetHealth()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    public void Set(bool set)
    {
        gameObject.SetActive(set);
    }
}
