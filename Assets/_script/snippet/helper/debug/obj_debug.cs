using UnityEngine;

namespace helper
{
	namespace debug
	{
		public static class obj_debug
		{
			public static void info( object msg )
			{
				info( msg.ToString() );
			}

			public static string full_name
			{
				get { return "debug"; }
			}

			public static string type_name
			{
				get { return "static"; }
			}

			public static void info( string msg, params object[] list )
			{
				msg = string.Format( msg, list );
				UnityEngine.Debug.Log( string.Format(
					"[{0}]{{{1}}} {2}", type_name, full_name, msg )
				);
			}

			public static void log( object msg )
			{
				log( msg.ToString() );
			}

			public static void log( string msg, params object[] list )
			{
				info( msg, list );
			}

			public static void warning( object msg )
			{
				warning( msg.ToString() );
			}

			public static void warning( string msg, params object[] list )
			{
				msg = string.Format( msg, list );
				UnityEngine.Debug.LogWarning( string.Format(
					"[{0}]{{{1}}} {2}", type_name, full_name, msg ) );
			}

			public static void error( object msg )
			{
				error( msg.ToString() );
			}

			public static void error( string msg, params object[] list )
			{
				msg = string.Format( msg, list );
				UnityEngine.Debug.LogError( string.Format(
					"[{0}]{{{1}}} {2}", type_name, full_name, msg ) );
			}

			public static void pause()
			{
				UnityEngine.Debug.Break();
			}
		}
	}
}
