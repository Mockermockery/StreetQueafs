using UnityEngine;

namespace CardHouse.attacking_scripts
{
    public class CardCombatManager : MonoBehaviour
    {
        public static CardCombatManager Instance;
        
        private CCGCardStats selectedAttacker;
        private CCGCardStats attackingCard;
        
        // e.g., "Player1", "Player2"

        void Awake()
        {
            Instance = this;
        }

        public void SelectAttacker(CCGCardStats card)
        {
            if (card.canAttack)
            {
                selectedAttacker = card;
                Debug.Log($"Selected attacker: {card.name}");
            }
        }

        public void StartAttacking(CCGCardStats cardAttacking)
        {
            Debug.Log("Start Attacking");
            // Turn off all Player 1 cards to be able to be attacked and turn on player 2 cards.
            if (cardAttacking.ownerId == "Player1")
            {
                CCGCardStats[] allCards = FindObjectsOfType<CCGCardStats>();
                // Enable Can Be Attacked
                foreach (var card in allCards)
                {
                    if (card.ownerId == "Player2")
                    {
                        Debug.Log("Found Card",card.gameObject);
                        if (card.onBoard)
                        {
                            card.canBeAttacked = true;
                            card.canAttack = false;
                            Debug.Log("Can Be Attacked",card.gameObject);
                        }
                    }
                    else if (card.ownerId == "Player1")
                    {
                        Debug.Log("Found Card",card.gameObject);
                        if (card.onBoard)
                        {
                            card.canBeAttacked = false;
                            card.canAttack = false;
                            Debug.Log("Stop Attacks",card.gameObject);
                        }
                    }
                }
                attackingCard = cardAttacking;
            }
            else if (cardAttacking.ownerId == "Player2")
            {
                CCGCardStats[] allCards = FindObjectsOfType<CCGCardStats>();
                // Enable Can Be Attacked
                foreach (var card in allCards)
                {
                    if (card.ownerId == "Player1")
                    {
                        Debug.Log("Found Card", card.gameObject);
                        if (card.onBoard)
                        {
                            card.canBeAttacked = true;
                            card.canAttack = false;
                            Debug.Log("Can Be Attacked", card.gameObject);
                        }
                    }
                    else if (card.ownerId == "Player2")
                    {
                        Debug.Log("Found Card", card.gameObject);
                        if (card.onBoard)
                        {
                            card.canBeAttacked = false;
                            card.canAttack = false;
                            Debug.Log("Stop Attacks", card.gameObject);
                        }
                    }
                }
                attackingCard = cardAttacking;
            }
            else
            {
                Debug.Log("No Player Identity Can't Attack");
            }
        }

        public void GetAttacked(CCGCardStats cardBeingAttacked)
        {
            int cardGettingAttackedAttack;
            int attackingCardAttack;

            cardGettingAttackedAttack = cardBeingAttacked.attack;
            attackingCardAttack = attackingCard.attack;

            attackingCard.hasAttacked = true;

            EnableAttackingDisableBeingAttacked(attackingCard.ownerId);
            cardBeingAttacked.TakeDamage(attackingCardAttack);
            attackingCard.TakeDamage(cardGettingAttackedAttack);
            attackingCard.hasAttacked = true;
            attackingCard = null;
        }

        private void EnableAttackingDisableBeingAttacked(string attackingCardOwnerId)
        {
            CCGCardStats[] allCards = FindObjectsOfType<CCGCardStats>();

            foreach (var card in allCards)
            {
                card.canBeAttacked = false;
                if (card.ownerId == attackingCardOwnerId)
                {
                    if (card.onBoard)
                    {
                        card.canAttack = true;
                    }
                }
            }
        }

        public void SelectTarget(CCGCardStats target)
        {
            if (selectedAttacker != null && target.ownerId != selectedAttacker.ownerId)
            {
                target.TakeDamage(selectedAttacker.attack);
                selectedAttacker.canAttack = false;

                Debug.Log($"{selectedAttacker.name} attacked {target.name}");

                selectedAttacker = null;
            }
        }

        public void ResetAttacks(string ownerId)
        {
            foreach (var card in FindObjectsOfType<CCGCardStats>())
            {
                if (card.ownerId == ownerId)
                {
                    if (card.onBoard)
                    {
                        card.canAttack = true;
                        card.hasAttacked = false;
                        card.isAttacking = false;
                        card.canBeAttacked = false;
                        card.hasStealth = false;
                    }
                }
            }
        }

        public void StopBeingAttacks(string ownerId)
        {
            Debug.Log($"Stop {ownerId} Attacks");
            CCGCardStats[] allCards = FindObjectsOfType<CCGCardStats>();
            foreach (var card in allCards)
            {
                if (card.ownerId == ownerId)
                {
                    Debug.Log("Found Card",card.gameObject);
                    if (card.onBoard)
                    {
                        card.canAttack = false;
                        card.isAttacking = false;
                        card.canBeAttacked = false;
                        Debug.Log("Stop Attacks",card.gameObject);
                    }
                }
            }
        }
    }
}
