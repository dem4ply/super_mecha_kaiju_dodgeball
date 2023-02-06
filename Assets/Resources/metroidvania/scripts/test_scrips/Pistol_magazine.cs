using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using metroidvania.controller.weapons.gun.bullet;
using metroidvania.inventory.item;
using metroidvania.inventory.item.container;

namespace metroidvania.test
{
	public class Pistol_magazine : chibi.Chibi_behaviour
	{

		public bool shot_b = false;
		public bool reload_m_2 = false;
		public bool reload_m_1 = false;
		public bool swap_magazine = false;
		public bool eject_magazine = false;
		public bool chambering_b = false;

		public bool is_semiautomatic = true;

		public metroidvania.inventory.item.Cartridge cartridge;

		public metroidvania.inventory.item.Cartridge chamber;

		public chibi.inventory.Inventory_stack magazine;
		public chibi.inventory.Inventory_stack magazine_2;
		public int bullet_1;
		public Magazine magazine_3;
		public int bullet_2;
		public Magazine magazine_4;
		public chibi.weapon.gun.Linear_gun gun;

		public bool is_empty
		{
			get {
				return magazine_3.is_empty;
			}
		}

		public bool is_not_empty
		{
			get {
				return !is_empty;
			}
		}

		private void Update()
		{
			if ( magazine_3 )
				bullet_1 = magazine_3.amount;
			if ( magazine_4 )
				bullet_2 = magazine_4.amount;
			if ( shot_b )
			{
				shot_b = false;
				shot();
			}

			if ( chambering_b )
			{
				chambering_b = false;
				chambering();
			}

			if ( reload_m_1 )
			{
				reload_m_1 = false;
				magazine_3.push( cartridge );
			}

			if ( swap_magazine )
			{
				swap_magazine = false;
				(magazine_3, magazine_4) = (magazine_4, magazine_3);
			}

			if ( reload_m_2 )
			{
				reload_m_2 = false;
				magazine_3 = Magazine.CreateInstance<Magazine>();
				magazine_3.push( cartridge );
				magazine_3.push( cartridge );
				magazine_3.push( cartridge );
				magazine_4 = Magazine.CreateInstance<Magazine>();
			}



			if ( eject_magazine )
			{
				eject_magazine = false;
				magazine_3 = null;
			}
		}

		protected void chambering()
		{
			if ( is_empty )
			{
				debug.warning(
					"no deberia de intentar de poner la bala en la recamara porque la "
					+ "revista esta vacia" );
			}
			else
			{
				Cartridge cartridge = pop_from_magazine();
				chamber = cartridge;
			}
		}

		protected Cartridge pop_from_magazine()
		{
			chibi.inventory.item.Item item = magazine_3.pop();
			Cartridge cartridge = item as Cartridge;
			return cartridge;
		}

		public void shot()
		{
			if ( chamber )
			{
				var bullet = chamber.pop();
				gun.shot( bullet, true );
				chamber = null;
				if ( is_semiautomatic )
					chambering();
			}
			else
			{
				debug.warning( "no hay bala en la recamara" );
			}
		}
	}
}
