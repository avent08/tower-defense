using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
    public MonsterState monsterState;
    public float attackPower = 0.2f;
    public float walkSpeed = 1f;
    public float monsterHealth = 20f;
    private const float minPosX = -15f;

    
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
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Tower") {
            monsterState = MonsterState.attack;
            target = collider.gameObject.GetComponent<Tower>();
        }
    }
}

public enum MonsterState {
    walk,
    attack
}
