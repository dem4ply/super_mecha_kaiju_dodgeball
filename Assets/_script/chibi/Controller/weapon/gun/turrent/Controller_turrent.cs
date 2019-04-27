﻿using System.Collections.Generic;
using UnityEngine;
using chibi.weapon.gun;
using rol_sheet;

namespace chibi.controller.weapon.gun.turrent
{
	public class Controller_turrent : Controller
	{
		Gun[] guns;

		protected Rol_sheet _owner;
		public Rol_sheet owner
		{
			get {
				return _owner;
			}
			set {
				_owner = value;
				foreach ( Gun gun in guns )
					gun.owner = value;
			}
		}

		public List<bullet.Controller_bullet> shot()
		{
			var bullets_controller = new List<bullet.Controller_bullet>();
			foreach ( var gun in guns )
			{
				bullets_controller.Add( gun.shot() );
			}
			return bullets_controller;
		}

		protected void search_all_guns()
		{
			guns = GetComponentsInChildren<Gun>();
		}

		protected override void _init_cache()
		{
			base._init_cache();
			search_all_guns();
		}
	}
}
