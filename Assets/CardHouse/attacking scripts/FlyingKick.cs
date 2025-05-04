using UnityEngine;

namespace CardHouse.attacking_scripts
{
    public class FlyingKick : MonoBehaviour
    {
        public AudioClip flyingKickSoundClipToPlay;
        public string playerID; // e.g., "Player1", "Player2"

        public void UseFlyingKick()
        {
            Debug.Log("Flying Kick");
            CCGCardStats[] allCards = FindObjectsOfType<CCGCardStats>();
            foreach (var card in allCards)
            {
                if (card.ownerId == playerID)
                {
                    Debug.Log("Found Card", card.gameObject);
                    card.UseFlyingKick();
                    Debug.Log($"Start Using Flying Kick", card.gameObject);
                }
            }

            if (flyingKickSoundClipToPlay)
            {
                PlayAudioClip(flyingKickSoundClipToPlay);
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
