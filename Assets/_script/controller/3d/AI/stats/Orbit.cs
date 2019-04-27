using UnityEngine;
using System.Collections.Generic;


namespace controller
{
	namespace controllers
	{
		namespace ai
		{
			namespace tree_d
			{
				namespace stats
				{
					[CreateAssetMenu( menuName = "controller/ai/stat/Orbit" )]
					public class Orbit : Stat
					{
						public float x_radius = 1;
						public float z_radius = 1;
						public float _orbit_period = 1;

						protected float _orbit_delta;

						public float orbit_delta
						{
							get {
								return _orbit_delta;
							}
						}

						public float orbit_period
						{
							get {
								return _orbit_period;
							}

							set {
								if ( value < 0.1f )
									value = 0.1f;
								_orbit_period = value;
								_orbit_delta = 1f / _orbit_period;
							}
						}

						private void OnEnable()
						{
							// TODO: camiar esto en un custom editor
							orbit_period = orbit_period;
						}
					}
				}
			}
		}
	}
}
