namespace Unreality.Core
{
	[System.Serializable]
	public class MeshComponent : PrimitiveComponent
	{
		public MeshComponent(Actor owner) : base(owner)
		{
		}

		public MeshComponent(Actor owner, IParent parent) : base(owner, parent)
		{
		}
	}
}