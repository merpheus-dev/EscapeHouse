using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subtegral.EscapeHouse.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class AudioManager : AbstractManager<AudioManager>
    {
        private AudioSource _source;

        private AudioManager(){ }

        private void Start()
        {
            _source = GetComponent<AudioSource>();
        }

        public void PlayClip(AudioClip audioClip)
        {
            _source.PlayOneShot(audioClip);
        }
    }
}