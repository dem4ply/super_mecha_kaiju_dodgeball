using UnityEngine;

namespace chibi.animator
{
	public abstract class Animator_base : chibi.Chibi_behaviour
	{
		#region Var public
		public Animator animator;
		#endregion

		#region funciones protegidas
		protected override void _init_cache()
		{
			if ( !animator )
				animator = GetComponent<Animator>();
			if ( !animator )
			{
				Debug.LogError( string.Format(
					"[Animator_base]el gameobject {0} no tiene un animator",
					helper.game_object.name.full( this ) ) );
			}
		}
		#endregion
	}
}
