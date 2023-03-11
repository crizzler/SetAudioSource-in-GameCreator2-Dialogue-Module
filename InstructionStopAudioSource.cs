using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

[Version(1, 0, 0)]

[Title("StopsAudioSource")]
[Description("Stops an AudioSource from playing a clip")]

[Category("Audio/Stop AudioSource")]

[Parameter("Target", "A game object that is set as the AudioSource")]

[Keywords("Audio", "Voice", "Voices", "Sounds", "Character", "Silence", "Mute", "Fade")]
[Image(typeof(IconVolume), ColorTheme.Type.TextLight, typeof(OverlayCross))]

[Serializable]
public class InstructionStopAudioSource : Instruction
{
    [SerializeField] private PropertyGetGameObject m_AudioSourceGameObject = new PropertyGetGameObject();

    public override string Title => $"Stop {this.m_AudioSourceGameObject} AudioSource";

    protected override Task Run(Args args)
    {
        GameObject target = this.m_AudioSourceGameObject.Get(args);
        AudioSource audioSource = target.GetComponent<AudioSource>();

        audioSource.Stop();
        return DefaultResult;
    }
}
