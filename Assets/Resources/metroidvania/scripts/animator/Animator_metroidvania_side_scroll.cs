using System;
using UnityEngine;

namespace metroidvania.animator
{
	public class Animator_metroidvania_side_scroll : chibi.animator.Animator_side_scroll
	{
		public GameObject model;

		public override Vector3 direction
		{
			get {
				var x = animator.GetFloat( "horizontal" );
				var z = animator.GetFloat( "vertical" );
				return new Vector3( x, 0, z );
			}
			set {
				base.direction = value;
				var dir = new Vector3( value.x, value.y, 0 );
				if ( dir.x != 0 )
				{
					var direction = Math.Sign( dir.x );
					float angle = direction > 0 ? 0 : -180;
					model.transform.rotation = Quaternion.Euler( 0, angle, 0 );
				}
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !model )
			{
				debug.error( "no se asigno el gameobject model" );
			}
		}
	}
}
