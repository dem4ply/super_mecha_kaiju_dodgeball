using System;
using System.Xml;
using helper;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace metroidvania.grid
{
	[System.Serializable]
	public class Chibi_grid_ui<T>: Chibi_grid<T>
	{
		// protected RectTransform rect_transform;

		public override void debug()
		{
			UnityEngine.Debug.Log( string.Format( "chibi grid ui shape: {0}, {1}", this.width, this.height ) );
		}
	}
}
