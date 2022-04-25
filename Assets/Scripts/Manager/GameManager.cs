using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
                instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }
    private void Awake()
    {
        instance = this;

    }

    public Canvas canvas;
    public GameObject dialog;
    public Text nameText;
    public Text discText;

    public DamageText dt;

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
}
