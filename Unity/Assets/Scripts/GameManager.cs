using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject landEnemyPrefab;
    public GameState gameState;
    public GameObject towerPlace;
    public int ctr;

	// Use this for initialization
	void Start () {
        GenerateTowerPlacer();
        gameState = GameState.none;
	}
	
	// Update is called once per frame
	void Update () {
        SetGrid();
        ctr++;
        if (ctr > 100) {
            SpawnMonster();
            ctr = 0;
        }
	}

    void SetGrid() {
        if (gameState == GameState.none) {
            GameObject planes = GameObject.Find("Planes");
            foreach (Transform t in planes.transform) {
                t.renderer.enabled = false;
            }
        }
        else {
            GameObject planes = GameObject.Find("Planes");
            foreach (Transform t in planes.transform) {
                t.renderer.enabled = true;
            }
        }
    }

    void SpawnMonster() {
        GameObject m = GameObject.Instantiate(landEnemyPrefab) as GameObject;

        m.transform.localPosition = Vector3.zero;
        m.transform.localRotation = Quaternion.identity;
        m.transform.localScale = Vector3.one;

        GameObject land = GameObject.Find("Planes") as GameObject;
        Bounds landBounds = land.GetComponent<Renderer>().bounds;

        m.transform.localPosition = new Vector3(landBounds.extents.x * 2, 1.2f, Random.Range(0, 5) * 2 + land.transform.localPosition.z);
    }

    void GenerateTowerPlacer(){
        GameObject towerPlacerLand = GameObject.Find("Planes") as GameObject;
        float xOrigin = -4f, yOrigin = 0.01f, zOrigin = 4;
        for (int x = 0; x < 9; x++) {
            for (int z = 0; z < 5; z++) {
                GameObject towerPlacer = GameObject.Instantiate(towerPlace) as GameObject;
                towerPlacer.transform.parent = towerPlacerLand.transform;
                towerPlacer.transform.name = "PlacementPlane";

                towerPlacer.transform.localPosition = new Vector3(
                    xOrigin + x,
                    yOrigin,
                    zOrigin - z);

                towerPlacer.transform.localScale = Vector3.one * 0.1f;
            } 
        }
    }

}

public enum GameState {
    none,
    build,
    destroy
}

   
