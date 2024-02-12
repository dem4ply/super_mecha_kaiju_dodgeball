using System;
using Unity.Mathematics;
using UnityEngine;

namespace metroidvania.grid
{
	public class Grid_ui: chibi.Chibi_behaviour
	{
		public Chibi_grid<int> grid;

        protected override void _init_cache()
        {
            base._init_cache();
			if ( grid == null )
				this.debug.error( "no tiene asignado un grid" );
			else
			{
				grid.init();
				grid.origin = this.transform;
			}

			grid.show_debug();
        }
	}
}
