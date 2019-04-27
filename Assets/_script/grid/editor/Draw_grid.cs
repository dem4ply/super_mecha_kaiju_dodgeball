using UnityEngine;
using System.Collections;
using UnityEditor;
using snippet.objects;
using grid;

namespace grid {
	namespace editor {

		[CustomEditor( typeof( Draw_grid ) ) ]
		public class Draw_gridInpector : Editor {
			public override void OnInspectorGUI() {
				DrawDefaultInspector();
				Draw_grid component = ( Draw_grid  )target;


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