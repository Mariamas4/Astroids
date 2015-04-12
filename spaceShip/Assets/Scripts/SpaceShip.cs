using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour {

	RaycastHit hit;
	float distance;

	//Transform currentAstroid;
	Asteroid currentAstroid;

	public RectTransform ScanButton, shotButton;
	public Text detailsText;
	public GameObject probePrefab;

	public AudioClip lunch;

	public Transform probePosition; 
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,2000f)){
			//	Debug.Log("Hello");
				if(hit.collider.name == "Astroid") {
					if(currentAstroid != null){
						StartCoroutine (currentAstroid.Deactivate(0));
						StartCoroutine(cleanData(0));
					}
					currentAstroid = hit.collider.transform.GetComponent<Asteroid>();
//					Debug.Log("curr: " + currentAstroid);

					showAsteriodTarget(currentAstroid);
					ScanButton.gameObject.SetActive (true);
					Debug.Log("scan: " + ScanButton.gameObject.activeSelf);
					//Debug.Log("I am ");
				}else if(hit.collider.tag == "planet"){
				

				}
			}
		}

	
	}

	void showAsteriodTarget(Asteroid Aster)
	{
		Aster.GetComponent<Asteroid>().showTarget();
		//distance = Vector3.Distance (transform.position, Aster.position);

	}

	public void showAsteroidData()
	{
		shotButton.gameObject.SetActive (true);
		detailsText.gameObject.SetActive (true);
		distance = Mathf.Round( Vector3.Distance (transform.position, currentAstroid.transform.position));
		detailsText.text = "Diameter: " + currentAstroid.size + "Km \n" +
					 	"Distance: "+(distance *13 )+"Km \n" +
				"Contents: " + currentAstroid.current_type.ToString() +"";
	}

	public IEnumerator cleanData(int i =50)
	{ 
		yield return new WaitForSeconds (i);
		//ScanButton.gameObject.SetActive (false);
		shotButton.gameObject.SetActive (false);
		detailsText.text = "";
		detailsText.gameObject.SetActive (false);
	}


	 
	public void ShotDrone()
	{
		Debug.Log ("target: ");
		GameObject GameObj =  (Instantiate (probePrefab, probePosition.position, probePosition.rotation)) as GameObject; 
		Probe probe = GameObj.GetComponent<Probe> (); 
		//play sound
		//yield return new WaitForSeconds (10);
		//play soundt
		Debug.Log (probe);

		probe.setTarget (currentAstroid.transform);
		audio.PlayOneShot (lunch);

		//playsound
	}

}
