using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    public int healthCount;

    private float startPositionX = DefineBorders.GameZone.endHeight;
    private float startPositionY = DefineBorders.GameZone.endWidth;

    private const float offset = 0.5f;

    private void setPosition(GameObject _health)
    {
        _health.transform.position = new Vector3(startPositionX, startPositionY);
        startPositionX -= (offset * 2);
    }

    public void Init()
    {

        setStartPosition();

        for (int i = 0; i < healthCount; i++) {

            GameObject health = HealthPool.SharedInstance.GetPooledObject();
            if (health != null) {

                setPosition(health);
                health.SetActive(true);
            }
        }
    }

    private void setStartPosition()
    {
        startPositionX = DefineBorders.GameZone.endWidth - (offset);
        startPositionY = DefineBorders.GameZone.endHeight - offset;
    }
}
