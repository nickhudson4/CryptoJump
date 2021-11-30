using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCountUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countTxt;

    public void SetCount(int count)    
    {
        countTxt.text = Utils.IntToString(count);
    }

    public void Set(bool set)
    {
        gameObject.SetActive(set);
    }

}
