using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace damage
{
	public class Damage : chibi.Chibi_behaviour {
		public damage.Damage damage;
		public behavior.Beavior behavior;
		public chibi.rol_sheet.Rol_sheet owner;
		[HideInInspector] public float amount = 1;

		protected List<motor.HP_motor_old> _taken_by;

		public List<motor.HP_motor_old> taken_by
		{
			get {
				return _taken_by;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			if ( damage != null )
			{
				amount = damage.amount;
			}
			_taken_by = new List<motor.HP_motor_old>();
		}

		public virtual void taken( motor.HP_motor_old hp_motor )
		{
			if ( !taken_by.Contains( hp_motor ) )
				taken_by.Add( hp_motor );
			Debug.Log( string.Format(
				"[Damage] danno tomado por {0}",
				helper.game_object.name.full( hp_motor.gameObject ) ) );

			if ( behavior != null )
				behavior.taken_damange( this );
			else
				Debug.Log(
					string.Format(
						"[Damage] el '{0}' damage no tiene un behavior",
						helper.game_object.name.full( gameObject ) ) );
		}

		public override void reset()
		{
			base.reset();
			_taken_by.Clear();
			owner = null;
		}
	}
}