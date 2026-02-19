using helper.game_object;
using UnityEngine;
using UnityEngine.UI;

namespace chibi
{

	public class Chibi_ui : Chibi_behaviour
	{
		public helper.ui.UI ui;
		public bool should_prepare_rect = false;
		protected RectTransform _rect_transform;


		public RectTransform rect_transform
		{
			get {
				return _rect_transform;
			}
		}

		public GameObject canvas
		{
			get {
				return helper.game_object.canvas.find_canvas();
			}
		}

		public CanvasScaler scaler
		{
			get {
				 return canvas.GetComponent<CanvasScaler>();
			}
		}

		public Vector2 ratio_scaler
		{
			get {
				// TODO: optimizar esta mierda
				// TODO: eliminar duplicacion en Assets/Resources/inventory/scripts/grid/obj/Chibi_grid_ui.cs
				float refecence_width = scaler.referenceResolution.x;
				float refecence_height = scaler.referenceResolution.y;
				float match = scaler.matchWidthOrHeight;
				float ratio_width = Screen.width / refecence_width;
				float ratio_height = Screen.height / refecence_height;
				return new Vector2( ratio_width, ratio_height );
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			// debug.log( "ui init cache" );
			ui = new helper.ui.UI( this );
			_rect_transform = GetComponent< RectTransform >();
			if ( should_prepare_rect )
				prepare_rect();
		}

		protected virtual void prepare_rect()
		{
		}

		public virtual void hide()
		{
			gameObject.SetActive( false );
		}

		public virtual void show()
		{
			gameObject.SetActive( true );
		}

		public virtual void toggle()
		{
			gameObject.SetActive( !gameObject.activeSelf );
		}

		protected override void Awake()
		{
			base.Awake();
			ui = new helper.ui.UI( this );
			//_init_cache();
		}

		protected override void Start() {
			base.Start();
			ui = new helper.ui.UI( this );
		}

		protected override void _dispose_cache() {
			base._dispose_cache();
			ui = null;
		}

		public Chibi_ui clone()
		{
			var result = helper.instantiate.ui.parent( this, this.canvas );
			return result;
		}
	}
}
