using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace snippet {
	namespace objects {
		namespace interfaces {
			public interface Container {
				GameObject scene_container { get; }

				void clean();
			}
		}
	}
}
