using UnityEngine;
using System.Collections;

public class PlacementPlane : MonoBehaviour {
    public GameObject landTowerPrefab;
    private Texture2D defaultTexture;
    private Texture2D highlightTexture;

	private void Start () {
        defaultTexture = Resources.Load("Textures/boxdefault") as Texture2D;
        highlightTexture = Resources.Load("Textures/boxhighlight") as Texture2D;
	}

    private void OnMouseOver() {
        transform.renderer.material.mainTexture = highlightTexture;
        transform.renderer.material.color = new Color(
            transform.renderer.material.color.r,
            transform.renderer.material.color.g,
            transform.renderer.material.color.b,
            255f / 255f);
    }

    private void OnMouseExit() {
        transform.renderer.material.mainTexture = defaultTexture;
        transform.renderer.material.color = new Color(
            transform.renderer.material.color.r, 
            transform.renderer.material.color.g, 
            transform.renderer.material.color.b, 
            150f / 255f);
    }

    private void OnMouseDown() {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager.gameState == GameState.build) {
            if (transform.childCount <= 0) {
                GameObject box = GameObject.Instantiate(landTowerPrefab) as GameObject;

                box.transform.parent = transform;
                box.transform.localPosition = Vector3.zero;
                box.transform.localPosition = new Vector3(0, 2f, 0);
                box.transform.localRotation = Quaternion.identity;
                box.transform.localScale = Vector3.one * 10;
            }
            else {
                Debug.Log("You can't build here");
            }
        }
        else if (gameManager.gameState == GameState.destroy) {
            if (transform.childCount > 0) DestroyImmediate(transform.GetChild(0).gameObject);
        }
        gameManager.gameState = GameState.none;
    }

    private void Update() {
	    
	}
}
