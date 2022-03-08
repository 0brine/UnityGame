using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public BuildingBlueprint[] availableTurrets;

    public GameObject buildEffect;
    public GameObject destroyEffect;

    private BuildingBlueprint selectedBuilding;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        selectedBuilding = availableTurrets[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasMoney { get { return PlayerStats.Money >= selectedBuilding.cost; } }

    public void select(Tile tile)
    {
        if (!HasMoney)
            return;

        if (tile.building != null)
            return;

        tile.BuildBuilding(selectedBuilding);
    }
}
