using helper.game_object;
using UnityEngine;

namespace chibi
{

	public class Chibi_ui : Chibi_behaviour
	{
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
