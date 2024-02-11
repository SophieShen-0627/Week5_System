using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelector : MonoBehaviour
{
    [SerializeField] GameObject MousePositionIndicator;
    [SerializeField] Transform PlayerPositionIndicator;

    [SerializeField] GameObject[] Blocks = new GameObject[3];

    public int CurrentBlockIndex = 0;                       //0: white, 1:red, 2:blue


    [SerializeField] int ShowMouse = 0;         //0:too far to show; 1: not show, able to delete; 2: show, able to create.

    // Update is called once per frame
    void Update()
    {
        GetMousePosition();
        if (ShowMouse == 2) CreateBlock(CurrentBlockIndex);
        if (ShowMouse == 1 && CheckMousePos() < 5)
        {
            DeleteBlock(CurrentBlockIndex);
        }
        if (ShowMouse != 2 && CheckMousePos() < 5)
        {
            SelectColor();
        }
    }

    private void CreateBlock(int Index)
    {
        Vector2 MousePos = Input.mousePosition;
        Vector2 PosInWorld = Camera.main.ScreenToWorldPoint(MousePos);
        PosInWorld = new Vector2(CountMiddlePoint(PosInWorld.x), CountMiddlePoint(PosInWorld.y));

        if (Input.GetMouseButtonDown(0) && ColorManager.instance.ColorNum >= Index +1)
        {
            ColorManager.instance.ColorNum -= Index + 1;
            Instantiate(Blocks[Index], PosInWorld, Quaternion.identity);
        }
    }

    private void DeleteBlock(int index)
    {
        Vector2 MousePos = Input.mousePosition;
        Vector2 PosInWorld = Camera.main.ScreenToWorldPoint(MousePos);
        RaycastHit2D hit = Physics2D.Raycast(PosInWorld, Vector2.zero);

        if (hit.collider.GetComponent<Block>())
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(hit.collider.gameObject);
                ColorManager.instance.ColorNum += index + 1;
            }
        }
    }

    private void SelectColor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CurrentBlockIndex = CheckMousePos();
        }
    }
    private void GetMousePosition()
    {
        Vector2 MousePos = Input.mousePosition;
        Vector2 PosInWorld = Camera.main.ScreenToWorldPoint(MousePos);
        PosInWorld = new Vector2(CountMiddlePoint(PosInWorld.x), CountMiddlePoint(PosInWorld.y));

        if (PosInWorld.x > PlayerPositionIndicator.position.x - 1.5f && PosInWorld.x < PlayerPositionIndicator.position.x + 1.5f)
        {
            if (PosInWorld.y > PlayerPositionIndicator.position.y - 1.5f && PosInWorld.y < PlayerPositionIndicator.position.y + 1.5f)
            {
                ShowMouse = 2;
            }
            else ShowMouse = 0;
        }
        else ShowMouse = 0;

        int dc = CheckMousePos();
        if (dc <= 5 && ShowMouse ==2) ShowMouse = 1;

        if (ShowMouse == 2) MousePositionIndicator.GetComponent<SpriteRenderer>().enabled = true;
        else MousePositionIndicator.GetComponent<SpriteRenderer>().enabled = false;
        MousePositionIndicator.transform.position = PosInWorld;
    }

    private int CheckMousePos()           //check if there is already a collider on mouse position
    {
        Vector2 MousePos = Input.mousePosition;
        Vector2 PosInWorld = Camera.main.ScreenToWorldPoint(MousePos);
        PosInWorld = new Vector2(CountMiddlePoint(PosInWorld.x), CountMiddlePoint(PosInWorld.y));

        RaycastHit2D hit = Physics2D.Raycast(PosInWorld, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<Block>())
            {
                return hit.collider.GetComponent<Block>().BlockIndex;
            }
            else return 5;             
        }
        else return 10;                
    }

    private float CountMiddlePoint(float X)
    {
        X = Mathf.FloorToInt(X) + 0.5f;
        return X;
    }
}
