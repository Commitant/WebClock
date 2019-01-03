using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
	// Start is called before the first frame update

	Quaternion rotation1 = Quaternion.Euler(0, -15, 0);
	Quaternion rotation2 = Quaternion.Euler(0, 15, 0);
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		float speed = .3f;
		float t = Mathf.PingPong(Time.time * speed, 1.0f);
		transform.rotation = Quaternion.Slerp(rotation1, rotation2, t); //t
	}
}
