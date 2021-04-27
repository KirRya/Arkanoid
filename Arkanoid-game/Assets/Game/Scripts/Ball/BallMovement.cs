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
            pushBall();
        }
        else if(!isMoveBanMove) {
            moveOnPlatform();
        }
    }

    void moveOnPlatform() {
        this.transform.position = new Vector3(platformPosition.transform.position.x, platformPosition.transform.position.y + ballOffset, 0);
    }

    void pushBall() {
        isMoveBanMove = true;

        Vector2 acceleration = new Vector2() {
            x = speed * Random.Range(DefineBorders.GameZone.startWidth, DefineBorders.GameZone.endWidth),
            y = speed * Random.Range(DefineBorders.GameZone.endHeight / 2, DefineBorders.GameZone.endHeight)
        };

        ballRigidBody.AddForce(acceleration);
    }
}
