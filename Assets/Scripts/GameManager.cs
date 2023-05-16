using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TypeOfClickOnBlock currentTypeOfClickOnBlock = TypeOfClickOnBlock.Destroy;
    
    public void ChangeTypeOfClickOnBlock()
    {
        currentTypeOfClickOnBlock = TypeOfClickOnBlock.ChangeColor;
    }
}
