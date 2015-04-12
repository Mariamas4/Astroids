using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public float size;
	public enum A_type {GOLD, IRON, WATER, OXGEN};
	public GameObject target;
	public A_type current_type;
	public GameObject nasaLogo;

	void Start () {
	
		target.gameObject.SetActive (false);
		nasaLogo.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	
		transform.Rotate(Random.Range(.1f, .25f), Random.Range(.140f, .20f), Random.Range(.05f, .0730f)) ;

	}

	public void showTarget()
	{
		target.gameObject.SetActive (true);
		//Show scan button
		//StartCoroutine ();
		//deactivate
		StartCoroutine (Deactivate(25));


	}



	public IEnumerator Deactivate(int t = 5){

		yield return new WaitForSeconds (t);
		target.gameObject.SetActive (false);

	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "probe")
			nasaLogo.gameObject.SetActive (true);

			
	
	}


}
