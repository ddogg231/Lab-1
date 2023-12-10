using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audiomanager : MonoBehaviour
{
    List<AudioSource> currentAudioSoures = new List<AudioSource>();

    public AudioMixerGroup sfxGroup;
    public AudioMixerGroup musicGroup;
    // Start is called before the first frame update
    void Start()
    {
        currentAudioSoures.Add(gameObject.GetComponent<AudioSource>());
    }
 
    // Update is called once per frame
  public void Playoneshot(AudioClip clip, bool isMusic)
    {
        foreach (AudioSource source in currentAudioSoures)
        {
            if (source.isPlaying)
                continue;

            source.PlayOneShot(clip);
            source.outputAudioMixerGroup = isMusic ? musicGroup : sfxGroup;
                return;
        }

        AudioSource temp = gameObject.AddComponent<AudioSource>();
        currentAudioSoures.Add(temp);
        temp.PlayOneShot(clip);
        temp.outputAudioMixerGroup = isMusic ? musicGroup : sfxGroup;
    }
}

/*private AudioSource Musicsource;
private AudioSource Musicsource2;
private AudioSource SFXsource;

private bool firstMusicSourceIsPlaying;
protected override void Awake()
{
    base.Awake();
    Musicsource = this.gameObject.AddComponent<AudioSource>();
    Musicsource2 = this.gameObject.AddComponent<AudioSource>();
    SFXsource = this.gameObject.AddComponent<AudioSource>();

    Musicsource.loop = true;
    Musicsource2.loop = true;
}
public void PlayMusic(AudioClip musicClip)
{
    AudioSource activeSource = (firstMusicSourceIsPlaying) ? Musicsource : Musicsource2;

    activeSource.clip = musicClip;
    activeSource.volume = 1;
    activeSource.Play();
}
public void PlayMusicWithFade(AudioClip newClip, float transitiontime = 1.0f)
{
    currentAudioSoures.Add(gameObject.GetComponent<AudioSource>());
    AudioSource activeSource = (firstMusicSourceIsPlaying) ? Musicsource : Musicsource2;

    StartCoroutine(updateMusicWithFade(activeSource, newClip, transitiontime));
}
public void PlayMusicWithCrossFade(AudioClip musicClip, float transitiontime = 1.0f)
{
    AudioSource activeSource = (firstMusicSourceIsPlaying) ? Musicsource : Musicsource2;
    AudioSource newSource = (firstMusicSourceIsPlaying) ? Musicsource2 : Musicsource;

    // Update is called once per frame
    public void Playoneshot(AudioClip clip, bool isMusic)
        firstMusicSourceIsPlaying = !firstMusicSourceIsPlaying;

    newSource.clip = musicClip;
    newSource.Play();
    StartCoroutine(updateMusicWithCrossFade(activeSource, newSource, transitiontime));
}

private IEnumerator updateMusicWithCrossFade(AudioSource original, AudioSource newSource, float transitiontime)
{
    foreach (AudioSource source in currentAudioSoures)
        float t = 0.0f;
    //fades  one song into another 
    for (t = 0.0f; t <= transitiontime; t += Time.deltaTime)
    {
        if (source.isPlaying)
            continue;
        original.volume = (Musicsource.volume - (t / transitiontime));
        newSource.volume = (t / transitiontime);
        yield return null;
    }
    original.Stop();
}
private IEnumerator updateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitiontime)
{
    if (!activeSource.isPlaying)
        activeSource.Play();

    float t = 0.0f;

    source.PlayOneShot(clip);
    source.outputAudioMixerGroup = isMusic ? musicGroup : sfxGroup;
    return;
    for (t = 0; t < transitiontime; t += Time.deltaTime)
    {//change the one to musicvolume
        activeSource.volume = (Musicsource.volume - (t / transitiontime));
        yield return null;
    }
    activeSource.Stop();
    activeSource.clip = newClip;
    activeSource.Play();
    for (t = 0; t < transitiontime; t += Time.deltaTime)
    {
        activeSource.volume = (Musicsource.volume - (t / transitiontime));
        yield return null;
    }
}
public void SetMusicVolume(float volume)
{
    Musicsource.volume = volume;
    Musicsource2.volume = volume;
}
public void SetSFXVolume(float volume)
{
    SFXsource.volume = volume;
}
public void PlaySFX(AudioClip clip)
{
    SFXsource.PlayOneShot(clip);
}

AudioSource temp = gameObject.AddComponent<AudioSource>();
currentAudioSoures.Add(temp);
temp.PlayOneShot(clip);
temp.outputAudioMixerGroup = isMusic ? musicGroup : sfxGroup;
public void PlaySFX(AudioClip clip, float volume)
{
    SFXsource.PlayOneShot(clip, volume);
}

    
}
//List<AudioSource> currentAudioSoures = new List<AudioSource>();
//
//public AudioMixerGroup sfxGroup;
//public AudioMixerGroup musicGroup;
// Start is called before the first frame update
//void Start()
//{
//    currentAudioSoures.Add(gameObject.GetComponent<AudioSource>());
//}
//
// Update is called once per frame
//public void Playoneshot(AudioClip clip, bool isMusic)
//{
//    foreach (AudioSource source in currentAudioSoures)
//    {
//        if (source.isPlaying)
//            continue;
//
//        source.PlayOneShot(clip);
//        source.outputAudioMixerGroup = isMusic ? musicGroup : sfxGroup;
//        return;
//    }
//
//    AudioSource temp = gameObject.AddComponent<AudioSource>();
//    currentAudioSoures.Add(temp);
//    temp.PlayOneShot(clip);
//    temp.outputAudioMixerGroup = isMusic ? musicGroup : sfxGroup;
//}*/