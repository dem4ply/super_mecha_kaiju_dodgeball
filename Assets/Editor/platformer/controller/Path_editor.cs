using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using platformer.controller.wagon;

namespace platformer.editor.controller.wagon
{
	[CustomEditor( typeof( Wagon ), true )]
	public class Wagon_editor : chibi.editor.Chibi_behavior_editor
	{
		protected Wagon wagon;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
		}

		private void OnEnable()
		{
			wagon = ( Wagon )target;
			if ( !wagon.path )
			{
				var path = helper.game_object.Find._<
					chibi.path.Path_behaviour >( wagon.gameObject, "path" );
				if ( !path )
				{
					wagon.debug.error( "no se encontro el path en el wagon" );
				}
			}

			if ( !wagon.controller )
			{
			}
		}
	}
}
