using UnityEngine;
using System.Collections;

public class cardlookat : MonoBehaviour {

    public Transform target;
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.transform);
        transform.Rotate(transform.up, 180f);
	}
}
