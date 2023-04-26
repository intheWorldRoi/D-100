using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;

    [SerializeField] AudioClip[] bgmClip; // ����� �ҽ��� ����.
    [SerializeField] AudioClip[] audioClip; // ����� �ҽ��� ����.

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
        if(SceneManager.GetActiveScene().name == "Main")
        {
            instance.PlayBGM("main");  
        }
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

    // �� �� ��� : ���� �Ű������� ����
    public void PlaySound(string a_name, float a_volume = 1f)
    {
        sfxPlayer.PlayOneShot(audioClipsDic[a_name], a_volume * masterVolumeSFX);
    }
    
    public void PlayBGM(string a_name)
    {
        bgmPlayer.clip = bgmClipsDic[a_name];
        bgmPlayer.volume = masterVolumeBGM;
        bgmPlayer.loop = true;
        bgmPlayer.Play();
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
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

}
