using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("移动参数")]
    public float speed = 2.0f; // 移动速度

    [Header("跳跃参数")]
    public float jumpHeight = 0.6f; // 跳跃高度

    [Header("重力参数")]
    public float gravity = -9.81f; // 重力
    public float groundDistance = 0.2f; // 射线长度(越小越精确)

    private CharacterController controller; // 角色控制器
    private Vector3 velocity; // 速度向量
    private bool isGrounded; // 是否在地面上

    void Start()
    {
        // 获取角色控制器组件
        controller = GetComponent<CharacterController>();

        // 禁止角色上坡或上楼梯
        controller.slopeLimit = 0;
        controller.stepOffset = 0.0f;
    }

    void Update()
    {
        HandleMovement(); // 处理移动
        //HandleJump(); // 处理跳跃和重力
        ApplyGravity();// 应用重力
    }

    void HandleMovement()
    {
        // 获取输入（WASD 或 箭头键）
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // 根据输入计算世界坐标下的移动方向
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
        move = move.normalized; // 归一化

        // 更新位置
        controller.Move(move * speed * Time.deltaTime);
    }

    void HandleJump()
    {
        // 地面检测
        Vector3 groundCheckPosition = transform.position - new Vector3(0, controller.height / 2, 0);
        isGrounded = Physics.Raycast(groundCheckPosition, Vector3.down, groundDistance);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 确保角色不粘在地面上
        }

        // 处理跳跃
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // 计算跳跃速度
        }
    }

    void ApplyGravity()
    {
        // 应用重力
        velocity.y += gravity * Time.deltaTime;
        // 移动角色
        controller.Move(velocity * Time.deltaTime);
    }
}
