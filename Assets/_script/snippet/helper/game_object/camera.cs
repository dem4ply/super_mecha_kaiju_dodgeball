using UnityEngine;

namespace helper.game_object
{
	public class camera
	{
		public static Camera maid_camera
		{
			get {
				return helper.game_object.Find._<Camera>(
					helper.consts.game_object_names.main_camera );
			}
		}
	}
}