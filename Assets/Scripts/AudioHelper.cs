using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioHelper
{
    public static IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;
        while(audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime;
            yield return null;
        }
        audioSource.Stop();
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0f;
        while(audioSource.volume < 0.4)
        {
            audioSource.volume += Time.deltaTime / fadeTime;
            yield return null;
        }
    }
}
