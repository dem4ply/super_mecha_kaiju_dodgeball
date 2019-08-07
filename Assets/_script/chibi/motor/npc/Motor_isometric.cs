using UnityEngine;
using chibi.manager.collision;

namespace chibi.motor.npc
{
	public class Motor_isometric : Motor
	{
		public override Vector3 desire_direction
		{
			set {
				base.desire_direction = new Vector3( value.x, 0, value.z );
			}
		}

		protected override void update_motion()
		{
			ridgetbody.velocity = new Vector3(
				desire_velocity.x, ridgetbody.velocity.y,
				desire_velocity.z );
			current_speed = desire_velocity;
		}

		#region propiedades publicas
		public virtual Chibi_collision_isometric collision_manager_side_scroll
		{
			get { return manager_collision as Chibi_collision_isometric; }
		}
		#region propiedades conocer el estado de las coliciones
		public virtual bool is_grounded
		{
			get { return collision_manager_side_scroll.is_grounded; }
		}

		public virtual bool is_not_grounded
		{
			get { return !is_grounded; }
		}

		public virtual bool is_walled
		{
			get { return collision_manager_side_scroll.is_walled; }
		}

		public virtual bool is_not_walled
		{
			get { return !is_walled; }
		}

		public virtual bool is_walled_left
		{
			get { return collision_manager_side_scroll.is_walled_left; }
		}

		public virtual bool is_walled_right
		{
			get { return collision_manager_side_scroll.is_walled_right; }
		}

		public virtual bool no_is_walled_left
		{
			get { return !is_walled_left; }
		}

		public virtual bool no_is_walled_right
		{
			get { return !is_walled_right; }
		}
		#endregion
		#endregion

		public virtual void on_died()
		{
			debug.info( "murio" );
		}

		public virtual void on_end_died()
		{
			debug.info( "termino de morir" );
		}
	}
}
