using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private float initPositionY;
    
    private Vector2 cursorPosition;
    void Start() {
        initPositionY = transform.position.y;
        initGameZoneBorders();
    }

    void Update() {
        platformMovement();
    }

    void platformMovement() {
        if (Input.GetMouseButtonDown(0)) {
            float positionX = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0)).x;
            transform.position = new Vector3(positionX, initPositionY, 0);
        }
    }

    void initGameZoneBorders() {

    }
}
