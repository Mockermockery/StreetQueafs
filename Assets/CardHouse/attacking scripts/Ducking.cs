using UnityEngine;

namespace RapidAssetPrototypes.CardHouse.Ccg_Extention.Scripts
{
    public class Ducking : MonoBehaviour
    {
        public AudioClip duckingSoundClipToPlay;
        public string playerID; // e.g., "Player1", "Player2"
        public void UseDucking()
        {
            Debug.Log("Duck");
            CCGCardStats[] allCards = FindObjectsOfType<CCGCardStats>();
            foreach (var card in allCards)
            {
                if (card.ownerId == playerID)
                {
                    Debug.Log("Found Card",card.gameObject);
                    if (card.onBoard)
                    {
                        card.hasStealth = true;
                        Debug.Log("Stealth Card",card.gameObject);
                    }
                }
            }
            if (duckingSoundClipToPlay)
            {
                PlayAudioClip(duckingSoundClipToPlay);
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
