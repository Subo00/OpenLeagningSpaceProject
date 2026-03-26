using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, MaskListener
{
    [Header("Movement")]
    public float move_speed;

    public float ground_drag;

    private float jump_force;
    public float jump_normal;
    public float jump_enhanced;
    public float jump_cooldown;
    public float air_multiplier;
    bool ready_to_jump;

    [Header("Keybinds")]
    public KeyCode jump_key = KeyCode.Space;

    [Header("Ground Check")]
    public float player_height;
    public LayerMask what_is_ground;
    bool grounded;

    public Transform orientation;

    float horizontal_input;
    float vertical_input;

    private Vector3 startingScale;

    Vector3 movement_direction;

    Rigidbody rigid_body;
    
    // Start is called before the first frame update
    private void Start()
    {
        rigid_body = GetComponentInChildren<Rigidbody>();
        rigid_body.freezeRotation = true;
        ready_to_jump = true;
        jump_force = jump_normal;
        MaskChanger.Instance.AddListener(this);
        startingScale = transform.localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, player_height * 0.5f + 0.2f, what_is_ground);
        
        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rigid_body.drag = ground_drag;
        else
            rigid_body.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontal_input = Input.GetAxisRaw("Horizontal");
        vertical_input = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jump_key) && ready_to_jump && grounded)
        {
            ready_to_jump = false;
            Jump();

            Invoke(nameof(ResetJump), jump_cooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        movement_direction = orientation.forward * vertical_input + orientation.right * horizontal_input;

        // on ground
        if (grounded)
            rigid_body.AddForce(movement_direction.normalized * move_speed * 10f, ForceMode.Force);
        // in air
        else if (!grounded)
            rigid_body.AddForce(movement_direction.normalized * move_speed * 10f * air_multiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flat_velocity = new Vector3(rigid_body.velocity.x, 0f, rigid_body.velocity.z);

        // limit velocity if needed
        if (flat_velocity.magnitude > move_speed)
        {
            Vector3 limited_velocity = flat_velocity.normalized * move_speed;
            rigid_body.velocity = new Vector3(limited_velocity.x, rigid_body.velocity.y, limited_velocity.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rigid_body.velocity = new Vector3(rigid_body.velocity.x, 0f, rigid_body.velocity.z);

        rigid_body.AddForce(transform.up * jump_force, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        ready_to_jump = true;
    }

    public void OnMaskChange(Mask mask)
    {
        ResetPlayer();
        if(mask == Mask.GREEN)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }else if(mask == Mask.ORANGE)
        {
            jump_force = jump_enhanced;
        }
    }

    private void ResetPlayer()
    {
        jump_force = jump_normal;
        transform.localScale = startingScale;
    }
}
