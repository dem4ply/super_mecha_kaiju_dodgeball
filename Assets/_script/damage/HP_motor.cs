using UnityEngine;

namespace damage
{
	namespace motor
	{
		public class HP_motor : chibi_base.Chibi_behaviour
		{
			public stat.Hp_stat stat;
			[HideInInspector] public float total_of_points = 1;
			[HideInInspector] public float current_points = 1;

			public LayerMask damage_mask;
			//public controller.motor.Motor_base motor;
			public rol_sheet.Rol_sheet rol;

			public virtual bool is_dead
			{
				get {
					return current_points <= 0;
				}
			}

			public virtual void take_damage( Damage damage )
			{
				current_points -= damage.amount;
				if ( is_dead )
				{
					Debug.Log( string.Format(
						"[HP_motor] murio: {0}",
						helper.game_object.name.full( gameObject ) ) );
				}
			}

			protected virtual void OnTriggerEnter2D( Collider2D other )
			{
				if ( helper.layer_mask.game_object_is_in_mask(
					other.gameObject, damage_mask ) )
				{
					Damage damage = other.GetComponent<Damage>();
					proccess_damage( damage );
				}
			}

			protected virtual void OnTriggerEnter( Collider other )
			{
				if ( helper.layer_mask.game_object_is_in_mask(
					other.gameObject, damage_mask ) )
				{
					Damage damage = other.GetComponent<Damage>();
					proccess_damage( damage );
				}
			}

			protected virtual void proccess_damage( Damage damage )
			{
				if ( damage == null )
				{
					Debug.LogError( "no tiene el componente de dano" );
					return;
				}
				if ( is_my_damage( damage ) || is_from_my_faction( damage ) )
					return;
				take_damage( damage );
				damage.taken( this );
			}

			protected virtual void log_trigger( Collider other )
			{
				string msg = string.Format(
					"el {0} toco un trigger de danno {1}",
					this.name, other.name );

				Debug.Log( msg );
			}

			protected virtual bool is_my_damage( Damage damage )
			{
				if ( damage.owner != null )
					return damage.owner == rol;
				return false;
			}

			protected virtual bool is_from_my_faction( Damage damage )
			{
				if ( damage.owner != null )
					return damage.owner.faction == rol.faction;
				return false;
			}

			protected override void _init_cache()
			{
				base._init_cache();
				if ( damage_mask.value == 0 )
					damage_mask = helper.consts.layers.receives_damage;
				if ( stat != null )
				{
					total_of_points = stat.total;
					current_points = stat.current;
				}
			}
		}
	}
}
