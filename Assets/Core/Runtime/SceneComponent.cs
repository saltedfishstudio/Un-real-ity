using System;
using UnityEngine;

namespace Unreality.Core
{
    [System.Serializable]
    public class SceneComponent : ActorComponent
    {
        public SceneComponent(Actor owner) : base(owner)
        {
        }

        public SceneComponent(Actor owner, IParent parent) : base(owner, parent)
        {
        }
    }
}