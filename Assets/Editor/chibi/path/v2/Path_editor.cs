using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using chibi.path;

namespace chibi.editor.path
{

	[CustomEditor( typeof( Path_behaviour ) )]
	public class Path_editor : Editor
	{
		Path_behaviour creator;
		Path path;
		Transform handler_container;

		public override void OnInspectorGUI()
		{
			EditorGUI.BeginChangeCheck();
			var new_type = (path_types)EditorGUILayout.EnumPopup( path.type );
			if ( new_type != path.type )
			{
				Undo.RecordObject( creator, "change type" );
				path.type = new_type;
			}
			if ( GUILayout.Button( "add segment" ) )
			{
				Undo.RecordObject( creator, "add segment" );
				path.add_segment_relative( Vector3.right );
			}
			if ( GUILayout.Button( "create_new" ) )
			{
				Undo.RecordObject( creator, "create new" );
				creator.create_path();
				path = creator.path;
			}


			if ( GUILayout.Button( "flat y" ) )
			{
				Undo.RecordObject( creator, "flat y" );
				foreach ( var s in path.segments )
				{
					s.vp1 = new Vector3(
						s.vp1.x, creator.transform.position.y, s.vp1.z );
					s.vc1 = new Vector3(
						s.vc1.x, creator.transform.position.y, s.vc1.z );

					s.vp2 = new Vector3(
						s.vp2.x, creator.transform.position.y, s.vp2.z );
					s.vc2 = new Vector3(
						s.vc2.x, creator.transform.position.y, s.vc2.z );
				}
				path = creator.path;
			}

			path.resolution = EditorGUILayout.FloatField(
					"resolution:", path.resolution );
			path.spacing = EditorGUILayout.FloatField( "spacing:", path.spacing );

			if ( GUILayout.Button( "bake" ) )
			{
				Undo.RecordObject( creator, "bake" );
				creator.path.bake();
				create_handlers();
			}

			if ( EditorGUI.EndChangeCheck() )
				SceneView.RepaintAll();

			DrawDefaultInspector();
		}

		protected void OnSceneGUI()
		{
			draw();
			input();
		}

		protected void input()
		{
		}

		protected void draw()
		{
			handdlers_for_move_points();
		}

		protected void handdlers_for_move_points()
		{
			Segment segment = path.segments[ 0 ];
			var p1 = Handles.PositionHandle(
				segment.vp1, Quaternion.identity );

			if ( p1 != segment.vp1 )
			{
				Undo.RecordObject( creator, "move point" );
				segment.vp1 = p1;
			}

			var p2 = Handles.PositionHandle(
				segment.vp2, Quaternion.identity );

			if ( p2 != segment.vp2 )
			{
				Undo.RecordObject( creator, "move point" );
				segment.vp2 = p2;
			}

			var c1 = Handles.PositionHandle(
				segment.vc1, Quaternion.identity );

			if ( c1 != segment.vc1 )
			{
				Undo.RecordObject( creator, "move point" );
				segment.vc1 = c1;
			}

			var c2 = Handles.PositionHandle(
				segment.vc2, Quaternion.identity );

			if ( c2 != segment.vc2 )
			{
				Undo.RecordObject( creator, "move point" );
				segment.vc2 = c2;
			}

			for ( int i = 1; i < path.segments.Count; ++i )
			{
				segment = path.segments[i];

				c1 = Handles.PositionHandle(
					segment.vc1, Quaternion.identity );

				if ( c1 != segment.vc1 )
				{
					Undo.RecordObject( creator, "move point" );
					segment.vc1 = c1;
				}

				p2 = Handles.PositionHandle( segment.vp2, Quaternion.identity );
				if ( p2 != segment.vp2 )
				{
					Undo.RecordObject( creator, "move point" );
					segment.vp2 = p2;
				}

				c2 = Handles.PositionHandle( segment.vc2, Quaternion.identity );
				if ( c2 != segment.vc2 )
				{
					Undo.RecordObject( creator, "move point" );
					segment.vc2 = c2;
				}
			}
		}

		protected void create_handlers()
		{
			if ( !handler_container )
			{
				handler_container = helper.game_object.Find._(
					creator.transform, "handler_container" );

				if ( !handler_container )
					handler_container = new GameObject().transform;
			}
			handler_container.name = "handler_container";
			handler_container.parent = creator.transform;

			for ( int i = handler_container.childCount - 1; i >= 0; --i )
			{
				var child = handler_container.GetChild( i );
				GameObject.DestroyImmediate( child.gameObject );
			}

			for ( int i = 0; i < creator.path_handlers.Count; ++i )
			{
				var handler = creator.path_handlers[i];
				var point = handler.make_point( path );
				point.transform.parent = handler_container.transform;
				point.name = string.Format( "handler__p{0}", i );
			}


		}

		private void OnEnable()
		{
			creator = ( Path_behaviour )target;
			if ( creator.path == null )
				creator.create_path();
			path = creator.path;
		}
	}
}
