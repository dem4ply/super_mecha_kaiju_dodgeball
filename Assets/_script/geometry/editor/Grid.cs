using UnityEngine;
using System.Collections;
using UnityEditor;
using snippet.objects;

namespace geometry{
	namespace grid {
		namespace editor {

			[CustomEditor( typeof( Grid ) )]
			public class GridInpector : Editor {
				public override void OnInspectorGUI() {
					DrawDefaultInspector();
					Grid component = ( Grid )target;


					EditorGUILayout.FloatField( "width", component.width );
					EditorGUILayout.FloatField( "height", component.height );

					component.columns = EditorGUILayout.IntField( "columns", component.columns );
					component.rows = EditorGUILayout.IntField( "rows", component.rows );

					if ( GUILayout.Button( "resize" ) ) {
						component.resize();
					}

					if ( GUILayout.Button( "Activate cells" ) ) {
						component.activate_cells( true );
					}
					if ( GUILayout.Button( "Disable cells" ) ) {
						component.activate_cells( false );
					}

					if ( GUILayout.Button( "enable colliders" ) ) {
						component.activate_colliders_cells( true );
					}
					if ( GUILayout.Button( "disable colliders" ) ) {
						component.activate_colliders_cells( false );
					}
				}
			}
		}
	}
}