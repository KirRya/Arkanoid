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

    [SerializeField]
    public GameObject effect;

    private Color effectColor;

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space) && !isMoveBanMove) {
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

        Vector2 acceleration = new Vector2() {
            x = speed * Mathf.Cos(angle * Mathf.Deg2Rad),
            y = speed * Mathf.Sin(angle * Mathf.Deg2Rad)
        };

        ballRigidBody.AddForce(acceleration);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "blockPrefab(Clone)") {
            collision.gameObject.SetActive(false);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.name == "BottomBound") {
            ballRigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    private void move() {

        Vector3 moveVector = new Vector3();

        if (ball.transform.position.y > DefineBorders.GameZone.endHeight)
        {
            moveVector = Vector3.Reflect(ball.transform.position, Vector3.down * 2);
            ballRigidBody.AddForce(moveVector);
        }
        else if (ball.transform.position.x < DefineBorders.GameZone.startWidth)
        {
            moveVector = Vector3.Reflect(ball.transform.position, Vector3.right * 2);
            ballRigidBody.AddForce(moveVector);
        }
        else if (ball.transform.position.x > DefineBorders.GameZone.endWidth)
        {
            moveVector = Vector3.Reflect(ball.transform.position, Vector3.left);
            ballRigidBody.AddForce(moveVector);
        }
        else if (ball.transform.position.y < DefineBorders.GameZone.startHeight)
            Debug.Log("DEAD");


    }
}
