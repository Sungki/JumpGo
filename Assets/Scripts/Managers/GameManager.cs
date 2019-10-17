using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 respawnPosition = Vector3.zero;
    [HideInInspector] public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public void SetRespawnPos(Vector3 pos)
    {
        respawnPosition = pos;
    }

    public void RespawnPlayer()
    {
        if(!player) player = GameObject.Find("Player");

        player.transform.position = respawnPosition;
    }
}
