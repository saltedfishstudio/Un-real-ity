namespace Unreality.Core
{
	[System.Serializable]
	public class Name
	{
		string name = default;
		
		public static implicit operator string(Name serialized)
		{
			return serialized.name;
		}

		public static implicit operator Name(string curve)
		{
			Name asset = new Name {name = curve};
			return asset;
		}
	}
}