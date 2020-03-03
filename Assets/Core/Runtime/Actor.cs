using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unreality.Core
{
	[System.Serializable]
	public class Actor : MonoBehaviour, IOwner
	{
		public UObject inheritFrom;
		public List<ITick> components = new List<ITick>();

		public readonly List<Action<float, ELevelTick>> action = new List<Action<float, ELevelTick>>();

		void Awake()
		{
			foreach (ITick component in components)
			{
				component.RegisterComponent();
			}
		}

		void Update()
		{
			foreach (ITick component in components)
			{
				component.TickComponent(Time.deltaTime, ELevelTick.OnUpdate);
			}
		}
		
		void FixedUpdate()
		{
			foreach (Action<float,ELevelTick> act in action)
			{
				act.Invoke(Time.fixedDeltaTime, ELevelTick.OnFixedUpdate);
			}
		}
		
		void LateUpdate()
		{
			foreach (Action<float,ELevelTick> act in action)
			{
				act.Invoke(Time.deltaTime, ELevelTick.OnLateUpdate);
			}
		}

		public Vector3 Position
		{
			get { return transform.position; }
		}

		public Vector3 Rotation
		{
			get { return transform.rotation.eulerAngles; }
		}

		public Vector3 Scale
		{
			get { return transform.localScale; }
		}

		[Header("Test")]
		public Mesh mesh;
		public Material material;
		[ContextMenu("Add Mesh Data")]
		void Test()
		{
			var newMesh = new StaticMeshComponent(this);
			newMesh.mesh = this.mesh;
			newMesh.material = this.material;
			
			components.Add(newMesh);
		}
	}

	public interface IOwner : IParent
	{
		
	}

	public interface IParent
	{
		Vector3 Position { get; }
		Vector3 Rotation { get; }
		Vector3 Scale { get; }
	}

	public interface ITick
	{
		void TickComponent(float deltaTime, ELevelTick tickType);
		void RegisterComponent();
	}
}