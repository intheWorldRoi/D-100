using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeChange : MonoBehaviour
{
    private void Awake()
    {
        if (transform.name == "BGMSlider")
            transform.GetComponent<Slider>().value = SoundManager.instance.masterVolumeBGM;

        else
            transform.GetComponent<Slider>().value = SoundManager.instance.masterVolumeSFX;
    }
    private void Update()
    {
        if (transform.name == "BGMSlider")
            SoundManager.instance.SetVolumeBGM(transform.GetComponent<Slider>().value);

        else
            SoundManager.instance.SetVolumeSound(transform.GetComponent<Slider>().value);
    }
}
