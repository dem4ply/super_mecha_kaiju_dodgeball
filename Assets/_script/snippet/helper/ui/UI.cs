using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace helper.ui
{
	public class UI
	{
		protected chibi.Chibi_ui _instance;
		public Image image;

		public UI( chibi.Chibi_ui instance )
		{
			_instance = instance;
			image = new Image( _instance );
		}
	}
}
