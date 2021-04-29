using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineGameBounds : MonoBehaviour
{
    [SerializeField]
    public GameObject boundaries;

    void Start()
    {
        boundaries.transform.position = new Vector3(DefineBorders.GameZone.startWidth, 0, 0);
        boundaries.GetComponent<BoxCollider2D>().size = new Vector2(0.2f, DefineBorders.height);
    }

    private void InitBounds() {

    }
}
