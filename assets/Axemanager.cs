using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Axemanager : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    public GameObject axe;
    public GameObject axelight;
    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
        axe.SetActive(true);
    }
    // Use this for initialization
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Destroy(gameObject);
        //littleknife.SetActive(true);
        axelight.SetActive(true);

    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
