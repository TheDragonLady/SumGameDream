using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public enum PlayerStates { Walk, Idle, JumpKeyDown, JumpKeyUp, WallSlide, Push}
public enum FacingDirection { Left, Right }


[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    public PlayerStates _ps;
    public FacingDirection _fd;
    public Controller2D controller;
    public Animation_Script animScript;
    public Vector2 directionalInput;
    public Vector2 playerMovement;
    public bool holdingPull;


    Bunny_Pos bunny;
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);
        playerMovement.x = directionalInput.x;
        playerMovement.y = player.velocity.y;
        AnimateCharacter(playerMovement);
        GetButtons();

        switch (_ps)
        {
            case PlayerStates.Idle:
                animScript.PlayIdle();
                animScript.NotJumping();
                animScript.NotWallSliding();
                break;
            case PlayerStates.Walk:
                animScript.PlayRun();
                animScript.NotJumping();
                animScript.NotWallSliding();
                animScript.NotPushing();
                break;
            case PlayerStates.JumpKeyDown:
                animScript.Jumping();
                animScript.NotWallSliding();
                break;
            case PlayerStates.JumpKeyUp:
                animScript.NotJumping();
                break;
            case PlayerStates.WallSlide:
                animScript.IsHolding();
                animScript.NotJumping();
                break;
            case PlayerStates.Push:
                animScript.Pushing();
                break;
        }

        switch (_fd)
        {
            case FacingDirection.Left:
                animScript.LookLeft();
                break;
            case FacingDirection.Right:
                animScript.LookRight();
                break;
        }
    }

    private void GetButtons()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.walkSpeed = player.sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.walkSpeed = 6f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetButtonUp("Jump"))
        {
            player.OnJumpInputUp();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            holdingPull = true;
        }
        else
        {
            holdingPull = false;
        }
    }

    public void AnimateCharacter(Vector2 _playerMovement)
    {
        if (_playerMovement.y == 0 ) //if not jumping
        {
            if (!holdingPull)
            {
                if (_playerMovement.x > 0) //if moving right
                {
                    _fd = FacingDirection.Right;
                    _ps = (PlayerStates.Walk);
                }
                else if (_playerMovement.x < 0) //if moving left
                {
                    _fd = (FacingDirection.Left);
                    _ps = (PlayerStates.Walk);
                }
                else // if not moving at all
                {
                    _ps = (PlayerStates.Idle);
                }
            }
            else
            {
                if (_playerMovement.x > 0)
                {
                    _fd = FacingDirection.Right;
                    _ps = (PlayerStates.Push);
                }
                else if (_playerMovement.x < 0)
                {
                    _fd = FacingDirection.Left;
                    _ps = (PlayerStates.Push);
                }
            }
        }
        else if(_playerMovement.y > 0 || _playerMovement.y < 0) //player is in the air
        {
            if (player.wallSliding)
            {
                if (_playerMovement.x > 0) //if moving right
                {
                    _fd = FacingDirection.Left;
                    _ps = (PlayerStates.WallSlide);
                }
                else if (_playerMovement.x < 0) //if moving left
                {
                    _fd = FacingDirection.Right;
                    _ps = (PlayerStates.WallSlide);
                }
            }
            else //not wallsliding
            {
                if (_playerMovement.x > 0) //if moving right
                {
                    _fd = FacingDirection.Right;
                    _ps = PlayerStates.JumpKeyDown;
                }
                else if (_playerMovement.x < 0) //if moving left
                {
                    _fd = (FacingDirection.Left);
                    _ps = (PlayerStates.JumpKeyDown);
                }
            }
        } 


        //else if(_directionalMovement.y > 0f)
        //{

        //    AnimStates(PlayerStates.JumpKeyDown, FacingDirection.Right);
        //    animScript.Jumping();
        //}
        //else
        //{
        //    animScript.NotJumping();
        //}

        //if (player.wallSliding == true)
        //{
        //    animScript.IsHolding();
        //}
        //else if (player.wallSliding == false && player.velocity.y == 0f)
        //{
        //    animScript.IsNotHolding();
        //}

        //if (player.wallSliding == false && player.velocity.y != 0f)
        //{
        //    animScript.IsNotHolding();
        //    animScript.Jumping();
        //}

        //if (player.wallSliding == false && player.velocity.y != 0f)
        //{
        //    animScript.WallJump();
        //}

    }

}
