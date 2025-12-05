using UnityEngine;
using System;
using NUnit.Framework;
using Mono.Cecil;
// using Unity.Entities;

namespace helper.tests
{
	public class basic_test
	{
		// protected World world;
		[SetUp]
		public virtual void set_up()
		{
		}

	}

	public class Scene_test : basic_test
	{
		protected GameObject scene;

		public virtual string scene_dir
		{
			get { throw new NotImplementedException(); }
		}

		public virtual YieldInstruction min_wait
		{
			get {
				return new WaitForSeconds( 0.1f );
			}
		}

		public virtual YieldInstruction wait_second
		{
			get {
				return new WaitForSeconds( 1f );
			}
		}

		[SetUp]
		public virtual void Instanciate_scenary()
		{
			/*
			var rat = typeof( GameObjectArray );
			var hybridhooks = new System.Type[] {
				rat.Assembly.GetType(
					"Unity.Entities.GameObjectArrayInjectionHook" ),
				rat.Assembly.GetType(
					"Unity.Entities.TransformAccessArrayInjectionHook" ),
				rat.Assembly.GetType(
					"Unity.Entities.ComponentArrayInjectionHook" )
			};

			//world = new World( "test world" );
			foreach ( var hook in hybridhooks )
			{
				InjectionHookSupport.RegisterHook(
					Activator.CreateInstance( hook ) as InjectionHook );
			}
			var manager = World.Active.GetOrCreateManager<EntityManager>();
			*/
			scene = Resources.Load( scene_dir ) as GameObject;
			if ( scene == null )
				Assert.Fail(
					string.Format(
						"no se pudo cargar la scena en '{0}'", scene_dir ) );
			scene = instantiate._( scene );
		}

		[TearDown]
		public virtual void clean_scenary()
		{
			game_object.clean.scene();
		}

		/// <summary>
		/// carga los recursos asumiendo que son GameObjects pensado para prefabs
		/// </summary>
		/// <param name="path">ruta del prefab en Resouorces</param>
		/// <returns>GameObject del prefab</returns>
		public virtual GameObject load_reasource( string path )
		{
			var obj = Resources.Load( path ) as GameObject;
			if ( obj == null )
				Assert.Fail(
					string.Format(
						"no sse pudo cargar el recurso '{0}'", path) );
			return obj;
		}

		/// <summary>
		/// funcion para cargar script objects de resources
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="path">ruta del script object tiene que estar en la carpeta de Resources</param>
		/// <returns></returns>
		public virtual T load_script_object<T>( string path ) where T : UnityEngine.Object
		{
			var obj = Resources.Load<T>( path );
			if ( obj == null )
				Assert.Fail(
					string.Format(
						"no sse pudo cargar el recurso '{0}'", path) );
			return obj;
		}
	}
}
