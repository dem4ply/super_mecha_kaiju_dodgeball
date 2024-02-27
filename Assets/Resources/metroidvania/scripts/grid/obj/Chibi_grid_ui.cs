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
	}
}
