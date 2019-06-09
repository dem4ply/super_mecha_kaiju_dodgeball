using UnityEngine;

namespace chibi_incompleto.damage
{
	namespace motor
	{
		public class HP_motor : chibi.Chibi_behaviour
		{
			/*
			public chibi.UI.chicken_o_meter.Gauge hp_stat;
			[HideInInspector] public float total_of_points = 1;
			[HideInInspector] public float current_points = 1;

			public LayerMask damage_mask;
			//public controller.motor.Motor_base motor;
			public chibi.rol_sheet.Rol_sheet rol;

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
						"[HP_motor] murio: '{0}'",
						helper.game_object.name.full( this ) ) );
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

			private void OnCollisionEnter( Collision collision )
			{
				if ( helper.layer_mask.game_object_is_in_mask(
					collision.collider.gameObject, damage_mask ) )
				{
					Damage damage = collision.collider.GetComponent<Damage>();
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
				if ( damage.owner != null && rol )
					return damage.owner == rol;
				return false;
			}

			protected virtual bool is_from_my_faction( Damage damage )
			{
				if ( damage.owner != null && damage.owner.sheet != null
					&& damage.owner.sheet.faction )
				{
					return damage.owner.sheet.faction == rol.sheet.faction;
				}
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
		*/
		}
	}
}
