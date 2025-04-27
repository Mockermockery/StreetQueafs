using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsound : MonoBehaviour
{
    [SerializeField] private AudioClip damagesound;
    public void playsoundtest()
    {
        Debug.Log("log my dick");
        SoundFXManager.instance.PlaySoundFXClip(damagesound, transform,1f);
}

    public void OnEnable()
    {
     playsoundtest();
    }
}
