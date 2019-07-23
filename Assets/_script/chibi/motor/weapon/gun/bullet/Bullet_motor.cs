using weapon.ammo;
using chibi.pomodoro;

namespace chibi.motor.weapons.gun.bullet
{
	public class Bullet_motor : Motor
	{
		protected float velocity_smooth_x, velocity_smooth_y;
		protected float velocity_smooth_z;

		public Ammo ammo;
		public float life_span;
		protected Pomodoro _life_span;

		protected virtual void Update()
		{
			if( _life_span.tick() )
				ammo.push( this );
		}

		protected override void _init_cache()
		{
			base._init_cache();
			_life_span = Pomodoro.CreateInstance<Pomodoro>();
			_life_span.is_enable = life_span > 0f;
			_life_span.frecuency = life_span;
		}
	}
}
