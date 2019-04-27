using UnityEngine;
using System.Collections.Generic;
using grid.cell.interfaces;
using snippet.objects;

namespace grid {
	namespace interfaces {
		interface i_grid : i_cell {

			i_cell cell { get; }

			i_cell this[int row, int column] { get; }

			Container cell_container { get; }

			int columns { get; }
			int rows { get; }
		}
	}
}
