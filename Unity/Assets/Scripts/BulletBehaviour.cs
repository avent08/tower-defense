using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    private float speed = 0f;
    private float velocity = 4f;
    private Vector3 defaultPosition;
    public float bulletPower = 5;
    private Monster monster;

	// Use this for initialization
	void Start () {
        defaultPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(defaultPosition.x + (speed+=(velocity*Time.deltaTime)),defaultPosition.y,defaultPosition.z);
        if (gameObject.transform.position.x > 10f)
            DestroyImmediate(gameObject);
    }
}
