using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;

public class LevelManager : MonoBehaviour
{
    private SceneState currentState = 0;
    Stack<GameObject> sceneStack = new Stack<GameObject>();
    List<Vector3> temporaryPos = new List<Vector3>();

    GameObject redGuyPrefab;
    GameObject blueGuyPrefab;
    GameObject playerPrefab;

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

        if(temporaryPos.Count==0)
        {
            sceneStack.Peek().GetComponent<T>().CreateLevel();
        }
        else
        {
            sceneStack.Peek().GetComponent<T>().CreateLevel(temporaryPos);
            temporaryPos.Clear();
        }
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

    public void CapturePos()
    {
        switch (currentState)
        {
            case SceneState.Level1:
                temporaryPos = new List<Vector3>(sceneStack.Peek().GetComponent<Level1>().GetPositions());
                break;
            case SceneState.Level2:
                temporaryPos = new List<Vector3>(sceneStack.Peek().GetComponent<Level2>().GetPositions());
                break;
            case SceneState.Level3:
                temporaryPos = new List<Vector3>(sceneStack.Peek().GetComponent<Level3>().GetPositions());
                break;
            default:
                break;
        }
    }

    public void CurrentScreen()
    {
        StartCoroutine(LoadScene());
    }

    public void GotoScreen(string screen)
    {
        SceneManager.LoadScene(screen);
    }
}
