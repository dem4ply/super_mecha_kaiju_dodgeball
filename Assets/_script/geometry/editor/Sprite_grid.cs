using UnityEngine;
using System.Collections;
using UnityEditor;
using snippet.objects;

namespace geometry{
	namespace grid {
		namespace editor {

			[CustomEditor( typeof( Sprite_grid ) )]
			public class SpriteGridInpector : Editor{
				public override void OnInspectorGUI() {
					DrawDefaultInspector();
					Sprite_grid component = ( Sprite_grid )target;


					EditorGUILayout.FloatField( "width", component.width );
					EditorGUILayout.FloatField( "height", component.height );

					component.columns = EditorGUILayout.IntField( "columns", component.columns );
					component.rows = EditorGUILayout.IntField( "rows", component.rows );

					component.base_cell = (geometry.cell.Cell)EditorGUILayout
						.ObjectField( "Cell",
							component.base_cell, typeof( geometry.cell.Cell ), true );

					if ( GUILayout.Button( "resize" ) ) {
						component.resize();
					}

					if ( GUILayout.Button( "clean_container" ) ) {
						component.container.clean();
					}
				}
			}
		}
	}
}
