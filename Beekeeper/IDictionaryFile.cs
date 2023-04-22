using System;
namespace Beekeeper
{
	public interface IDictionaryFile : IDisposable
	{
		public string? NextWord(); 
	}
}

