using UnityEngine;
using System.Collections;

namespace helper {
	public class time{
		public static float get_delta_time(float time){
			return Time.time - time;
		}
	}
}