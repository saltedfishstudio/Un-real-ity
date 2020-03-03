using System;

namespace Unreality.Core
{
	[Serializable]
	public abstract class UObject
	{
		public Name name = default;
		
		public virtual void BeginDestroy() { }
		
		public virtual void Serialize() { }

		public virtual bool Rename(Name newName)
		{
			return true;
		}
		
		public virtual void PostRename(Name oldName) { }
	}
}