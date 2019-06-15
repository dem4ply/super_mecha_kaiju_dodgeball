using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_arkanoid : chibi.Chibi_behaviour
{
	public SMKD.motor.Dodger_motor dodger;

	protected override void Start()
	{
		base.Start();
		dodger.load_gun();
	}
}
