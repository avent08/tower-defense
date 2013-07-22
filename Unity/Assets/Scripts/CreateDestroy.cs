using UnityEngine;
using System.Collections;

public class CreateDestroy : MonoBehaviour {
    private string buttonName;
    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        buttonName = transform.name;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void OnClick () {
        if (buttonName == "btnCreate") {
            gameManager.gameState = GameState.build;
        }
        else if (buttonName == "btnDestroy") {
            gameManager.gameState = GameState.destroy;
        }
	}
}
