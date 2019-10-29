using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public GameObject player;
    public AudioMixer mixer;

    public AudioClip ambient;
    public AudioClip battle;

    public float volume = 1f;

    private static float clipLength;
    private bool keepFadingIn;
    private bool keepFadingOut;

    private void Start()
    {
        TrackSettings(player, ambient, "Music");
        StartCoroutine(ChangeMusic(player, ambient, 0.01f, volume, true));
    }

    public void PlayMusic(GameObject go, AudioClip track, float volume, bool loop = false)
    {
        var source = go.GetComponent<AudioSource>();
        source.PlayOneShot(track, volume);

        if (loop)
        {
            clipLength = track.length;
            StartCoroutine(Loop(go, clipLength, track, volume, loop));
        }
    }

    IEnumerator Loop(GameObject go, float length, AudioClip track, float volume, bool loop = false)
    {
        yield return new WaitForSeconds(length);

        PlayMusic(go, track, volume, loop);
    }

    public void PlayBattleMusic()
    {
        StartCoroutine(ChangeMusic(player, battle, 0.1f, volume, true));
    }

    public void PlayAmbientMusic()
    {
        StartCoroutine(ChangeMusic(player, ambient, 0.01f, volume, true));
    }

    public void TrackSettings(
        GameObject go,
        AudioClip track,
        string audioGroup
    )
    {
        go.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups(audioGroup)[0];
    }

    IEnumerator ChangeMusic(GameObject go, AudioClip track, float speed, float volume, bool loop = false)
    {
        StartCoroutine(FadeOut(go, track, speed));

        var src = go.GetComponent<AudioSource>();
        while (src.volume >= speed)
        {
            yield return new WaitForSeconds(0.01f);
        }
        src.Stop();

        PlayMusic(go, track, volume, loop);
        StartCoroutine(FadeIn(go, track, speed, volume));
    }

    IEnumerator FadeIn(GameObject go, AudioClip track, float speed, float volume)
    {
        var source = go.GetComponent<AudioSource>();

        keepFadingIn = true;
        keepFadingOut = false;

        source.volume = 0;

        while (source.volume < volume && keepFadingIn)
        {
            source.volume += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator FadeOut(GameObject go, AudioClip track, float speed)
    {
        keepFadingIn = false;
        keepFadingOut = true;

        var source = go.GetComponent<AudioSource>();

        while (source.volume > speed && keepFadingOut)
        {
            source.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
