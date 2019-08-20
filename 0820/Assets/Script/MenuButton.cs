using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {

    private AudioSource audio;
    public AudioClip selectMenu;
    public AudioClip selectBack;

    public GameObject Menu;
    public GameObject Stage;
    public GameObject Option;
    public GameObject AudioMgr;

    void Start()
    {
        //GameObject.Find("OptionWindow")/*.transform.GetChild(0)*/.gameObject.SetActive(false);
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = selectMenu;
        audio.loop = false;
        audio.volume = AudioMgr.GetComponent<SoundManager>().EffectVol;
    }

    // 시작 화면
    // start
    public void OnEnterStartButton()
    {
        audio.clip = selectMenu;
        audio.volume = AudioMgr.GetComponent<SoundManager>().EffectVol;
        audio.Play();
        GameObject.Find("StartImage").transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Debug.Log("Enter Start Button");
    }

    public void OnExitStartButton()
    {
        GameObject.Find("StartImage").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Start Button");
    }

    public void OnClickStartButton()
    {
        GameObject.Find("StartImage").transform.GetComponent<Image>().color = Color.gray;
        Stage.SetActive(true);
        Menu.SetActive(false);
        GameObject.Find("Back2").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.Find("Back2").transform.GetComponent<Image>().color = Color.white;
        Debug.Log("Start Button Click");
    }

    public void OnUpStartButton()
    {
        //SceneManager.LoadScene("CLUE_Map1");
    }

    // option
    public void OnEnterOptionButton()
    {
        audio.clip = selectMenu;
        audio.volume = AudioMgr.GetComponent<SoundManager>().EffectVol;
        audio.Play();
        GameObject.Find("OptionImage").transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Debug.Log("Enter Option Button");

        //if()
    }

    public void OnExitOptionButton()
    {
        GameObject.Find("OptionImage").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Option Button");
    }

    public void OnClickOptionButton()
    {
        GameObject.Find("OptionImage").transform.GetComponent<Image>().color = Color.gray;
        Menu.SetActive(false);
        Option.gameObject.SetActive(true);
        GameObject.Find("Back").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.Find("Back").transform.GetComponent<Image>().color = Color.white;
        Debug.Log("Option Button Click");
    }

    public void OnUpOptionButton()
    {
        //GameObject.Find("MenuWindow").transform.GetChild(0).gameObject.SetActive(false);
        //GameObject.Find("OptionWindow").transform.GetChild(0).gameObject.SetActive(true);
    }

    // Exit
    public void OnEnterExitButton()
    {
        audio.clip = selectMenu;
        audio.volume = AudioMgr.GetComponent<SoundManager>().EffectVol;
        audio.Play();
        GameObject.Find("ExitImage").transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Debug.Log("Enter Exit Button");
    }

    public void OnExitExitButton()
    {
        GameObject.Find("ExitImage").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Exit Button");
    }

    public void OnClickExitButton()
    {
        GameObject.Find("ExitImage").transform.GetComponent<Image>().color = Color.gray;
        Application.Quit();
        Debug.Log("Exit Button Click");
    }

    public void OnUpExitButton()
    {
        //Application.Quit();
    }


    // 옵션 창
    public void OnEnterBackButton()
    {
        audio.clip = selectBack;
        audio.volume = AudioMgr.GetComponent<SoundManager>().EffectVol;
        audio.Play();
        GameObject.Find("Back").transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Debug.Log("Enter Back Button");
    }

    public void OnExitBackButton()
    {
        GameObject.Find("Back").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Back Button");
    }

    public void OnClickBackButton()
    {
        GameObject.Find("Back").transform.GetComponent<Image>().color = Color.gray;
        Menu.SetActive(true);
        Option.gameObject.SetActive(false);
        Stage.SetActive(false);
        GameObject.Find("StartImage").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.Find("StartImage").transform.GetComponent<Image>().color = Color.white;
        GameObject.Find("OptionImage").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.Find("OptionImage").transform.GetComponent<Image>().color = Color.white;
        Debug.Log("Back Button Click");
    }

    public void OnUpBackButton()
    {
        //GameObject.Find("MenuWindow").transform.GetChild(0).gameObject.SetActive(true);
        //GameObject.Find("OptionWindow").transform.GetChild(0).gameObject.SetActive(false);
    }


    // 스테이지 선택 창
    public void OnEnterStage1Button()
    {
        audio.clip = selectMenu;
        audio.volume = AudioMgr.GetComponent<SoundManager>().EffectVol;
        audio.Play();
        GameObject.Find("Stage1").transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        GameObject.Find("Stage1").transform.GetComponent<Image>().color = Color.gray;
        Debug.Log("Enter Stage1 Button");
    }

    public void OnExitStage1Button()
    {
        GameObject.Find("Stage1").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.Find("Stage1").transform.GetComponent<Image>().color = Color.white;
        Debug.Log("Stage1 Back Button");
    }

    public void OnClickStage1Button()
    {
        LoadingManager.LoadScene("CLUE_Map1");
        //SceneManager.LoadScene("CLUE_Map1");
        Debug.Log("Stage1 Button Click");
    }

    public void OnEnterStage2Button()
    {
        audio.clip = selectMenu;
        audio.volume = AudioMgr.GetComponent<SoundManager>().EffectVol;
        audio.Play();
        GameObject.Find("Stage2").transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        GameObject.Find("Stage2").transform.GetComponent<Image>().color = Color.gray;
        Debug.Log("Enter Stage2 Button");
    }

    public void OnExitStage2Button()
    {
        GameObject.Find("Stage2").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.Find("Stage2").transform.GetComponent<Image>().color = Color.white;
        Debug.Log("Stage2 Back Button");
    }

    public void OnClickStage2Button()
    {
        LoadingManager.LoadScene("CLUE_Map2");
        //SceneManager.LoadScene("CLUE_Map2");
        Debug.Log("Stage2 Button Click");
    }

    public void OnEnterBack2Button()
    {
        audio.clip = selectBack;
        audio.volume = AudioMgr.GetComponent<SoundManager>().EffectVol;
        audio.Play();
        GameObject.Find("Back2").transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Debug.Log("Enter Back Button");
    }

    public void OnExitBack2Button()
    {
        GameObject.Find("Back2").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Back Button");
    }

    public void OnClickBack2Button()
    {
        GameObject.Find("Back2").transform.GetComponent<Image>().color = Color.gray;
        Menu.SetActive(true);
        Option.gameObject.SetActive(false);
        Stage.SetActive(false);
        GameObject.Find("StartImage").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.Find("StartImage").transform.GetComponent<Image>().color = Color.white;
        GameObject.Find("OptionImage").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.Find("OptionImage").transform.GetComponent<Image>().color = Color.white;
        Debug.Log("Back Button Click");
    }
}
