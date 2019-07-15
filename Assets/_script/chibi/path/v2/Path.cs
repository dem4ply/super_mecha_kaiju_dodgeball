﻿using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace chibi.path
{
	public enum path_types
	{
		free, aligment
	}

	[System.Serializable]
	public class Path
	{
		public List<Segment> segments;
		public Transform container;

		protected path_types _type;

		public path_types type
		{
			get { return _type; }
			set {
				if ( type != value )
				{
					_type = value;
					if ( type == path_types.free )
						change_to_free();
					if ( type == path_types.aligment)
						change_to_aligment();
				}
			}
		}

		public Path( Transform center )
		{
			container = center;
			segments = new List<Segment> { new Segment( center, container ) };
		}

		public Path( Transform center, Path path )
		{
			container = center;
			segments = new List<Segment> { new Segment( center, container ) };
			type = path.type;
		}

		public void add_segment_relative( Vector3 direction )
		{
			var segment = segments.Last();
			Segment new_segment = null;
			if ( type == path_types.free )
				new_segment = new Segment(
					segment, segment.p2.position + direction );
			else if ( type == path_types.aligment )
				new_segment = new Segment_aligment(
					segment, segment.p2.position + direction );
			segments.Add( new_segment );
			relink();
			rename_points();
		}

		public IEnumerable<Transform> plain_points()
		{
			foreach ( Segment segment in segments )
			{
				yield return segment.p1;
				yield return segment.c1;
				yield return segment.c2;
			}
			yield return segments.Last().p2;
		}

		protected void change_to_free()
		{
			List<Segment> new_segmnets = new List<Segment>( segments.Count );
			foreach ( var segment in segments )
				new_segmnets.Add( new Segment( segment ) );
			segments = new_segmnets;
			relink();
			rename_points();
		}

		protected void change_to_aligment()
		{
			List<Segment> new_segmnets = new List<Segment>( segments.Count );
			foreach ( var segment in segments )
				new_segmnets.Add( new Segment_aligment( segment ) );
			segments = new_segmnets;
			relink();
			rename_points();
		}

		protected void relink()
		{
			for ( int i = 1; i < segments.Count; ++i )
			{
				segments[ i - 1 ].next = segments[i];
				segments[i].previous = segments[ i - 1 ];
			}
		}

		protected void rename_points()
		{
			List<Transform> points = new List<Transform>();
			for ( int i = 0; i < segments.Count; ++i )
			{
				segments[ i ].p1.name = string.Format( "{0}__p1", i );
				segments[ i ].p2.name = string.Format( "{0}__p2", i );
				segments[ i ].c1.name = string.Format( "{0}__c1", i );
				segments[ i ].c2.name = string.Format( "{0}__c2", i );
				points.Add( segments[ i ].p1 );
				points.Add( segments[ i ].p2 );
				points.Add( segments[ i ].c1 );
				points.Add( segments[ i ].c2 );
			}
			for ( int i = container.childCount - 1; i > 0; --i )
			{
				var child = container.GetChild( i );
				if ( points.Find( ( t ) => t == child ) == null )
				{
					GameObject.DestroyImmediate( child.gameObject );
				}
			}
		}
	}
}