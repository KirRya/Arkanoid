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
        
        if (Input.GetKeyDown(KeyCode.Space) && !isMoveBanMove) {
            pushBall(90);
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

        Vector2 acceleration = new Vector2() {
            x = speed * Mathf.Cos(angle * Mathf.Deg2Rad),
            y = speed * Mathf.Sin(angle * Mathf.Deg2Rad)
        };

        ballRigidBody.AddForce(acceleration);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "blockPrefab(Clone)") {
            collision.gameObject.SetActive(false);
        }
    }
}
