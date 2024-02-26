using UnityEngine;
using UnityEngine.UI;

namespace helper.game_object
{
	public class canvas
	{
		public static GameObject find_canvas()
		{
			var canvas = helper.game_object.Find._( consts.game_object_names.canvas );
            return canvas;
		}

        public static Image add_img_canvas( GameObject parent, Sprite img, string name )
        {
            RectTransform obj = new_ui_element( parent, name );

            Image image = obj.gameObject.AddComponent< Image >();
            image.sprite = img;
            return image;

        }

        public static RectTransform new_ui_element( GameObject parent, string name )
        {
            var obj = new GameObject( name );
            RectTransform transform = obj.AddComponent< RectTransform >();
            transform.transform.SetParent( parent.transform );
            transform.localScale = Vector3.one;
            transform.anchoredPosition = new Vector3( 0f, 0f );
            // transform.sizeDelta= new Vector2(150, 200); // custom size
            return transform;
        }
	}
}
