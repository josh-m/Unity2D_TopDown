using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour {
    
    public float speed;
    public Transform mouseIndicator;
    
	// Use this for initialization
	void Start () {
        mouseIndicator = transform.Find("DirectionIndicator");
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		UnityEngine.Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        mouseIndicator.rotation = rot;
        mouseIndicator.transform.eulerAngles = new Vector3(0, 0, mouseIndicator.transform.eulerAngles.z);
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = 0;
        
        float v_input = Input.GetAxis("Vertical");
        rb.AddForce(mouseIndicator.transform.up * speed * v_input);
    }
}
