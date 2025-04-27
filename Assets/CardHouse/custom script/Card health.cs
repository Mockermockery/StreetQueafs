using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cardhealth : MonoBehaviour
{
    public static float maxcardHp;
    public static float staticcardHp;
    public float cardHp;

    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        maxcardHp = 10;
        staticcardHp = 4;

    }

    // Update is called once per frame
    void Update()
    {
        cardHp = staticcardHp;
        if(cardHp > maxcardHp )
        { cardHp = maxcardHp; }
        hpText.text = cardHp + "HP";
    }
}
