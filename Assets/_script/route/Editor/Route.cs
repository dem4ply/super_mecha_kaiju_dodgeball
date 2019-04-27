using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using snippet.objects;


namespace route
{
	namespace editor
	{
		[ CustomEditor( typeof( route.Route ), true ) ]
		public class RouteInspector : Editor
		{
			protected float radius, nodes, x, y;
			protected int style_selected;

			public override void OnInspectorGUI()
			{
				DrawDefaultInspector();
				Route component = ( Route )target;

				EditorGUILayout.BeginHorizontal();
				component.current_style = EditorGUILayout.Popup(
					"style", component.current_style, Route.STYLE_SHAPES );
				component.style = Route.STYLE_SHAPES[ component.current_style ];
				bool reshape = GUILayout.Button( "reshape" );
				EditorGUILayout.EndHorizontal();

				inspect_style( component.current_style );

				if ( reshape )
					do_reshape( component.current_style );
			}

			public virtual void inspect_style( int style_selected )
			{
				switch ( style_selected )
				{
					case 0:
						break;
					case 1:
						inspect_circle();
						break;
					case 2:
					case 3:
					case 4:
						inspect_trigonometric();
						break;
					case 5:
						inspect_zig_zag_sqr();
						break;
				}
			}

			public virtual void do_reshape( int style_selected )
			{
				Route c = ( Route )target;
				switch ( c.current_style )
				{
					case 0:
						throw new System.NotImplementedException();
					case 1:
						c.draw_circle();
						break;
					case 2:
					case 3:
					case 4:
						throw new System.NotImplementedException();
					case 5:
						c.draw_zig_zag_sqr();
						break;
				}
			}

			public virtual void inspect_circle()
			{
				Route c = ( Route )target;
				c.nodes = EditorGUILayout.IntField("nodes", c.nodes );
				c.radius = EditorGUILayout.FloatField( "radius", c.radius );
			}

			public virtual void inspect_trigonometric()
			{
				Route c = ( Route )target;
				c.nodes = EditorGUILayout.IntField("nodes", c.nodes );
				x = EditorGUILayout.FloatField( "x", 1 );
				y = EditorGUILayout.FloatField( "y", 1 );
			}

			public virtual void inspect_zig_zag_sqr()
			{
				Route c = ( Route )target;
				c.nodes = EditorGUILayout.IntField("nodes", c.nodes );
				c.radius = EditorGUILayout.FloatField( "width", c.radius );
				c.step_size = EditorGUILayout.FloatField( "height", c.step_size );
				bool get_values_from_points = GUILayout.Button(
					"get values from points" );
				if ( get_values_from_points )
				{
					c.radius = (
						c.points[0].position - c.points[1].position ).magnitude;
					c.step_size = (
						c.points[1].position - c.points[2].position ).magnitude;
				}
			}
		}
	}
}
