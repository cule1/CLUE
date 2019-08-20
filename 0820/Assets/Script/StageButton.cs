using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StageButton : MonoBehaviour {

    public GameObject MenuCanvas;
    public GameObject OptionCanvas;
    public Slider EffectSlider;

    public AudioClip selectMenu;
    public AudioClip selectBack;

    private AudioSource audio;
    private float EffectVolume;

    // Use this for initialization
    void Start ()
    {
        EffectVolume = 0.5f;

        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = selectMenu;
        audio.loop = false;
        audio.volume = EffectVolume;
    }
	
	// Update is called once per frame
	void Update () {
        EffectVolume = EffectSlider.value;
    }

    // play
    public void OnEnterPlayButton()
    {
        audio.clip = selectMenu;
        audio.volume = EffectVolume;
        audio.Play();
        GameObject.Find("PlayButton").transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        Debug.Log("Enter Play Button");
    }

    public void OnExitPlayButton()
    {
        GameObject.Find("PlayButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Play Button");
    }

    public void OnDownPlayButton()
    {
        GameObject.Find("PlayButton").transform.GetComponent<Image>().color = Color.gray;
        Debug.Log("Play Button Down");
    }

    public void OnUpPlayButton()
    {
        GameObject.Find("PlayButton").transform.GetComponent<Image>().color = Color.white;
        GameObject.Find("PlayButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.Find("Timer").transform.GetComponent<Pause>().IsPause = false;
        Time.timeScale = 1;
        Debug.Log("Play Button Up");
    }


    // pause
    public void OnEnterPauseButton()
    {
        audio.clip = selectMenu;
        audio.volume = EffectVolume;
        audio.Play();
        GameObject.Find("PauseButton").transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        Debug.Log("Enter Pause Button");
    }

    public void OnExitPauseButton()
    {
        GameObject.Find("PauseButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Pause Button");
    }

    public void OnDownPauseButton()
    {
        GameObject.Find("PauseButton").transform.GetComponent<Image>().color = Color.gray;
        Debug.Log("Pause Button Down");
    }

    public void OnUpPauseButton()
    {
        GameObject.Find("PauseButton").transform.GetComponent<Image>().color = Color.white;
        GameObject.Find("PauseButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameObject.Find("Timer").transform.GetComponent<Pause>().IsPause = true;
        Time.timeScale = 0;
        Debug.Log("Pause Button Up");
    }


    // back
    public void OnEnterBackButton()
    {
        audio.clip = selectMenu;
        audio.volume = EffectVolume;
        audio.Play();
        GameObject.Find("BackButton").transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        Debug.Log("Enter Back Button");
    }

    public void OnExitBackButton()
    {
        GameObject.Find("BackButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Back Button");
    }

    public void OnDownBackButton()
    {
        GameObject.Find("BackButton").transform.GetComponent<Image>().color = Color.gray;
        Debug.Log("Back Button Down");
    }

    public void OnUpBackButton()
    {
        GameObject.Find("BackButton").transform.GetComponent<Image>().color = Color.white;
        GameObject.Find("BackButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (Time.timeScale == 1)
        {
            MenuCanvas.transform.parent.GetComponent<Pause>().IsPause = false;
            MenuCanvas.SetActive(false);
        }
        Debug.Log("Back Button Up");
    }


    // setting
    public void OnEnterSettingButton()
    {
        audio.clip = selectMenu;
        audio.volume = EffectVolume;
        audio.Play();
        GameObject.Find("SettingButton").transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        Debug.Log("Enter Setting Button");
    }

    public void OnExitSettingButton()
    {
        GameObject.Find("SettingButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Setting Button");
    }

    public void OnDownSettingButton()
    {
        GameObject.Find("SettingButton").transform.GetComponent<Image>().color = Color.gray;
        Debug.Log("Setting Button Down");
    }

    public void OnUpSettingButton()
    {
        GameObject.Find("SettingButton").transform.GetComponent<Image>().color = Color.white;
        GameObject.Find("SettingButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        MenuCanvas.SetActive(false);
        OptionCanvas.SetActive(true);
        Debug.Log("Setting Button Up");
    }


    // menu
    public void OnEnterMenuButton()
    {
        audio.clip = selectMenu;
        audio.volume = EffectVolume;
        audio.Play();
        GameObject.Find("MenuButton").transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        Debug.Log("Enter Menu Button");
    }

    public void OnExitMenuButton()
    {
        GameObject.Find("MenuButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Menu Button");
    }

    public void OnDownMenuButton()
    {
        GameObject.Find("MenuButton").transform.GetComponent<Image>().color = Color.gray;
        Debug.Log("Menu Button Down");
    }

    public void OnUpMenuButton()
    {
        GameObject.Find("MenuButton").transform.GetComponent<Image>().color = Color.white;
        GameObject.Find("MenuButton").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        SceneManager.LoadScene("Menu");
        Debug.Log("Menu Button Up");
    }



    // 설정 창
    // back
    public void OnEnterBack2Button()
    {
        audio.clip = selectBack;
        audio.volume = EffectVolume;
        audio.Play();
        GameObject.Find("BackButton2").transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        Debug.Log("Enter Back Button");
    }

    public void OnExitBack2Button()
    {
        GameObject.Find("BackButton2").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Exit Back Button");
    }

    public void OnDownBack2Button()
    {
        GameObject.Find("BackButton2").transform.GetComponent<Image>().color = Color.gray;
        Debug.Log("Back Button Down");
    }

    public void OnUpBack2Button()
    {
        GameObject.Find("BackButton2").transform.GetComponent<Image>().color = Color.white;
        GameObject.Find("BackButton2").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        MenuCanvas.SetActive(true);
        OptionCanvas.SetActive(false);
        Debug.Log("Back Button Up");
    }
}
