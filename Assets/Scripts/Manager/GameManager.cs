using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonManager<GameManager>
{
    public Player player;

    public Canvas canvas;
    public GameObject dialog;
    public Text nameText;
    public Text discText;

    public DamageText dt;

    public GameObject[] projectiles;

    public bool isPlay;

    
    public void SetActiveDialog(bool Active)
    {
        dialog.SetActive(Active);
    }
    public void SetDialogContent(string name, string disc)
    {
        nameText.text = name;
        discText.text = disc;
    }
    public void CreateDamage(Vector3 pos, int damage)
    {
        //Vector3 initPos = Camera.main.WorldToScreenPoint(pos);
        DamageText temp = Instantiate(dt, pos, Quaternion.identity, canvas.transform);
        temp.damageText.text = damage.ToString();
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
