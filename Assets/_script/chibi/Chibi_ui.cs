using UnityEngine;

namespace chibi
{
	public class Chibi_ui : Chibi_behaviour
	{
		public void hide()
		{
			gameObject.SetActive( false );
		}

		public void show()
		{
			gameObject.SetActive( true );
		}

		public void toggle()
		{
			gameObject.SetActive( !gameObject.activeSelf );
		}
	}
}
