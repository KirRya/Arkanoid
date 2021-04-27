using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private float initPositionY;

    private Vector2 currentMousePosition;

    private const float platformOffset = 0.65f;

    
    private Vector2 cursorPosition;
    void Start() {
        initPositionY = transform.position.y;
    }

    void Update() {
        move();
    }

    void move() {
        currentMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (currentMousePosition.x - platformOffset > DefineBorders.GameZone.startWidth && 
            currentMousePosition.x + platformOffset < DefineBorders.GameZone.endWidth) {

            float positionX = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0)).x;
            transform.position = new Vector3(positionX, initPositionY, 0);
        }
    }
}
