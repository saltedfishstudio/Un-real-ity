using System;
using UnityEngine;

namespace Unreality.Core
{
	[Serializable]
	public class ActorComponent : UObject, IParent, ITick
	{
		public ActorComponent(Actor owner)
		{
			this.ownerPrivate = owner;
			this.parentPrivate = owner;
		}
		
		public ActorComponent(Actor owner, IParent parent)
		{
			this.ownerPrivate = owner;
			this.parentPrivate = parent;
		}
		
		ActorComponent() {}

		[SerializeField]
		protected Actor ownerPrivate;
		[SerializeField]
		protected IParent parentPrivate;
		
		bool active;
		bool isRegistered;
		bool allowReregistration;
		
		public virtual void TickComponent(float deltaTime, ELevelTick tickType)
		{
			
		}
		
		public bool IsRegistered {
			get { return isRegistered; }
		}

		public bool AllowReregistration
		{
			get
			{
				return allowReregistration;
			}
		}

		public virtual void RegisterComponent()
		{
			ownerPrivate.action.Add(this.TickComponent);
		}

		public virtual void UnregisterComponent()
		{
			
		}

		public virtual void ReRegisterComponent()
		{
			
		}

		public virtual void DestroyComponent()
		{
			
		}

		public virtual void OnComponentCreated()
		{
			
		}

		public virtual void OnComponentDestroyed()
		{
			
		}

		public virtual bool CanChangeParent(IParent newParent)
		{
			return false;
		}

		public virtual void DoChangeParent(IParent newParent)
		{
			
		}

		public void SetActive(bool newIsActive)
		{
			this.active = newIsActive;
		}
		
		public bool Active
		{
			get { return active; }
		}

		public IOwner GetOwner()
		{
			return ownerPrivate;
		}

		public IParent GetParent()
		{
			return parentPrivate;
		}

		public virtual Vector3 Position
		{
			get { return parentPrivate.Position; }
		}

		public virtual Vector3 Rotation
		{
			get { return parentPrivate.Rotation; }
		}

		public virtual Vector3 Scale
		{
			get { return parentPrivate.Scale; }
		}
	}

	public enum ELevelTick
	{
		OnUpdate = 0,
		OnFixedUpdate = 1,
		OnLateUpdate = 2,
		Manual = 3,
	}

	public class TickFunction
	{
		
	}
}