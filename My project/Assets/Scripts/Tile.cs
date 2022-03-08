using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Vector3 positionOffset;

    public GameObject building;
    private BuildingBlueprint buildingBlueprint;

    private Renderer renderer;
    private Color initialColor;
    private Color hoverColor;

    private BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        renderer = this.GetComponent<Renderer>();
        initialColor = renderer.material.color;
        hoverColor = Color.Lerp(initialColor, Color.white, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        buildManager.select(this);
    }

    public void BuildBuilding(BuildingBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        building = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);

        buildingBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build!");
    }

    private Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseEnter()
    {
        // not over UI
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;

        renderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        renderer.material.color = initialColor;
    }
}
