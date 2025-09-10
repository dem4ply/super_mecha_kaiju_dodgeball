using helper.game_object;
using UnityEngine;

namespace chibi
{

	public class Chibi_ui : Chibi_behaviour
	{
		public bool should_prepare_rect = false;
		protected RectTransform _rect_transform;

		public RectTransform rect_transform
		{
			get {
				return _rect_transform;
			}
		}

        protected override void _init_cache()
        {
            base._init_cache();
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
	}
}
