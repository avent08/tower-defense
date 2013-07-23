using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
    public float towerHealth;
    public float attackPower;
    public GameObject bullet = null;
    private bool shooting = true;
    private Vector3 towerDefaultPosition;
	// Use this for initialization
	void Start () {
        towerDefaultPosition = gameObject.transform.position;

        if (towerHealth > 0f)
            StartCoroutine(Shoot());
	}

	// Update is called once per frame
	void Update () {
        if (towerHealth <= 0f) {
            shooting = false;
            gameObject.AddComponent<Detonator>();
            Detonator detonator = gameObject.GetComponent<Detonator>();
            detonator.size = 3;
            detonator.duration = 1f;
            detonator.destroyTime = 1.5f;
            detonator.explodeOnStart = true;
            gameObject.renderer.enabled = false;
            
        }   
	}

    private IEnumerator Shoot() {
        if (gameObject.activeSelf)
        {
            while (shooting)
            {
                GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
                bullets.transform.name = "bullet";
                bullets.transform.position = new Vector3(towerDefaultPosition.x + 0.5f,towerDefaultPosition.y,towerDefaultPosition.z);
                bullets.transform.localScale = Vector3.one * 0.2f;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
