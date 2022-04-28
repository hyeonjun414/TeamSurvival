using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonManager<GameManager>
{
    public Player player;

    public GameObject[] projectiles;

    public bool isPlay;
    public float playTime;

    public UIManager uiManager;
    public Canvas worldCanvas;
    public FloatingText floatText;
    private void Start()
    {
        Application.targetFrameRate = 60;
        ObjectPooling.Instance.AddObjects(floatText.key, floatText.gameObject, 200);
    }
    private void Update()
    {
        if(isPlay)
            playTime += Time.deltaTime;

    }
    private void FixedUpdate()
    {
        string str = string.Format("{0:D2} : {1:D2}", (int)playTime / 60, (int)playTime % 60);
        uiManager.curTime.text = str;//((int)playTime).ToString();
    }

    public void CreateDamage(Vector3 pos, int damage)
    {
        GameObject obj = ObjectPooling.Instance.ObjectUse(floatText.key);
        obj.transform.position = pos;
        FloatingText txt = obj.GetComponent<FloatingText>();
        txt.damageText.text = damage.ToString();
        obj.transform.SetParent(worldCanvas.gameObject.transform);
    }

    public void PlayGame()
    {
        isPlay = true;
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        isPlay = false;
        Time.timeScale = 0;
    }

    public void TalentSelect(TalentData data)
    {
        player.TalentApply(data);
    }

}
