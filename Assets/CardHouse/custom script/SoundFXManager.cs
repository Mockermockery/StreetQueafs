using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        int rand = Random.Range(0, audioClip.Length);

        AudioSource audioScource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioScource.clip = audioClip[rand];
        audioScource.volume = volume;

        audioScource.Play();
        float clipLength = audioScource.clip.length;
        Destroy(audioScource.gameObject,clipLength);
    }



    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioScource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioScource.clip = audioClip;
        audioScource.volume = volume;

        audioScource.Play();
        float clipLength = audioScource.clip.length;
        Destroy(audioScource.gameObject, clipLength);
    }
}
