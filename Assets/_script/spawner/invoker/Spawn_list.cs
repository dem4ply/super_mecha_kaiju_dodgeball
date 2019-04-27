using UnityEngine;
using System.Collections.Generic;

namespace spawner
{
	namespace invoker
	{
		public class Spawn_list : Invoker
		{
			public List<Spawn_point> spawn_points;
			public float spawn_delta_time = 1f;
			public int loops = 1;

			protected float _sigma_time = 0f;
			protected int _amount_of_loops = 0;
			protected int _index = 0;
			protected List<Spawn_point>.Enumerator points;

			protected override void Start()
			{
				base.Start();
				points = spawn_points.GetEnumerator();
				Invoke( "spawn", spawn_delta_time );
			}

			protected void spawn()
			{
				if ( points.MoveNext() )
				{
					points.Current.spawn();
					Invoke( "spawn", spawn_delta_time );
				}
				else
				{
					if ( ++_amount_of_loops >= loops )
					{
						enabled = false;
					}
					else
					{
						points = spawn_points.GetEnumerator();
						spawn();
					}
				}
			}
		}
	}
}