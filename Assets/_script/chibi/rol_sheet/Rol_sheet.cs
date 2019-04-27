using UnityEngine;
using System.Collections.Generic;
using chibi.rol_sheet.buff;


namespace chibi.rol_sheet
{
	public class Rol_sheet: chibi.Chibi_behaviour
	{
		public Sheet sheet;
		[ SerializeField ]
		public List<Buff_attacher> buffos;
		protected List<Buff_attacher> buffos_are_going_to_remove;

		protected float _current_hp = -1f;
		protected float _raw_hp = 1f;
		protected float _const_added_hp = 0f;
		protected float _persentil_hp = 1f;

		public float max_hp
		{
			get {
				return _raw_hp;
			}
			set {
				_raw_hp = value;
			}
		}

		public float hp
		{
			get {
				return _current_hp;
			}
			set {
				_current_hp = Mathf.Clamp( value, 0f, max_hp );
			}
		}

		public void attach_buff( Buff buff )
		{
			Buff_attacher buff_attacher;
			buff_attacher = new Buff_attacher( buff, this );
			buffos.Add( buff_attacher );
		}

		public void unattach_buff( Buff_attacher buff )
		{
			buff.buff.unattach( this );
			buffos_are_going_to_remove.Add( buff );
		}

		protected override void _init_cache()
		{
			base._init_cache();
			buffos = new List<Buff_attacher>();
			buffos_are_going_to_remove = new List<Buff_attacher>();
		}

		public void clean()
		{
			foreach ( var buff in buffos_are_going_to_remove )
			{
				buffos.Remove( buff );
			}
			buffos_are_going_to_remove.Clear();
		}
	}
}