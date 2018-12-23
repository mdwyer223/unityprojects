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
    protected bool jump_key_up = true;

    // Update is called once per frame
    void Update()
    {
        horiz_move = Input.GetAxisRaw("Horizontal") * speed;
        vert_move = Input.GetAxisRaw("Vertical");

        Debug.Log(horiz_move);
        Debug.Log(vert_move);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            if(jump_key_up)
            {
                double_jump = true;
            }
            jump_key_up = false;
        }

        if (Input.GetButtonUp("Jump"))
        {
            jump_key_up = true;
        }

    }

    private void FixedUpdate()
    {
        move_script.Move(horiz_move * Time.fixedDeltaTime, false, jump, double_jump);
        jump = false;
        double_jump = false;
    }
}
