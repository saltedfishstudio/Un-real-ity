using System;
using UnityEngine;

namespace Unreality.Core
{
	[System.Serializable]
	public class StaticMeshComponent : MeshComponent
	{
		[SerializeField]
		public Mesh mesh;
		[SerializeField]
		public Material material;
		[SerializeField]
		public int layer;
		[SerializeField]
		public Vector3 position;
		[SerializeField]
		public Vector3 rotation;
		[SerializeField]
		public Vector3 scale = Vector3.one;

		public override void TickComponent(float deltaTime, ELevelTick tickType)
		{
			base.TickComponent(deltaTime, tickType);
			switch (tickType)
			{
				case ELevelTick.OnUpdate:
					Graphics.DrawMesh(mesh, Position + position, Quaternion.Euler(Rotation + rotation), material, layer);
                    
					break;
				case ELevelTick.OnFixedUpdate:
					break;
				case ELevelTick.OnLateUpdate:
					break;
				case ELevelTick.Manual:
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(tickType), tickType, null);
			}
		}

		public override void RegisterComponent()
		{
			ownerPrivate.action.Add(TickComponent);
		}

		public StaticMeshComponent(Actor owner) : base(owner)
		{
			name = "New Static Mesh";
		}

		public StaticMeshComponent(Actor owner, IParent parent) : base(owner, parent)
		{
		}
	}
}