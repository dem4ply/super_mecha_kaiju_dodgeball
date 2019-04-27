using UnityEngine;
using System.Collections;
using UnityEditor;
using snippet.objects;

namespace grid {
	namespace editor {

		[CustomEditor( typeof( Grid ) ) ]
		public class GridInpector : Editor {
			public override void OnInspectorGUI() {
				DrawDefaultInspector();
				Grid component = ( Grid )target;


				EditorGUILayout.FloatField( "width", component.width );
				EditorGUILayout.FloatField( "height", component.height );

				component.cell_container = (Container)EditorGUILayout.ObjectField(
					"Container", component.cell_container, typeof( Container ), true );

				component.columns = EditorGUILayout.IntField( "columns", component.columns );
				component.rows = EditorGUILayout.IntField( "rows", component.rows );

				if ( GUILayout.Button( "resize" ) ) {
					component.resize();
				}

			}
		}

	}
}