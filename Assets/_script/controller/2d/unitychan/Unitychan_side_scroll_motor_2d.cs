using UnityEngine;
using System.Collections;
using controller.animator;
using System;

namespace controller
{
	namespace motor
	{
		public class Unitychan_side_scroll_motor_2d : NPC_side_scroll_motor_2d
		{
			public GameObject model;

			public override void update_motion()
			{
				base.update_motion();
				update_model();
			}


			public virtual void update_model()
			{
				Vector3 model_local_scale = model.transform.localScale;
				if ( _rigidbody.velocity.x > 0 )
					model.transform.localScale = new Vector3(
						1, model_local_scale.y, model_local_scale.z );
				else if ( _rigidbody.velocity.x < 0 )
					model.transform.localScale = new Vector3(
						-1, model_local_scale.y, model_local_scale.z );
			}

			protected override void _init_cache()
			{
				base._init_cache();
				if ( model == null )
				{
					model = transform.Find( "model" ).gameObject;
					if ( model == null )
					{
						string msg = String.Format(
							"no se encontro el modelo en el gameobject {0}",
							this.gameObject.name );
						throw new NullReferenceException( msg );
					}
				}
			}
		}
	}
}