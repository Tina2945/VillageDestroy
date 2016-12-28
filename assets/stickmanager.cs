using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class stickmanager : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    public GameObject stick;
    public GameObject sticklight;
    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
        stick.SetActive(true);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Destroy(gameObject);
        //littleknife.SetActive(true);
        sticklight.SetActive(true);

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
