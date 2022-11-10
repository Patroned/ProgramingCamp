using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputAction : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }//�ƶ�����
    public bool JumpInput { get; private set; }//��Ծ����

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        JumpInput = context.performed;
    }
}
