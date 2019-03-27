using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Subtegral.EscapeHouse.Managers;
namespace Subtegral.EscapeHouse.Graph
{
    [CreateNodeMenu("Executions/Play Sound")]
    public class PlaySoundExecution : AbstractExecutionNode
    {
        public AudioClip Clip;

        public override void Execute()
        {
            (AudioManager.Instance as AudioManager).PlayClip(Clip);
        }

    }
}