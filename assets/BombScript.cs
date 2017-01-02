using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

	public float waitTime;
	public GameObject Boom;

	void Start(){
		StartCoroutine ("Boommer");
	}

	IEnumerator Boommer(){
		yield return new WaitForSeconds (waitTime);
		Boom.gameObject.transform.parent = null;
		Boom.gameObject.SetActive (true);
		KillYourself ();
	}

	public void KillYourself()
	{
		GameObject.Destroy (this.gameObject);
	}

	void OntriggerEnter(Collider other){
		other.gameObject.SendMessage ("Hit", 100);
	}


}
