using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject landEnemyPrefab;
    public GameState gameState;
    public GameObject towerPlace;
    public int ctr;
    private static UILabel moneyLabel;
    public static int money = 100;

	// Use this for initialization
	void Start () {
        moneyLabel = GameObject.Find("moneyLabel").GetComponent<UILabel>() as UILabel;
        moneyLabel.text = "Your Money = $ " + money;
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

    public static void buyTower(TowerCategories towerCategory)
    {
        if(towerCategory == TowerCategories.Weak)
            money -= 40;
        else if (towerCategory == TowerCategories.Average)
            money -= 60;
        else if (towerCategory == TowerCategories.Strong)
            money -= 80;
        else if (towerCategory == TowerCategories.Powerful)
            money -= 100;

        moneyLabel.text = "Your Money = $ " + money;
        
    }

    public static void getMoney()
    {
        money += 20;
        moneyLabel.text = "Your Money = $ " + money;
    }

}

public enum GameState {
    none,
    build,
    destroy
}

public enum TowerCategories { 
    Weak,
    Average,
    Strong,
    Powerful
}

   
