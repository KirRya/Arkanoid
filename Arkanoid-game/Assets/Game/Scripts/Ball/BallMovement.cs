using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private PlatformMovement platformPosition;

    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private Rigidbody2D ballRigidBody;

    [SerializeField]
    private float speed;

    private const float ballOffset = 0.3f;

    private bool isMoveBanMove = false;

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            pushBall(60);
        }
        else if(!isMoveBanMove) {
            moveOnPlatform();
        }
    }

    void moveOnPlatform() {
        this.transform.position = new Vector3(platformPosition.transform.position.x, platformPosition.transform.position.y + ballOffset, 0);
    }

    void pushBall(float angle) {
        isMoveBanMove = true;

        var acceleration = new Vector2
        {
            x = speed * Mathf.Cos(angle * Mathf.Deg2Rad),
            y = speed * Mathf.Sin(angle * Mathf.Deg2Rad)
        };

        ballRigidBody.AddForce(acceleration);
    }
}
