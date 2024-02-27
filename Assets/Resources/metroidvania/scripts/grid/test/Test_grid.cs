using UnityEngine;
using System.Collections.Generic;
using chibi.controller;
using UnityEngine.InputSystem;
using chibi.joystick;
using metroidvania.controller.player;


namespace metroidvania.grid
{
	public class Test_grid: chibi.Chibi_behaviour
	{
        protected override void _init_cache()
        {
            base._init_cache();
			var grid = new Chibi_grid<int>( 20, 10 );
			grid.debug();
        }
    }
}
