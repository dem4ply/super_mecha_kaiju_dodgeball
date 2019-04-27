using UnityEngine;
using Unity.Entities;
using chibi.motor;

namespace chibi.systems.dialog
{
	public class Dialogue_box: ComponentSystem
	{
		struct group
		{
			public chibi.dialog.Dialogue_box dialogue_box;
		}

		protected override void OnUpdate()
		{
			float delta_time = Time.deltaTime;
			foreach ( var entity in GetEntities<group>() )
			{
				var dialogue = entity.dialogue_box;
				if ( dialogue.put_texy )
				{
					dialogue.total_delta_time += delta_time;
					float total_of_letters =
						( dialogue.letters_by_second * dialogue.total_delta_time );

					// detener el calculo cuando escriba todas las letras
					if ( total_of_letters >= dialogue.current_text.Length )
					{
						dialogue.put_texy = false;
						dialogue.pull_all_text();
					}
					else
						dialogue.dialogue_box.text = dialogue.current_text.Substring(
							0, Mathf.RoundToInt( total_of_letters ) );

				}
			}
		}
	}
}
