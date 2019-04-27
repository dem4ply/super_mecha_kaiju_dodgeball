using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using controller.animator;
using controller.motor;
using controller.controllers;
using chibi_base;

namespace controller {
	namespace ai{
		public class Ai: Chibi_behaviour {
			public Controller_base controller;

			protected override void _init_cache()
			{
				base._init_cache();
				if ( controller == null )
					controller =
						transform.GetComponent<Controller_base>();
			}
		}
	}
}
