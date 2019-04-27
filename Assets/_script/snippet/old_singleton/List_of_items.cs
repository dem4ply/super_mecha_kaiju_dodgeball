using UnityEngine;
using System.Collections;

public class List_of_items : Singleton<List_of_items> {	
	protected List_of_items(){}
	
	public Test_items test;
}

[System.Serializable]
public class Test_items{
	public GameObject test_1;
	public GameObject test_2;
	public GameObject test_3;
}
