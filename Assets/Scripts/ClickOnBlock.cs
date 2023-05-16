using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnBlock : MonoBehaviour
{
    GameManager gameManager;

    Color currentColor;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        currentColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    void OnMouseUp()
    {
        switch (gameManager.currentTypeOfClickOnBlock)
        {
            case TypeOfClickOnBlock.Destroy:
                Destroy(gameObject);
                break;
            case TypeOfClickOnBlock.ChangeColor:
                gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                currentColor = gameObject.GetComponent<MeshRenderer>().material.color;
                break;
        }
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
    }

    private void OnMouseEnter()
    {
        currentColor = gameObject.GetComponent<MeshRenderer>().material.color;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
    }
}
