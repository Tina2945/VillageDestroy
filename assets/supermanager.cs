using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class supermanager : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    public GameObject super;
    public GameObject superlight;

    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
        super.SetActive(true);

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Destroy(gameObject);
        //littleknife.SetActive(true);
        superlight.SetActive(true);

    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
