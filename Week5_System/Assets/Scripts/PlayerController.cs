using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float PlayermovingSpeed = 3f;
    private Rigidbody2D RB;

    [SerializeField] GameObject PositionIndicate;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0) PlayerMove();
        PlayerShowSelectableColor();
    }

    private void PlayerMove()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        RB.position += new Vector2(moveInput * PlayermovingSpeed * Time.fixedDeltaTime * 0.1f, 0);
        //RB.velocity = new Vector2(moveInput * PlayermovingSpeed, RB.velocity.y);
    }

    private void PlayerShowSelectableColor()
    {
        Vector2 Pos = transform.position;
        float CenterX = Mathf.FloorToInt(Pos.x) + 0.5f;
        float CenterY = Mathf.FloorToInt(Pos.y) + 0.5f;

        Pos = new Vector2(CenterX, CenterY);

        PositionIndicate.transform.position = Pos;
    }
}
