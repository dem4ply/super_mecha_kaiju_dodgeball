using UnityEngine;

namespace controller {
	namespace animator {

		class NPC_animator_3d : animator.animator_3d
		{
			public motor.NPC_motor_3d _motor;
			protected bool _is_attacking = false;
			public const string IS_ATTACK = "attack";

			public virtual bool is_attacking
			{
				get {
					return animator.GetBool( IS_ATTACK );
				}
				set {
					animator.SetBool( IS_ATTACK, value );
					_is_attacking = value;
				}
			}

			protected override void _init_cache()
			{
				base._init_cache();
				if ( _motor == null )
					_motor = GetComponent<motor.NPC_motor_3d>();
			}

			protected virtual void Update()
			{
			}
		}
	}
}