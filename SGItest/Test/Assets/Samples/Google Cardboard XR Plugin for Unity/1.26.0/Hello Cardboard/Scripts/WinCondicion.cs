using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondicion : MonoBehaviour
{
    private TextMesh tm;
    public GameObject[] objectsToCheck;

    public float yMax = 4f;
    public float yMin = 0f;
    public float xMax = 2.6f;
    public float xMin = -0.6f;
    public float zMax = 2.6f;
    public float zMin = -0.6f;

    void Start()
    {
        tm = gameObject.GetComponent<TextMesh>();
    }

    private bool hasWon = false;

    private void Update()
    {
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (hasWon) return;

        foreach (GameObject obj in objectsToCheck)
        {
            if (obj.transform.position.y <= yMax &&
                obj.transform.position.y >= yMin &&
                obj.transform.position.x <= xMax &&
                obj.transform.position.x >= xMin &&
                obj.transform.position.z <= zMax &&
                obj.transform.position.z >= zMin 
                )
            {
                tm.text = "you win!!!!!";
                Debug.Log("you win!!!!!");
                hasWon = true;
            }
        }

    }
}
