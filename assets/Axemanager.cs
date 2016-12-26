using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Axemanager : MonoBehaviour, IPointerDownHandler
{
    public GameObject axe;
   
    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
        axe.SetActive(true);
    }
    // Use this for initialization
  
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
