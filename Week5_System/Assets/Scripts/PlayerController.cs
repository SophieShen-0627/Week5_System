using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float PlayermovingSpeed = 2f;
    private Rigidbody2D playerrigidbody;

    [SerializeField] GameObject PositionIndicate;
    void Start()
    {
        playerrigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMove();
        PlayerShowSelectableColor();
    }

    private void PlayerMove()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        playerrigidbody.velocity = new Vector2(moveInput * PlayermovingSpeed, playerrigidbody.velocity.y);
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
