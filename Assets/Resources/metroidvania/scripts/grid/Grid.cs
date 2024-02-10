using System;
using System.Diagnostics;
using UnityEngine;

namespace metroidvania.grid
{
	public class Grid
	{
		protected int width;
		protected int height;

		protected int[,] grid_array;

		public Grid( int width, int height )
		{
			this.width = width;
			this.height = height;

			grid_array = new int[ this.width, this.height ];
		}

		public debug()
		{
			Debug.Log( string.Format( "Grid shape: {0}, {1}", this.width, this.height ) );
		}
	}
}
