using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class supermanager : MonoBehaviour, IPointerDownHandler
{
    public GameObject super;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
        super.SetActive(true);

    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
