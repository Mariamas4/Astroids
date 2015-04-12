using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

	public float polarDiameter, Gravity;
	public int numberOfMoons;

	public enum P_type {Earth, Mars};
	public GameObject target;
	public P_type current_type;

	void Start () {
		
		target.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate (Random.Range (.09f, .2f), 0, 0);// Random.Range(.020f, .70f), Random.Range(.05f, .0730f)) ;
		
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
	

}
