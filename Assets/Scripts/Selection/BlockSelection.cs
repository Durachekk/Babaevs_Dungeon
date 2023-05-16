using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSelection : MonoBehaviour
{
    public List<GameObject> blockList = new List<GameObject>();
    public List<GameObject> blockSelected = new List<GameObject>();

    private static BlockSelection _instance;
    public static BlockSelection Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject blockToAdd)
    {
        DeselectAll();
        blockSelected.Add(blockToAdd);
    }

    public void DragSelect(GameObject blockToAdd)
    {
        if (!blockSelected.Contains(blockToAdd))
        {
            blockSelected.Add(blockToAdd);
            //blockToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void DeselectAll()
    {
        blockSelected.Clear();
    }

    public void Deselect(GameObject blockToDeselect)
    {

    }
}
