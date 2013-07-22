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
            gameObject.AddComponent<Detonator>();
            Detonator detonator = gameObject.GetComponent<Detonator>();
            detonator.size = 3;
            detonator.duration = 1f;
            detonator.destroyTime = 1.5f;
            detonator.explodeOnStart = true;
            gameObject.renderer.enabled = false;

            //DestroyImmediate(gameObject);
        }
	}
}
