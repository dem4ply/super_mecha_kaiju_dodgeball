using UnityEngine;


namespace chibi.pomodoro
{
	[ CreateAssetMenu( menuName="chibi/pomodoro/base" ) ]
	public class Pomodoro : chibi.Chibi_object
	{
		public float frecuency = 0f;
		public float _sigma_frecuency = 0f;

		public bool is_time
		{
			get {
				return frecuency >= _sigma_frecuency;
			}
		}

		public void reset()
		{
			_sigma_frecuency = 0f;
		}

		public bool tick()
		{
			_sigma_frecuency += Time.deltaTime;
			return is_time;
		}

		public bool tick( float delta_time )
		{
			_sigma_frecuency += delta_time;
			return is_time;
		}
	}
}

