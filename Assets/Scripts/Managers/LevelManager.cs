using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;

public class LevelManager : MonoBehaviour
{
    private SceneState currentState = 0;
    Stack<GameObject> sceneStack = new Stack<GameObject>();

    GameObject redGuyPrefab;
    GameObject blueGuyPrefab;
    GameObject playerPrefab;

    public bool IsLevelScene()
    {
        if (currentState == SceneState.StartScreen || currentState == SceneState.EndScreen)
            return false;
        else
            return true;
    }

    private void Awake()
    {
        redGuyPrefab = Resources.Load<GameObject>("RedGuy");
        blueGuyPrefab = Resources.Load<GameObject>("BlueGuy");
        playerPrefab = Resources.Load<GameObject>("Player");

        Init();
    }

    public void Init()
    {
        currentState = SceneState.StartScreen;
    }

    public void NextLevel()
    {
        if (currentState == SceneState.EndScreen) Init();
        else
        {
            currentState++;
        }

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(currentState.ToString());
        while (!op.isDone)
        {
            yield return null;
        }

        switch(currentState)
        {
            case SceneState.Level1:
                CreateLevel<Level1>();
                break;
            case SceneState.Level2:
                CreateLevel<Level2>();
                break;
            case SceneState.Level3:
                CreateLevel<Level3>();
                break;
            default:
                break;
        }
    }

    private void CreateLevel<T>() where T : SceneBase
    {
        var go = new GameObject(typeof(T).ToString());
        PushScene(go);

        sceneStack.Peek().transform.parent = this.gameObject.transform;
        sceneStack.Peek().AddComponent<T>().SetPrefab(playerPrefab, redGuyPrefab, blueGuyPrefab);
        sceneStack.Peek().GetComponent<T>().CreateLevel();
    }

    private void PushScene(GameObject go)
    {
        if (sceneStack.Count > 0)
        {
            sceneStack.Pop();
            GameObject.Destroy(transform.GetChild(0).gameObject);
        }
        sceneStack.Push(go);
    }

    public void CurrentScreen()
    {
        StartCoroutine(LoadScene());
    }

    public void GotoScreen(string screen)
    {
        if(screen == "EndScreen") currentState = SceneState.EndScreen;
        SceneManager.LoadScene(screen);
    }
}
