using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
    [Title("Audio Source")]
    [Category("Audio Source")]

    [Image(typeof(IconVolume), ColorTheme.Type.Yellow)]
    [Description("Plays an AudioClip in a specified AudioSource")]

    [Serializable]
    [HideLabelsInEditor]
    public class GetAudioSource : PropertyTypeGetAudio
    {
        [SerializeField] protected AudioClip audioClip;
        [SerializeField] protected AudioSource audioSource;

        public override AudioClip Get(Args args)
        {
            audioSource.clip = audioClip;
            int lengthSamples = audioClip.samples;
            AudioClip copyLength = AudioClip.Create("copyClip", lengthSamples, audioClip.channels, audioClip.frequency, false);
            audioSource.Play();
            return copyLength;
        }

        public static PropertyGetAudio Create => new PropertyGetAudio(
            new GetAudioSource()
        );

        public override string String => "Set AudioSource and AudioClip";
    }
}