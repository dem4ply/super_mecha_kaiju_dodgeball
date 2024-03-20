using UnityEngine;
using UnityEngine.UI;

namespace metroidvania.grid
{
    [System.Serializable]
	public class Chibi_grid_ui<T>: Chibi_grid<T>
	{
		// protected RectTransform rect_transform;

		public override void debug()
		{
			UnityEngine.Debug.Log( string.Format( "chibi grid ui shape: {0}, {1}", this.width, this.height ) );
		}

		/// <summary>
		/// calcula el offsect del UI para escalar el grid con el UI
		/// </summary>
		public override float offsect
		{
			get
			{
				CanvasScaler scaler = helper.game_object.canvas.find_canvas().GetComponent<CanvasScaler>();
				float refecence_width = scaler.referenceResolution.x;
				float refecence_height = scaler.referenceResolution.y;
				float match = scaler.matchWidthOrHeight;
				float offect = ( Screen.width / refecence_width ) * ( 1 - match ) + ( Screen.height / refecence_height ) * match;
				return offect;
			}
		}

        public override Vector3 get_world_position(int x, int y)
        {
			//Debug.Log( string.Format( "scale factor {0}", offsect_ui ) );
			return origin.position + new Vector3( x, -y, 0 ) * ( size * this.offsect );
        }

		public override void get_x_y_from_ui( Vector3 vector, out int x, out int y )
		{
			float relative_grid_x = vector.x - rect_transform.position.x;
			float relative_grid_y = rect_transform.position.y - vector.y;

			float size_offsect = size * offsect;
			x = Mathf.FloorToInt( relative_grid_x / size_offsect );
			y = Mathf.FloorToInt( relative_grid_y / size_offsect );
		}

		public override void move_to_world_position( GameObject obj, int x, int y )
		{
			//Vector3 desire_position = get_world_position( x, y );
			Vector3 offset_to_center = get_world_position_center_cell( x, y );
			//offset_to_center = offset_to_center * 0.5f;
			obj.transform.position = offset_to_center;
		}

		public virtual void move_to_world_position(
			GameObject obj, int x, int y, int width, int height )
		{
			//Vector3 desire_position = get_world_position( x, y );
			Vector3 offset_to_center = get_world_position_center_cell( x, y, width, height );
			//offset_to_center = offset_to_center * 0.5f;
			obj.transform.position = offset_to_center;
		}
	}
}
