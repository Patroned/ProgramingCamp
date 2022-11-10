using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("�ƶ�״̬")]
    [Tooltip("�ƶ��ٶ�")]
    public float moveSpeed = 10f;

    [Header("��Ծ״̬")]
    [Tooltip("��Ծ����")]
    public float jumpForce = 15f;

    [Header("Check")]
    [Tooltip("���������")]
    public float groundCheckRadius = 0.3f;
    [Tooltip("������ͼ��")]
    public LayerMask groundCheckLayer;

    [Tooltip("ǽ�������")]
    public Vector2 wallCheckRange = new Vector2(1, 1);
    [Tooltip("������ͼ��")]
    public LayerMask wallCheckLayer;
}

