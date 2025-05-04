using UnityEngine;

namespace CardHouse.attacking_scripts
{
    public class Cheer : MonoBehaviour
    {
        public AudioClip cheerSoundClipToPlay;
        public string playerID; // e.g., "Player1", "Player2"
        public int cheerAttackBuff = 3;

        public void UseCheer()
        {
            Debug.Log("Duck");
            CCGCardStats[] allCards = FindObjectsOfType<CCGCardStats>();
            foreach (var card in allCards)
            {
                if (card.ownerId == playerID)
                {
                    Debug.Log("Found Card", card.gameObject);
                    if (card.onBoard)
                    {
                        card.attack += cheerAttackBuff;
                        Debug.Log($"Buff Attack {cheerAttackBuff}", card.gameObject);
                    }
                }
            }

            if (cheerSoundClipToPlay)
            {
                PlayAudioClip(cheerSoundClipToPlay);
            }
        }

        public void PlayAudioClip(AudioClip audioClipToPlay)
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
