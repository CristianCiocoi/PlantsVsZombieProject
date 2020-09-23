using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();//makes a game obj in our hierarchy called Defenders and here all of the defenders clones will appear
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        // Debug.Log("clicks in the box collider area");
        AttemptToPlaceDefenderAt(GetSquareClicked());

    }


    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;

    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }

    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //clicking on a position and then that position is assinged to the var
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos); //whether clickPos is we want to take that and convert to screen to world Position
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    } 

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender; // as GameObject so we can see it in the hierarchy, we can manipulate if we need too
        newDefender.transform.parent = defenderParent.transform;//its instantiated as a child to our defender parent
    }
}
