using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [HideInInspector] public Player player;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public Player SpawnPlayer(GameObject prefab)
    {
        if (player){ Destroy(player.gameObject); }
        player = Instantiate(prefab, gv.core.gameManager.GetCurrentLevel().startPos.position, Quaternion.identity).GetComponent<Player>();
        return player;
    }
}
