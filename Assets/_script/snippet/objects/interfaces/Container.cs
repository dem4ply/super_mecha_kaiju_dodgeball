using UnityEngine;

namespace snippet
{
	namespace objects
	{
		namespace interfaces
		{
			public interface Container {
				GameObject scene_container { get; }

				void clean();
			}
		}
	}
}
