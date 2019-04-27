using UnityEngine;

namespace controller {
	namespace animator {

		class NPC_isometric_animator_2d : animator.NPC_animator_2d
		{
			public motor.NPC_isometric_motor_2d _motor;
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
					_motor = GetComponent<motor.NPC_isometric_motor_2d>();
			}

			protected virtual void Update()
			{
				if ( is_attacking != _is_attacking )
				{
					_motor.attack_ended();
					_is_attacking = is_attacking;
				}
			}
		}
	}
}
