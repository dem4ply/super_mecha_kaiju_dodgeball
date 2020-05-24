using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace dr_stone.ui
{
	public class Gather_slot_ui : chibi.Chibi_ui
	{
		public chibi.inventory.item.Item item;
		public UnityEngine.UI.Image sprite;
		public TMPro.TextMeshProUGUI text;

		protected void Update()
		{
			if ( item )
			{
				sprite.sprite = item.image;
				text.text = item.name;
			}
			else
			{
				sprite.sprite = null;
				text.text = "";
			}
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !sprite )
			{
				var obj_sprite = transform.Find( "sprite" );
				if ( obj_sprite )
					sprite = obj_sprite.GetComponent<UnityEngine.UI.Image>();
				else
					debug.error( "no se encontro el gameobject sprite" );
			}
			if ( !sprite )
				debug.error( "no esta asignado el sprite para el item" );

			if ( !text )
			{
				var obj_text = transform.Find( "text" );
				if ( obj_text )
					text = obj_text.GetComponent<TMPro.TextMeshProUGUI>();
				else
					debug.error( "no se encontro el gameobject text mesh pro" );
			}
			if ( !text )
				debug.error( "no esta asignado el text mesh pro para el item" );
		}
	}
}
