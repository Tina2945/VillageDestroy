using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class littleknifemanager : MonoBehaviour, IPointerDownHandler
{
    public GameObject littleknife;
    public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(gameObject);
        littleknife.SetActive(true);
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
