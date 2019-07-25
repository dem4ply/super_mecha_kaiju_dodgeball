using UnityEngine;
using weapon.stat;
using weapon.ammo;

using chibi.controller.weapon.gun.bullet;


namespace chibi.weapon.gun
{
	public abstract class Gun : Weapon
	{
		public Gun_stat stat;
		public Ammo ammo;

		public Transform position_of_shot;

		public bool automatic_shot = false;

		[HideInInspector] public float last_automatic_shot = 0f;
		protected Vector3 _aim_direction;

		protected int burst_amount = 0;
		protected int amount_of_automatic_shot = 0;

		public Vector3 direction_shot
		{
			get { return transform.forward.normalized; }
		}

		public float rate_fire
		{
			get {
				return 1 / stat.rate_fire;
			}
		}

		public Vector3 aim_direction
		{
			get {
				return _aim_direction;
			}
			set {
				_aim_direction = transform.position + value;
				transform.LookAt( _aim_direction );
			}
		}

		public abstract Controller_bullet shot();

		public override void attack()
		{
			shot();
		}

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !ammo )
			{
				ammo = load_default_ammo() as Ammo;
			}
			if ( !stat )
			{
				stat = load_default_stat() as Gun_stat;
			}
		}

		public virtual void aim_to( Transform target )
		{
			aim_to( target.position );
		}

		public virtual void aim_to( Vector3 position )
		{
			aim_direction = position - transform.position;
		}

		protected virtual chibi.Chibi_object load_default_ammo()
		{
			return Ammo.CreateInstance<Ammo>().find_default<Ammo>();
		}

		protected virtual chibi.Chibi_object load_default_stat()
		{
			return Gun_stat.CreateInstance<Gun_stat>()
				.find_default<Gun_stat>();
		}

		protected void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;
			if ( position_of_shot )
			{
				Gizmos.DrawWireSphere( position_of_shot.position, 0.2f );
				Gizmos.color = Color.red;
				helper.draw.arrow.gizmo( position_of_shot.position, direction_shot );
			}
			else
			{
				Gizmos.DrawWireSphere( transform.position, 0.2f );
				Gizmos.color = Color.red;
				helper.draw.arrow.gizmo( transform.position, direction_shot );
			}
		}

		private void Update()
		{
			if ( automatic_shot )
				do_automatic_shot( Time.deltaTime, this );
		}

		protected virtual void do_automatic_shot( float delta_time, Gun gun )
		{
			gun.last_automatic_shot += delta_time;
			if ( gun.last_automatic_shot > gun.rate_fire )
			{
				gun.last_automatic_shot -= gun.rate_fire;
				gun.shot();
				++amount_of_automatic_shot;
				if ( burst_amount > 0 && burst_amount <= amount_of_automatic_shot )
				{
					burst_amount = 0;
					amount_of_automatic_shot = 0;
					automatic_shot = false;
				}
			}
		}

		public void burst()
		{
			automatic_shot = true;
			burst_amount = stat.burst_amount;
			amount_of_automatic_shot = 0;
		}
	}
}
