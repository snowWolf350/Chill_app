using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class MusicManager : ButtonScript
{
    [Header("musicSO list")]
    [SerializeField] List<MusicSO> musicListSO;
    [Header("Text")]
    [SerializeField] TextMeshProUGUI musicText;
    [SerializeField] TextMeshProUGUI artistText;
    [Header("Buttons")]
    [SerializeField] Button pauseButton;
    [SerializeField] Button nextButton;
    [Header("Play Toggle")]
    [SerializeField] Sprite pauseSprite;
    [SerializeField] Sprite playSprite;

    MusicSO currentMusicSO;
    AudioSource AudioSource;
    bool isPlaying = true;
    const int initialVolume = 0;

    float finalVolume = 0.15f;

    protected override void Awake()
    {
        base.Awake();
        AudioSource = GetComponent<AudioSource>();
        pauseButton.onClick.AddListener(() =>
        {
            pauseMusic();
            if (isPlaying)
            {
                pauseButton.image.sprite = pauseSprite;
            }
            else
            {
                pauseButton.image.sprite = playSprite;
            }
        });
        nextButton.onClick.AddListener(() =>
        {
            playNewMusic();
        });
    }

    private void Start()
    {
        playNewMusic();   
    }

    private void Update()
    {
        if (isPlaying && !AudioSource.isPlaying)
        {
            playNewMusic();
        }
    }

    private void playNewMusic()
    {
        AudioSource.Stop();

        MusicSO newMusic;
        do
        {
            newMusic = musicListSO[Random.Range(0, musicListSO.Count)];
        }
        while (newMusic == currentMusicSO);

        currentMusicSO = newMusic;


        musicText.text = currentMusicSO.songName;
        artistText.text = currentMusicSO.songMaker;
        AudioSource.clip = currentMusicSO.audioClip;

        StartCoroutine(GradualVolumeIncrease());

        AudioSource.Play();
        isPlaying = true;
    }
    private void pauseMusic()
    {
        if (isPlaying)
        {
            isPlaying = false;
            AudioSource.Pause();
        }
        else
        {
            isPlaying=true;
            AudioSource.UnPause();
        }
    }

    private IEnumerator GradualVolumeIncrease()
    {
        float timer = 0;
        float timerMax = 2;

        while (timer < timerMax)
        {
            timer += Time.deltaTime;
            AudioSource.volume = Mathf.Lerp(initialVolume, finalVolume, timer * timer);
            yield return null;
        }

        AudioSource.volume = finalVolume;
    }
}
