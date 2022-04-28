using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MonsterSpawn : MonoBehaviour
{
    int count = 5;

    float timedurtion =  0;


    List<GameObjectBundle> objBundles = new List<GameObjectBundle>();

    [SerializeField]
    List<Transform> spawnTransform;

    [SerializeField]
    List<MonsterData> monsterDataList;

    public int monsterMax = 500;

    private void Awake()
    {
        Application.targetFrameRate = 40;

    }

    private void Start()
    {

        Init();
        StartCoroutine(SpawnRoutin());
        StartCoroutine(TimeRoutin());
        Debug.Log("시작");

    }

    



    public void Init()
    {
        foreach(var md in monsterDataList)
        {
            GameObjectBundle bundle = new GameObjectBundle();
            bundle.key = md.monsterName;
            bundle.prefabObj = md.monsterObj;
            bundle.count = md.count;
            bundle.maxCount = md.maxCount;
            objBundles.Add(bundle);
        }
       


        for(int i = 0; i < objBundles.Count; i++)
        {
            int count =  objBundles[i].count;

            ObjectPooling.Instance.AddObjects(objBundles[i].key, objBundles[i].prefabObj, objBundles[i].count);

        }



    }
    





    public void Spawn(string key , int count)
    {
       var go = objBundles.Find(x => x.key == key);

       var objs =  ObjectPooling.Instance.objectsDictionary[key];




        if(go != null)
        {

            for (int i = 0; i < count; i++)
            {
                int randomIndex = (int)Random.Range(0, spawnTransform.Count);
                int randomPosX = Random.Range(0, 3);
                int randomPosY = Random.Range(0, 3);
                GameObject monster = ObjectPooling.Instance.ObjectUse(key);
                if(monster == null) {
                    return;
                }


                monster.transform.position =
                    new Vector2( spawnTransform[randomIndex].position.x + randomPosX , spawnTransform[randomIndex].position.y + randomPosY) ;
                monster.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);


            }

        }

    }

    IEnumerator SpawnRoutin()
    {
        WaitForSeconds second = new WaitForSeconds(2f);
        while(true){

            if (ObjectPooling.Instance.monstorCount < monsterMax)
            {


                int index = (int)Random.Range(0, objBundles.Count);
                Spawn(objBundles[index].key, count);
            }

            yield return second;

        }


    }

    IEnumerator TimeRoutin()
    {

        float time = 0;

        while (true)
        {
            if(time >= timedurtion)
            {
                count += 5;
                timedurtion += 30f;
            }
            
            time += Time.deltaTime;

            yield return null;
        }
    }


}

[System.Serializable]
public class GameObjectBundle
{
    public string key;
    public GameObject prefabObj;
    public int count;
    public int maxCount;

}