using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public void createLevel(Level currentLevel, BlockView blockViewPrefab, Colors[] allColors) {
        for (int i = 0; i < currentLevel.blocks.Length; i++) {

            BlockView block = ObjectPool.SharedInstance.GetPooledObject();
            if (block != null)  {

                block.setPosition(currentLevel.blocks[i]);
                block.spriteRenderer.color = blockViewPrefab.setColor(currentLevel.blocks[i], allColors);

                block.prefab.SetActive(true);
            }
        }
    }
}
