using UnityEngine;
using UnityEngine.Events;

namespace CardHouse
{
    public class ClickDetector : Toggleable
    {
        public UnityEvent SOnPress;
        public UnityEvent SOnButtonClicked;
        [SerializeField] private AudioClip[] ClickClips;

        public GateCollection<NoParams> SClickGates;

        void OnMouseDown()
        {
            if (IsActive && SClickGates.AllUnlocked(null))
            {
                OnPress.Invoke();
                SoundFXManager.instance.PlayRandomSoundFXClip(ClickClips, transform, 1f);
            }
        }

        void OnMouseUpAsButton()
        {
            if (IsActive && SClickGates.AllUnlocked(null))
            {
                OnButtonClicked.Invoke();
                SoundFXManager.instance.PlayRandomSoundFXClip(ClickClips, transform, 1f);
            }
        }
    }
}
