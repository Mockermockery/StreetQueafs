using System.Linq;
using UnityEngine;

namespace CardHouse.attacking_scripts
{
    public class ManaGoesUp : MonoBehaviour
    {
        private CurrencyRegistry thisCurrencyRegistry;
        // Start is called before the first frame update
        void Start()
        {
            thisCurrencyRegistry = GetComponentInChildren<CurrencyRegistry>();
        }

        public void AddPlayer1Mana()
        {
            Debug.Log("Add Player 1 mana");
            if (thisCurrencyRegistry == null)
            {
                thisCurrencyRegistry = GetComponentInChildren<CurrencyRegistry>();
            }

            thisCurrencyRegistry.PlayerWallets[0].Currencies.Max().Max++;
            thisCurrencyRegistry.PlayerWallets[0].Currencies.Max().RefillValue++;
        }
        

        public void AddPlayer2Mana()
        {
            Debug.Log("Add Player 2 mana");
            if (thisCurrencyRegistry == null)
            {
                thisCurrencyRegistry = GetComponentInChildren<CurrencyRegistry>();
            }

            thisCurrencyRegistry.PlayerWallets[1].Currencies.Max().Max++;
            thisCurrencyRegistry.PlayerWallets[1].Currencies.Max().RefillValue++;
        }
    }
}
