using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAndBowScript : MonoBehaviour {

	private Rigidbody myBody;

	public float speed = 30f;
	public float deactive_Timer = 3f;
	public float damage = 15f;

	void Awake ()
    {
		myBody = GetComponent<Rigidbody>();
    }


	// Use this for initialization
	void Start () {
		Invoke("DeactivateGameObject", deactive_Timer);
	}

	public void Launch(Camera mainCamera)
    {
		myBody.velocity = mainCamera.transform.forward * speed;

		transform.LookAt(transform.position + myBody.velocity);	
    }
	
	void DeactivateGameOdject()
    {
		if (gameObject.activeInHierarchy)
        {
			gameObject.SetActive(false);	
        }
    }

	void OnTriggerEnter(Collider target)
    {
		// after we touch an enemy deactivate game object
    }

}// class






