using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    GameManager gameManager;

    //Вводим блок
    public GameObject block;

    // Вводим тригеры для нахождения других блоков
    public GameObject positiveXobject;
    CheckOtherObject positiveXtrig;

    public GameObject negativeXobject;
    CheckOtherObject negativeXtrig;

    public GameObject positiveZobject;
    CheckOtherObject positiveZtrig;

    public GameObject negativeZobject;
    CheckOtherObject negativeZtrig;

    Color currentColor;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        // Инициализируем triggered из триггеров
        positiveXtrig = positiveXobject.GetComponent<CheckOtherObject>();
        negativeXtrig = negativeXobject.GetComponent<CheckOtherObject>();
        positiveZtrig = positiveZobject.GetComponent<CheckOtherObject>();
        negativeZtrig = negativeZobject.GetComponent<CheckOtherObject>();
        currentColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }
    /*
    private void Update()
    {
        float turnUp = Input.GetAxis("Vertical");
        float turnRight = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x + (turnRight * Time.deltaTime), transform.position.y + (turnUp * Time.deltaTime), transform.position.z);
    }
    */
    public void UpdateObject()
    {
        if (positiveXtrig.triggered && negativeXtrig.triggered && positiveZtrig.triggered && negativeZtrig.triggered)
        {
            block.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
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
        block.GetComponent<MeshRenderer>().material.color = Color.black;
    }

    private void OnMouseEnter()
    {
        currentColor = block.GetComponent<MeshRenderer>().material.color;
        block.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        block.GetComponent<MeshRenderer>().material.color = currentColor;
    }
}
