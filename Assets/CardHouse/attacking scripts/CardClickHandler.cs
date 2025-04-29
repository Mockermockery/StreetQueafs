using UnityEngine;

namespace RapidAssetPrototypes.CardHouse.Ccg_Extention.Scripts
{
    public class CardClickHandler : MonoBehaviour
    {
        private CCGCardStats stats;

        void Start()
        {
            stats = GetComponent<CCGCardStats>();
        }

        void OnMouseDown()
        {
            if (stats == null) return;

            if (stats.onBoard)
            {
                if (stats.canAttack)
                {
                    CardCombatManager.Instance.SelectAttacker(stats);
                }
                else
                {
                    CardCombatManager.Instance.SelectTarget(stats);
                }
            }
        }
    }
}
