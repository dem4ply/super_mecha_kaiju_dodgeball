using UnityEngine;

namespace helper.ui
{
	public class Image
	{
		protected chibi.Chibi_ui _instance;
		protected UnityEngine.Color origin_color;
		protected bool color_has_change;

		public bool has
		{
			get
			{
				return (bool) component;
			}
		}

		public bool has_temp_change
		{
			get
			{
				return color_has_change;
			}
		}

		public bool has_not_temp_change
		{
			get
			{
				return !has_temp_change;
			}
		}

		public UnityEngine.Color color
		{
			get
			{
				return component.color;
			}
			set{
				if ( !color_has_change )
				{
					origin_color = color;
					color_has_change = true;
				}
				component.color = value;
			}
		}

		public float transparency
		{
			set
			{
				UnityEngine.Color c = color;
				c .a = value;
				color = c;
			}
		}

		public UnityEngine.UI.Image component
		{
			get
			{
				return _instance.GetComponent<UnityEngine.UI.Image>();
			}
		}

		public Image( chibi.Chibi_ui instance )
		{
			_instance = instance;
			color_has_change = false;
		}

		public void reset()
		{
			if ( color_has_change )
			{
				color = origin_color;
				color_has_change = false;
			}
		}
	}
}
