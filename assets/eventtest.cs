using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class eventtest : MonoBehaviour, IPointerDownHandler
{
    public GameObject bomb;
    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
        bomb.SetActive(true);
    }
    // Use this for initialization

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
