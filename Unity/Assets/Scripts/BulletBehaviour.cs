using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    private float speed = 0f;
    private Vector3 defaultPosition;

	// Use this for initialization
	void Start () {
        defaultPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(defaultPosition.x + (Time.deltaTime*(speed+=1f)),defaultPosition.y,defaultPosition.z);
        if (gameObject.transform.position.x > 10f)
            DestroyImmediate(gameObject);

        
    }
}
