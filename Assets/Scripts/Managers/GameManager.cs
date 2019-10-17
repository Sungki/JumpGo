using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Vector3 respawnPosition = Vector3.zero;
    [HideInInspector] public GameObject player;
    private Text[] textArray;

    private void Start()
    {
        player = GameObject.Find("Player");

        GameObject myCanvas = GameObject.Find("Canvas");
        textArray = myCanvas.GetComponentsInChildren<Text>();
        DontDestroyOnLoad(myCanvas);
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

    public void ShowHUD()
    {
        textArray[0].text = transform.parent.GetComponentInChildren<StatManager>().GetPlayerLife();
        textArray[1].text = transform.parent.GetComponentInChildren<StatManager>().GetScore();
    }

    public void InitText()
    {
        textArray[0].text = null;
        textArray[1].text = null;
        textArray[2].text = null;
    }

    private void Update()
    {
        ShowHUD();
    }
}
