using TMPro;
using UnityEngine;

namespace CardHouse.attacking_scripts
{
    public class CCGCardStats : MonoBehaviour
    {
        public int attack = 2;
        public int health = 3;
        public int currentHealth = 3;
        public bool canAttack = false;
        public bool hasAttacked = false;
        public bool canBeAttacked = false;
        public bool isAttacking = false;
        public bool onBoard = false;
        public bool hasStealth = false;
        [Header("Sounds")]
        public AudioClip startAttackingSoundClipToPlay;
        public AudioClip whenDontAttackSoundClipToPlay;
        public AudioClip whenAttackSoundClipToPlay;
        public AudioClip whenHitSoundClipToPlay;
        public AudioClip onDeathSoundClipToPlay;
        public AudioClip onPlaySoundClipToPlay;
        [Header("Effects")]
        public ParticleSystem canAttackParticles;
        public ParticleSystem canBeAttackedParticles;
        public ParticleSystem isAttackingParticles;
        public TMP_Text attackText;
        public TMP_Text healthText;
        public GameObject destroyEffect;
        public GameObject hurtEffect;
        public GameObject stealthEffect;
        public CardOwner thisCardsOwner;
        public string ownerId; // e.g., "Player1", "Player2"

        public void Start()
        {
            currentHealth = health;
            attackText.text = attack.ToString();
            healthText.text = currentHealth.ToString();
            canBeAttacked = false;
        }

        public void Update()
        {
            if (onBoard)
            {
                attackText.text = attack.ToString();
                healthText.text = currentHealth.ToString();
                if (currentHealth < health)
                {
                    healthText.color = Color.red;
                }
                else
                {
                    healthText.color = Color.white;
                }

                if (canAttack && hasAttacked == false && attack > 0)
                {
                    if (!canAttackParticles.isPlaying)
                    {
                        canAttackParticles.Play();
                    }
                }
                else
                {
                    if (canAttackParticles.isPlaying)
                    {
                        canAttackParticles.Stop();
                    }
                }
                
                if (isAttacking)
                {
                    if (!isAttackingParticles.isPlaying)
                    {
                        isAttackingParticles.Play();
                    }
                }
                else
                {
                    if (isAttackingParticles.isPlaying)
                    {
                        isAttackingParticles.Stop();
                    }
                }

                if (hasStealth)
                {
                    if (!stealthEffect.gameObject.activeInHierarchy)
                    {
                        stealthEffect.gameObject.SetActive(true);
                    }
                    if (canBeAttackedParticles.isPlaying)
                    {
                        canBeAttackedParticles.Stop();
                    }
                }
                else if (!hasStealth)
                {
                    if (stealthEffect.gameObject.activeInHierarchy)
                    {
                        stealthEffect.gameObject.SetActive(false);
                    }
                    if (canBeAttacked)
                    {
                        if (!canBeAttackedParticles.isPlaying)
                        {
                            canBeAttackedParticles.Play();
                        }
                    }
                    else
                    {
                        if (canBeAttackedParticles.isPlaying)
                        {
                            canBeAttackedParticles.Stop();
                        }
                    }
                }
            }
        }

        public void PlaceOnBoard()
        {
            onBoard = true;
            canAttack = true;
            hasAttacked = false;
            
            
            if (onPlaySoundClipToPlay)
            {
                PlayAudioClip(onPlaySoundClipToPlay);
            }
        }

        public void TakeDamage(int amount)
        {
            Debug.Log("Take Damage");
            if (isAttacking)
            {
                hasStealth = false;
                if (whenAttackSoundClipToPlay)
                {
                    PlayAudioClip(whenAttackSoundClipToPlay);
                }
            }
            else
            {
                if (whenHitSoundClipToPlay)
                {
                    PlayAudioClip(whenHitSoundClipToPlay);
                }
            }

            isAttacking = false;
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                Instantiate(destroyEffect, this.transform.position, this.transform.rotation);
                if (onDeathSoundClipToPlay)
                {
                    PlayAudioClip(onDeathSoundClipToPlay);
                }

                Card thisCard = gameObject.GetComponent<Card>();
                Debug.Log($"this is the group we are on {thisCard.Group}", thisCard.Group);
                thisCard.Group.MountedCards.Remove(thisCard);
                Destroy(gameObject, 2);
            }
            else
            {
                Instantiate(hurtEffect, this.transform.position, this.transform.rotation);
            }
        }

        public void Attack()
        {
            if (onBoard)
            {
                if (canAttack && hasAttacked == false && attack > 0)
                {
                    if (isAttacking == false)
                    {
                        Debug.Log("Attack");
                        FindObjectOfType<CardCombatManager>().StartAttacking(this);
                        isAttacking = true; 
                        if (startAttackingSoundClipToPlay) 
                        {
                            PlayAudioClip(startAttackingSoundClipToPlay); 
                        }
                    }
                    else if (isAttacking == true)
                    {
                        Debug.Log("Stop Attacking");
                        FindObjectOfType<CardCombatManager>().StartAttacking(this);
                        isAttacking = false; 
                        if (whenDontAttackSoundClipToPlay) 
                        {
                            PlayAudioClip(whenDontAttackSoundClipToPlay); 
                        }
                    }
                }
                else if (canBeAttacked)
                {
                    if (!hasStealth)
                    {
                        FindObjectOfType<CardCombatManager>().GetAttacked(this);
                    }
                }
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
