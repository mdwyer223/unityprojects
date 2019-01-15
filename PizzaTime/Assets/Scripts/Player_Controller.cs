using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public Player_Movement move_script;

    public float speed = 40f;

    protected float horiz_move = 0;
    protected float vert_move = 0;

    protected bool jump = false;
    protected bool double_jump = false;
    protected bool double_jump_allowed = false;
    protected bool dash = false;

    // Update is called once per frame
    void Update()
    {
        horiz_move = Input.GetAxisRaw("Horizontal") * speed;
        vert_move = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            double_jump = true;
        }

        if (Input.GetButtonDown("Dash"))
        {
            dash = true;
        }

    }

    private void FixedUpdate()
    {
        move_script.Move(horiz_move * Time.fixedDeltaTime, false, jump, double_jump, dash);
        jump = false;
        double_jump = false;
        dash = false;
    }
}
