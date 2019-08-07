using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using chibi.manager.collision;
using chibi.motor.npc;


namespace chibi.editor.motor.npc
{
	[CustomEditor( typeof( Motor_side_scroll ) )]
	public class Motor_side_scroll_editor : Motor_editor
	{
		public static bool show_jump_forces = false;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			Motor_side_scroll motor = ( Motor_side_scroll )target;

			draw_jump_control( motor );
			serializedObject.Update();
		}

		public virtual void draw_jump_control( Motor_side_scroll motor )
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField( "jump", EditorStyles.boldLabel );
			var old_width = EditorGUIUtility.labelWidth;
			EditorGUIUtility.labelWidth = 70f;
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField( "gravity:", motor.gravity.ToString() );
			EditorGUILayout.LabelField( "max jump:", motor.max_jump_velocity.ToString() );
			EditorGUILayout.LabelField( "min jump:", motor.min_jump_heigh.ToString() );
			EditorGUILayout.EndHorizontal();
			EditorGUIUtility.labelWidth = old_width;

			EditorGUILayout.BeginHorizontal();
			motor.max_jump_heigh = EditorGUILayout.FloatField(
				"max jump height", motor.max_jump_heigh );
			motor.min_jump_heigh = EditorGUILayout.FloatField(
				"min jump height", motor.min_jump_heigh );
			EditorGUILayout.EndHorizontal();
			motor.multiplier_velocity_wall_slice = EditorGUILayout.Slider(
				"multiplier of gravity on wall",
				motor.multiplier_velocity_wall_slice, 0, 1 );

			show_jump_forces = EditorGUILayout.Foldout(
				show_jump_forces, "jump vectors", true, EditorStyles.boldLabel );
			if ( show_jump_forces )
			{
				EditorGUI.indentLevel += 1;
				motor.wall_jump_climp = EditorGUILayout.Vector3Field(
					"climp", motor.wall_jump_climp );
				motor.wall_jump_off = EditorGUILayout.Vector3Field(
					"off", motor.wall_jump_off );
				motor.wall_jump_leap = EditorGUILayout.Vector3Field(
					"off", motor.wall_jump_leap );
				EditorGUI.indentLevel -= 1;
			}
		}

		protected override string[] ignore_properties()
		{
			var ignore = base.ignore_properties();
			string[] ignore_2 = new string[] {
				"gravity", "multiplier_velocity_wall_slice", "wall_jump_climp",
				"wall_jump_off", "wall_jump_leap" };
			return ignore.Union( ignore_2 ).ToArray();
		}
	}
}
