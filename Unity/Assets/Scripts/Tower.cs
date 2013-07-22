using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
    public float towerHealth;
    public float attackPower;
	// Use this for initialization
	void Start () {
	
	}

    void Attack() { 
        
    }
	
	// Update is called once per frame
	void Update () {
        if (towerHealth <= 0f) {
            DestroyImmediate(gameObject);
        }
	}
}
