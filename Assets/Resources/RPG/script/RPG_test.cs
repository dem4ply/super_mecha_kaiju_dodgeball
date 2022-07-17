using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

namespace rpg.manager
{
	public class RPG_test: chibi.Chibi_behaviour
	{

		protected override void _init_cache()
		{
			base._init_cache();
		}

		public void on_attack()
		{
			this.debug.info( "ataco" );
		}
		public void on_defend()
		{
			this.debug.info( "defendio" );
		}

		public void on_run()
		{
			this.debug.info( "corrio" );
		}

	}
}
