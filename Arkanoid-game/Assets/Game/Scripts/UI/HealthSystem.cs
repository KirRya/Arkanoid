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

    [SerializeField]
    private GameObject pool;

    private int hearthsIndex;

    private void setPosition(GameObject _health)
    {
        _health.transform.position = new Vector3(startPositionX, startPositionY);
        startPositionX -= (float)(offset * 1.25);
    }

    public void Init()
    {
        hearthsIndex = healthCount - 1;
        setStartPosition();

        for (int i = 0; i < healthCount; i++) {

            GameObject health = HealthPool.SharedInstance.GetPooledObject();
            if (health != null) {

                setPosition(health);
                health.SetActive(true);
            }
        }

        //decreaseHearth();
    }

    private void setStartPosition()
    {
        startPositionX = DefineBorders.GameZone.endWidth - (offset);
        startPositionY = DefineBorders.GameZone.endHeight - offset;
    }

    public void decreaseHearth() {
        GameObject tmp = pool.gameObject.transform.GetChild(hearthsIndex).gameObject;
        tmp.SetActive(false);
        hearthsIndex--;
    }
}
