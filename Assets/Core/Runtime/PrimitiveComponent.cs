namespace Unreality.Core
{
	[System.Serializable]
	public class PrimitiveComponent : SceneComponent
	{
		public PrimitiveComponent(Actor owner) : base(owner)
		{
		}

		public PrimitiveComponent(Actor owner, IParent parent) : base(owner, parent)
		{
		}
	}
}