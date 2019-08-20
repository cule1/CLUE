using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public Slider BGMVolume;
    public Slider EffectVolume;
    public Toggle MuteToggle;
    public AudioSource audio;

    private float BGMVol = 1.0f;
    public float EffectVol = 1.0f;  // 이펙트는 각각 사운드 크기 가져오려고 바꿈

    // Use this for initialization
    void Start () {
        BGMVol = PlayerPrefs.GetFloat("BGMSlider", 1.0f);
        BGMVolume.value = BGMVol;
        audio.volume = BGMVolume.value;

        EffectVol = PlayerPrefs.GetFloat("EffectSlider", 1.0f);
        EffectVolume.value = EffectVol;
        audio.volume = EffectVolume.value;
    }
	
	// Update is called once per frame
	void Update () {
        if (!MuteToggle.isOn)
        {
            BGMSlider();
            EffectSlider();
        }
        else
        {
            BGMVol = 0.0f;
            EffectVol = 0.0f;
            audio.volume = BGMVol;
        }
    }

    public void BGMSlider() {
        audio.volume = BGMVolume.value;

        BGMVol = BGMVolume.value;
        PlayerPrefs.SetFloat("BGMSlider", BGMVol);
    }

    public void EffectSlider()
    {
        // 이펙트는 나중에 값만 따서 실행시키면 됨

        //audio.volume = EffectVolume.value;

        EffectVol = EffectVolume.value;
        PlayerPrefs.SetFloat("EffectSlider", EffectVol);
    }
}
