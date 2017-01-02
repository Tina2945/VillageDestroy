using UnityEngine;
using System.Collections;
using DG.Tweening;
public class GunManager : MonoBehaviour {

	public float MinimumShootPeriod;

	private float shootCounter = 0;

	public GameObject bulletCandidate;

	public void TryToTriggerGun()
	{
		if (shootCounter <= 0) {
			this.transform.DOShakeRotation (MinimumShootPeriod * 0.8f, 3f);

			shootCounter = MinimumShootPeriod;
			GameObject newBullet =  GameObject.Instantiate (bulletCandidate);
			BulletScript bullet = newBullet.GetComponent<BulletScript> ();

		}
	}
	public void Update()
	{
		if (shootCounter > 0) {
			shootCounter -= Time.deltaTime;
		}

	}
}