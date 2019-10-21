using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Vector3 respawnPosition = Vector3.zero;
    [HideInInspector] public GameObject player;
    private Text[] textArray;
    private GameObject myCanvas;

    private void Awake()
    {
        player = GameObject.Find("Player");

        myCanvas = GameObject.Find("Canvas");
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
        player.GetComponent<Player>().speedUp = 1.0f;
    }

    public void ShowHUD()
    {
        textArray[0].transform.position = new Vector2(Screen.width / 2 - 100, Screen.height - 50);
        textArray[1].transform.position = new Vector2(Screen.width / 2 + 250, Screen.height - 50);

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
        if (Input.GetKey("escape")) Application.Quit();
    }
}
