using UnityEngine;
using System.Collections;

public class Probe : MonoBehaviour {
	public Transform target;
	float speed;

	void Start () {
		speed = 100;
	}
	
	// Update is called once per frame
	void Update () {

		if (target == null)
			return;
	
		transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

	}

	public void setTarget(Transform tar)
	{
		target = tar;
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("ToDestoroy!");
		GameObject.Destroy (this);
	}
}
