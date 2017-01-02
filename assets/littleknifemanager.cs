using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class littleknifemanager : MonoBehaviour, IPointerDownHandler , IPointerEnterHandler
{
    public GameObject littleknife;
    public GameObject littleknifelight;

    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
        littleknife.SetActive(true);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Destroy(gameObject);
        //littleknife.SetActive(true);
        littleknifelight.SetActive(true);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Destroy(gameObject);
        //littleknife.SetActive(true);
        littleknifelight.SetActive(false);

    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
