using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public float masterVolumeSFX = 1;
    public float masterVolumeBGM = 1;

    [SerializeField] AudioClip[] bgmClip; // 오디오 소스들 지정.
    [SerializeField] AudioClip[] audioClip; // 오디오 소스들 지정.

    public Dictionary<string, AudioClip> bgmClipsDic = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>();

    public AudioSource bgmPlayer;
    public AudioSource sfxPlayer;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            AwakeAfter();
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
            PlayINTRO("introNomal");
    }
    void AwakeAfter()
    {
        GameObject bgm = new GameObject("BGM");
        bgm.transform.SetParent(transform);
        bgmPlayer = bgm.AddComponent<AudioSource>();

        GameObject eff = new GameObject("SFX");
        eff.transform.SetParent(transform);
        sfxPlayer = eff.AddComponent<AudioSource>();

        bgmClipsDic = new Dictionary<string, AudioClip>();
        foreach (AudioClip a in bgmClip)
        {
            bgmClipsDic.Add(a.name, a);
        }

        audioClipsDic = new Dictionary<string, AudioClip>();
        foreach (AudioClip a in audioClip)
        {
            audioClipsDic.Add(a.name, a);
        }
    }


    // 한 번 재생 : 볼륨 매개변수로 지정
    public void PlaySound(string a_name, float a_volume = 1f)
    {
        sfxPlayer.PlayOneShot(audioClipsDic[a_name], a_volume * masterVolumeSFX);
    }

    public void PlayBGM(string a_name)
    {
        //StartCoroutine(volumeDown());
        //bgmPlayer.clip = bgmClipsDic[a_name];
        //bgmPlayer.loop = true;
        StartCoroutine(volumeUp(a_name));
        //bgmPlayer.Play();

    }

    public void StopBGM()
    {
        //StartCoroutine(volumeDown());
        bgmPlayer.Stop();
    }
    public void StopSound()
    {
        sfxPlayer.Stop();
    }
    public void SetVolumeSound(float a_volume)
    {
        masterVolumeSFX = a_volume;
        sfxPlayer.volume = masterVolumeSFX;
    }

    public void SetVolumeBGM(float a_volume)
    {
        masterVolumeBGM = a_volume;
        bgmPlayer.volume = masterVolumeBGM;
    }

    IEnumerator volumeUp(string a_name)
    {
        while (bgmPlayer.volume > 0)
        {
            yield return new WaitForSeconds(0.06f);
            bgmPlayer.volume -= 0.1f;
            yield return new WaitForSeconds(0.03f);
        }
        bgmPlayer.clip = bgmClipsDic[a_name];
        bgmPlayer.loop = true;
        bgmPlayer.Play();
        while (bgmPlayer.volume < masterVolumeBGM)
        {
            yield return new WaitForSeconds(0.06f);
            bgmPlayer.volume += 0.1f;
            yield return new WaitForSeconds(0.03f);
        }
        bgmPlayer.volume = masterVolumeBGM;

    }

    IEnumerator volumeDown()
    {
        while (bgmPlayer.volume >= 0)
        {
            yield return new WaitForSeconds(0.2f);
            bgmPlayer.volume -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

    }
    public void PlayINTRO(string a_name)
    {
        bgmPlayer.clip = bgmClipsDic[a_name];
        bgmPlayer.volume = masterVolumeBGM;
        bgmPlayer.loop = true;
        bgmPlayer.Play();

    }
}
