using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TitleManager : MonoBehaviour
{
    public Image fadeoutImg;

    public GameObject optionDialog;
    public Slider effectVolume;
    public Slider musicVolume;

    public AudioMixer mixer;

    private void Start()
    {
        float effect = PlayerPrefs.GetFloat("Effect");
        float bgm = PlayerPrefs.GetFloat("BGM");

        mixer.SetFloat("Effect", effect);
        mixer.SetFloat("BGM", bgm);
        effectVolume.value = effect;
        musicVolume.value = bgm;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            print("종료 키 누름");
            ExitBtn();
        }
    }
    public void InGameStart()
    {
        StartCoroutine("FadeOut");
        Invoke("SceneChange", 1f);   
    }
    public void ExitBtn()
    {
        StartCoroutine("FadeOut");
        Invoke("GameExit", 1f);

    }
    public void OptionBtn()
    {
        optionDialog.SetActive(!optionDialog.activeSelf);
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("InGameScene");
    }
    public void GameExit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void SetEffectVolume(float value)
    {
        float sound = effectVolume.value;

        if (sound == -40f) mixer.SetFloat("Effect", -80);
        else mixer.SetFloat("Effect", sound);

        PlayerPrefs.SetFloat("Effect", sound);
    }
    public void SetBGMVolume(float value)
    {
        float sound = musicVolume.value;

        if (sound == -40f) mixer.SetFloat("BGM", -80);
        else mixer.SetFloat("BGM", sound);

        PlayerPrefs.SetFloat("BGM", sound);
    }
    IEnumerator FadeOut()
    {
        float curTime = 0;
        while (true)
        {
            curTime += Time.deltaTime;
            fadeoutImg.color = new Color(fadeoutImg.color.r, fadeoutImg.color.g, fadeoutImg.color.b, curTime/1);
            if (curTime >= 1)
            {
                yield break;
            }
            yield return null;
        }
    }
    
}
