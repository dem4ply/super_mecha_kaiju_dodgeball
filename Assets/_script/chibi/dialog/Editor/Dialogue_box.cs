using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using snippet.objects;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;


namespace chibi.dialog.editor
{
	[CustomEditor( typeof( Dialogue_box ), true )]
	public class AnimatorAvatarInspector : Editor
	{
		SerializedProperty m_emotion;

		protected virtual void OnEnable()
		{
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			var component = ( Dialogue_box )target;
			GUILayout.BeginHorizontal();
			var start_dialog = GUILayout.Button( "start dialog" );
			var prev_dialog = GUILayout.Button( "prev dialog" );
			var next_dialog = GUILayout.Button( "next dialog" );
			GUILayout.EndHorizontal();
			if ( EditorApplication.isPlaying )
			{
				if ( start_dialog )
					component.start_dialogue();
				if ( prev_dialog )
					component.previous_dialog();
				if ( next_dialog )
					component.next_dialog();
			}
		}
	}
}