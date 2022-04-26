using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MonsterSpawn : MonoBehaviour
{

    [SerializeField]
    List<GameObjectBundle> objBundles;

    [SerializeField]
    List<Transform> spawnTransform;


    private void Start()
    {

        Init();
        StartCoroutine(SpawnRoutin());

    }
    public void Init()
    {
        for(int i = 0; i < objBundles.Count; i++)
        {
            int count =  objBundles[i].count;

            ObjectPooling.Instacne.AddObjects(objBundles[i].key, objBundles[i].prefabObj, objBundles[i].count);

        }



    }
    





    public void Spawn(string key , int count)
    {
       var go = objBundles.Find(x => x.key == key);

       var objs =  ObjectPooling.Instacne.objectsDictionary[key];

       ObjectPoolConfig[] objCon =  FindObjectsOfType<ObjectPoolConfig>();
        int totalCount = 0;
        for(int i = 0; i < objCon.Length; i++)
        {
            if(key == objCon[i].key)
            {
                totalCount++;

            }


        }


        

        if(totalCount > go.maxCount)
        {


            return;
        }



        if(go != null)
        {

            for (int i = 0; i < count; i++)
            {
                int randomIndex = (int)Random.Range(0, spawnTransform.Count);
                int randomPosX = Random.Range(0, 3);
                int randomPosY = Random.Range(0, 3);
                GameObject monster = ObjectPooling.Instacne.ObjectUse(key);
                monster.transform.position =
                    new Vector2( spawnTransform[randomIndex].position.x + randomPosX , spawnTransform[randomIndex].position.y + randomPosY) ;

            }

        }

    }

    IEnumerator SpawnRoutin()
    {
        WaitForSeconds second = new WaitForSeconds(3f);
        while(true){



            Spawn("Chort", 10);
            Spawn("Img", 20);

            yield return second;

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