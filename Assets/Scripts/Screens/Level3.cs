using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : SceneBase
{
    private List<GameObject> objPrefab = new List<GameObject>();
    public List<GameObject> obj = new List<GameObject>();
    public List<Vector3> initPos = new List<Vector3>();

    private void Awake()
    {
        initPos.Add(new Vector3(-2.2f, -2.4f, 0));
        initPos.Add(new Vector3(4.5f, -2.4f, 0));
        initPos.Add(new Vector3(27.3f, 1.6f, 0));
        //        initPos.Add(new Vector3(29.1f, -2.4f, 0));
        //        initPos.Add(new Vector3(35.5f, -2.4f, 0));
    }

    public override void SetPrefab(GameObject _player, GameObject _red, GameObject _blue)
    {
        objPrefab.Add(_player);
        objPrefab.Add(_red);
        objPrefab.Add(_blue);
    }

    public override void CreateLevel(List<Vector3> pos)
    {
        for (int i = 0; i < objPrefab.Count; i++)
        {
            Instantiate(objPrefab[i], pos[i], Quaternion.identity);
        }
    }

    public override void CreateLevel()
    {
        for (int i = 0; i < objPrefab.Count; i++)
        {
            var go = Instantiate(objPrefab[i], initPos[i], Quaternion.identity);
            obj.Add(go);
        }
    }

    public override List<Vector3> GetPositions()
    {
        List<Vector3> res = new List<Vector3>();

        for (int i = 0; i < obj.Count; i++)
            res.Add(obj[i].transform.position);

        return res;
    }
}
