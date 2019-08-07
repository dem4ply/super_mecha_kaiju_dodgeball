using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using chibi.manager.collision;
using chibi.motor;


namespace chibi.editor.motor
{

	[CustomEditor( typeof( Motor ), true )]
	public class Motor_editor : Editor
	{
		SerializedProperty current_speed;

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			DrawPropertiesExcluding( serializedObject, ignore_properties() );

			Motor motor = ( Motor )target;

			if ( motor.debug_mode )
				draw_debug_mode( motor );

			draw_speed_control( motor );

			draw_steering( motor );
		}

		public virtual void draw_debug_mode( Motor motor )
		{
			current_speed = serializedObject.FindProperty( "current_speed" );
			EditorGUILayout.PropertyField( current_speed );
		}

		public virtual void draw_speed_control( Motor motor )
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField( "speed control", EditorStyles.boldLabel );
			// EditorGUILayout.BeginHorizontal();
			motor.desire_speed = EditorGUILayout.Slider(
				"desire speed", motor.desire_speed, 0, motor.max_speed );
			// EditorGUILayout.EndHorizontal();
			motor.max_speed = EditorGUILayout.FloatField( "max speed", motor.max_speed );
			motor.velocity_acceleration = EditorGUILayout.Vector3Field(
				"velocity acceleration", motor.velocity_acceleration );
		}

		public virtual void draw_steering( Motor motor )
		{
			motor.is_steering = EditorGUILayout.Foldout(
				motor.is_steering, "is steering" );
			if ( motor.is_steering )
			{
				motor.steering_mass = EditorGUILayout.FloatField(
					"mass", motor.steering_mass );
			}
		}

		protected virtual string[] ignore_properties()
		{
			string[] ignore = new string[] {
				"current_speed", "is_steering", "steering_mass", "desire_speed",
				"max_speed", "velocity_acceleration" };
			return ignore;
		}
	}
}
