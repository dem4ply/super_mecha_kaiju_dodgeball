using UnityEngine;
using System.Collections;
using chibi_base;

namespace controller
{
	namespace motor
	{
		namespace platform
		{
			public class Platform_motor_base: Chibi_behaviour
			{
				public GameObject platform;

				public virtual GameObject summon()
				{
					GameObject new_platform = helper.instantiate.position(
						platform, transform.position );
					new_platform.transform.rotation = platform.transform.rotation;
					new_platform.SetActive( true );
					return new_platform;
				}

				protected override void _init_cache() {
					base._init_cache();
					if ( platform == null )
						platform = gameObject;
				}
			}
		}
	}
}
