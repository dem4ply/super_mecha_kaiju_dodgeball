using UnityEngine;

public class Test_rotation : chibi.Chibi_behaviour
{
	public Vector3 rotation_vector = Vector3.up;
	public Vector3 desire = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnDrawGizmos()
	{
		helper.draw.arrow.gizmo(
			transform.position, rotation_vector, Color.blue );
		helper.draw.arrow.gizmo(
			transform.position, desire, Color.yellow );

		var w = Vector3.SignedAngle( Vector3.forward, desire, Vector3.up );
		var a = Quaternion.AngleAxis( w, rotation_vector );

		var cross = Vector3.Cross( rotation_vector, transform.forward );
		w *= Mathf.Deg2Rad;
		Debug.Log( w );
		var rr =  Vector3.RotateTowards( cross, rotation_vector, w, 0f );

		helper.draw.arrow.gizmo(
			transform.forward, rr, Color.green );
		helper.draw.arrow.gizmo(
			transform.position, cross, Color.red );

		var result = a * transform.forward;
		//helper.draw.arrow.gizmo(
			//transform.position, result, Color.magenta );
		
	}
}
