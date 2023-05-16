using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDrag : MonoBehaviour
{
    Camera myCam;

    [SerializeField] RectTransform boxVisual;

    Rect selectionBox;

    Vector2 startPosition;
    Vector2 endPosition;

    private void Start()
    {
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }

    private void Update()
    {
        //when clicked
        if(Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }
        //when dragging
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
        //when release click
        if (Input.GetMouseButtonUp(0))
        {
            SelectBlocks();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
        }
    }

    void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxSize;
    }

    void DrawSelection()
    {
        //do x calculation

        if(Input.mousePosition.x < startPosition.x)
        {
            //dragging left
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            //dragging right
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }
        //do y calculation
        if (Input.mousePosition.y < startPosition.y)
        {
            //dragging down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            //dragging up
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }

    void SelectBlocks()
    {
        //loop thru all blocks
        foreach (var block in BlockSelection.Instance.blockList)
        {
            //if unit is within the bounds of the selection rect
            if (selectionBox.Contains(myCam.WorldToScreenPoint(block.transform.position)))
            {
                BlockSelection.Instance.DragSelect(block);
            }
        }
    }
}
