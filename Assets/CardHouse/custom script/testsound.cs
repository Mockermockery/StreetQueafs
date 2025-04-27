using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsound : MonoBehaviour
{
    [SerializeField] private AudioClip[] TurnSound;
    public void playsoundtest()
    {
        Debug.Log("log my dick");
        SoundFXManager.instance.PlayRandomSoundFXClip(TurnSound, transform,1f);
}

    public void OnEnable()
    {
        
     playsoundtest();
    }


}
