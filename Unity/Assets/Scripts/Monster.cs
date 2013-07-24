using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
    public MonsterState monsterState;
    public float attackPower = 0.2f;
    public float walkSpeed = 1f;
    public float monsterHealth = 20f;
    private const float minPosX = -15f;
    private bool isDestroy = false;
    
    private Tower target;

	// Use this for initialization
	void Start () {
        monsterState = MonsterState.walk;  
	}

    void Walk() {
        transform.Translate(-walkSpeed * Time.deltaTime, 0f, 0f);
    }

    void Attack() {
        Debug.Log("Attack this tower");
        if (target.towerHealth > 0)
            target.GetComponent<Tower>().towerHealth -= attackPower;
        else
            monsterState = MonsterState.walk;
    }
	
	// Update is called once per frame
	void Update () {
        if (monsterState == MonsterState.walk)
            Walk();
        else if (monsterState == MonsterState.attack)
            Attack();

        if (transform.localPosition.x <= minPosX)
            DestroyImmediate(transform.gameObject);

        if (monsterHealth <= 0)
        {            
            gameObject.AddComponent<Detonator>();
            Detonator detonator = gameObject.GetComponent<Detonator>();
            detonator.size = 3;
            detonator.duration = 1f;
            detonator.destroyTime = 1.5f;
            detonator.explodeOnStart = true;
            gameObject.renderer.enabled = false;
            gameObject.collider.enabled = false;
            if(!isDestroy)
                GameManager.getMoney();
            isDestroy = true;
        }

	}

    void OnTriggerStay(Collider collider) {

        if (collider.tag == "Bullet") {
            BulletBehaviour bullet = collider.gameObject.GetComponent<BulletBehaviour>();
            monsterHealth -= bullet.bulletPower;
            Destroy(collider.gameObject);
        }


        if (collider.tag == "Tower" && Vector3.Distance(collider.transform.position, gameObject.transform.position) < 1)
        {
            monsterState = MonsterState.attack;
            target = collider.gameObject.GetComponent<Tower>();            
        }
    }  
}

public enum MonsterState {
    walk,
    attack
}
