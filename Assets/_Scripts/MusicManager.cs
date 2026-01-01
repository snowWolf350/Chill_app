using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

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

    MusicSO currentMusicSO;
    AudioSource AudioSource;
    bool isPlaying = true;

    float volume = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        AudioSource = GetComponent<AudioSource>();
        pauseButton.onClick.AddListener(() =>
        {
            pauseMusic();
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
        AudioSource.volume = volume;
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
}
