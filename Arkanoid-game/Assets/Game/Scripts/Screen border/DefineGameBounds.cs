using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineGameBounds : MonoBehaviour
{
    [SerializeField]
    private GameObject leftBound;

    [SerializeField]
    private GameObject rightBound;

    [SerializeField]
    private GameObject topBound;

    [SerializeField]
    private GameObject bottomBound;

    private BoxCollider2D leftCollider;
    private BoxCollider2D rightCollider;
    private BoxCollider2D topCollider;
    private BoxCollider2D bottomCollider;

    void Start()
    {
        InitColliders();
        InitBounds();
    }

    void InitColliders() {
        leftCollider   = leftBound.  GetComponent<BoxCollider2D>();
        rightCollider  = rightBound. GetComponent<BoxCollider2D>();
        topCollider    = topBound.   GetComponent<BoxCollider2D>();
        bottomCollider = bottomBound.GetComponent<BoxCollider2D>();
    }

    void InitBounds() {
        leftBound.transform.position = new Vector3(DefineBorders.GameZone.startWidth, 0, 0);
        leftCollider.size = new Vector2(0.2f, DefineBorders.height * 2);

        rightBound.transform.position = new Vector3(DefineBorders.GameZone.endWidth, 0, 0);
        rightCollider.size = leftCollider.size;

        topBound.transform.position = new Vector3(0, DefineBorders.topOffset + BlockView.rowIncreaseValue, 0);
        topCollider.size = new Vector2(DefineBorders.width, 0.2f);

        bottomBound.transform.position = new Vector3(0, DefineBorders.GameZone.startHeight * 2, 0);
        bottomCollider.size = topCollider.size;
    }

}
