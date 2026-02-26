using UnityEngine;
using System.Collections.Generic;
using System;

namespace chibi.spawner
{
	public class Spawner : chibi.Chibi_behaviour
	{
		public virtual GameObject spawn()
		{
			throw new NotImplementedException("funcion spawn no implementada");
		}

		/// <summary>
		/// funcion para spawnerar usando los eventos de unity
		/// </summary>
		public virtual void simple_spawn()
		{
			spawn();
		}
	}
}