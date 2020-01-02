using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using chibi.manager.collision;
using chibi.motor.npc;
using chibi.motor;


namespace chibi.editor.motor.npc
{
	[CustomEditor( typeof( Motor_side_scroll ) )]
	public class Motor_side_scroll_editor : Motor_editor
	{
		public static bool show_jump_forces = false;

		public override void OnInspectorGUI()
		{
			is_going_to_draw_gravity = false;
			base.OnInspectorGUI();
			Motor_side_scroll motor = ( Motor_side_scroll )target;

			draw_jump_control( motor );
			serializedObject.Update();
			serializedObject.ApplyModifiedProperties();
		}

		protected override void draw_gravity( Motor motor_old )
		{
			Motor_side_scroll motor = ( Motor_side_scroll )motor_old;
			var old_width = EditorGUIUtility.labelWidth;
			//EditorGUIUtility.labelWidth = 70f;
			//EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField( "gravity:", motor.gravity.ToString() );
			EditorGUILayout.LabelField(
				"gravity when fall:", motor.gravity_when_fall.ToString() );
			EditorGUILayout.LabelField(
				"gravity in wall:",
				( motor.gravity * motor.multiplier_velocity_wall_slice ).ToString() );
			EditorGUILayout.LabelField(
				"gravity slope:", motor.slope_gravity.ToString() );
			EditorGUILayout.LabelField(
				"max jump:", motor.max_jump_velocity.ToString() );
			EditorGUILayout.LabelField(
				"min jump:", motor.min_jump_heigh.ToString() );
			//EditorGUILayout.EndHorizontal();
			EditorGUIUtility.labelWidth = old_width;
		}

		public virtual void draw_jump_control( Motor_side_scroll motor )
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField( "jump", EditorStyles.boldLabel );
			draw_gravity( motor );

			//EditorGUILayout.BeginHorizontal();
			var jump_time = EditorGUILayout.FloatField(
				"jump time", motor.jump_time );
			if ( jump_time != motor.jump_time )
			{
				motor.jump_time = jump_time;
				Undo.RecordObject( motor, "change jump time" );
			}

			var falling_time = EditorGUILayout.FloatField(
				"falling time", motor.falling_time );
			if ( falling_time != motor.falling_time )
			{
				motor.falling_time = falling_time;
				Undo.RecordObject( motor, "change falling time" );
			}


			var max_jump_heigh = EditorGUILayout.FloatField(
				"max jump height", motor.max_jump_heigh );
			if ( max_jump_heigh != motor.max_jump_heigh )
				motor.max_jump_heigh = max_jump_heigh;

			var min_jump_heigh = EditorGUILayout.FloatField(
				"min jump height", motor.min_jump_heigh );
			if ( min_jump_heigh != motor.min_jump_heigh )
				motor.min_jump_heigh = min_jump_heigh;
			//EditorGUILayout.EndHorizontal();
			motor.multiplier_velocity_wall_slice = EditorGUILayout.Slider(
				"grabity in wall",
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
					"leap", motor.wall_jump_leap );
				EditorGUI.indentLevel -= 1;
			}
		}

		protected override string[] ignore_properties()
		{
			var ignore = base.ignore_properties();
			string[] ignore_2 = new string[] {
				"gravity", "multiplier_velocity_wall_slice", "wall_jump_climp",
				"wall_jump_off", "wall_jump_leap", "slope_gravity", "_jump_time",
				"_falling_time", "_gravity_when_fall" };
			return ignore.Union( ignore_2 ).ToArray();
		}
	}
}
