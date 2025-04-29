using System;
using UnityEngine;

namespace RapidAssetPrototypes.CardHouse.Ccg_Extention.Scripts
{
    public class PlayAudio : MonoBehaviour
    {
        private AudioClip audioClipToPlay;

        public void Awake()
        {
            PlayAudioClip();
        }

        public void PlayAudioClip()
        {
            // Create a temporary GameObject
            GameObject tempGO = new GameObject("TempAudio");
            // Add an AudioSource component
            AudioSource audioSource = tempGO.AddComponent<AudioSource>();
            // Assign the clip
            audioSource.clip = audioClipToPlay;
            // Play it
            audioSource.Play();
            // Destroy the GameObject after the clip finishes playing
            Destroy(tempGO, audioClipToPlay.length);
        }
    }
}