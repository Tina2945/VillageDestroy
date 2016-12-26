using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class stickmanager : MonoBehaviour, IPointerDownHandler
{
    public GameObject stick;
    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
        stick.SetActive(true);
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
