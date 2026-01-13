using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] List<BackgroundMusicSO> backgroundMusicSOList;

    BackgroundMusicSO currentBackgroundMusicSO;
    AudioSource audioSource;
    const int initialVolume = 0;
    bool isPlaying = true;

    float finalVolume = 0.1f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        playNewMusic();
    }
    private void Update()
    {
        if (isPlaying && !audioSource.isPlaying)
        {
            playNewMusic();
        }
    }

    private void playNewMusic()
    {
        audioSource.Stop();

        BackgroundMusicSO newMusic;
        do
        {
            newMusic = backgroundMusicSOList[Random.Range(0, backgroundMusicSOList.Count-1)];
        }
        while (newMusic == currentBackgroundMusicSO);

        currentBackgroundMusicSO = newMusic;
        audioSource.clip = currentBackgroundMusicSO.backgroundAudioClip;

        StartCoroutine(GradualVolumeIncrease());

        audioSource.Play();
        isPlaying = true;
    }
    private void pauseMusic()
    {
        if (isPlaying)
        {
            isPlaying = false;
            audioSource.Pause();
        }
        else
        {
            isPlaying = true;
            audioSource.UnPause();
        }
    }

    private IEnumerator GradualVolumeIncrease()
    {
        float timer = 0;
        float timerMax = 2;

        while (timer < timerMax)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(initialVolume, finalVolume, timer * timer);
            yield return null;
        }

        audioSource.volume = finalVolume;
    }
}
