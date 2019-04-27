using UnityEngine;
using System.Collections;
using grid.cell;
using UnityEditor;

namespace grid {
	namespace editor {
		[CustomEditor( typeof( Cell ) ) ]
		public class CellEditor : Editor {
			public override void OnInspectorGUI() {
				DrawDefaultInspector();
				Cell component = ( Cell )target;

				float width = EditorGUILayout.FloatField( "width", component.width );
				float height = EditorGUILayout.FloatField( "height", component.height );

				component.width = width;
				component.height = height;

				if ( GUILayout.Button( "resize" ) ) {
					component.resize();
				}
			}
		}
	}
}