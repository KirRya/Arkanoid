using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    private float scaleValue;
    private const int normalBlockColumnsAmount = 5;

    private float startColumn;
    public void createLevel(Level currentLevel, BlockView blockViewPrefab, Colors[] allColors) {

        DefineBorders.matrix = new bool[currentLevel.rowsCounts, currentLevel.columnsCounts];

        scaleValue = ((float)normalBlockColumnsAmount / (float)DefineBorders.matrix.GetLength(1));

        startColumn = DefineBorders.GameZone.startWidth + 1;

        for (int i = 0; i < currentLevel.blocks.Length; i++) {

            BlockView block = ObjectPool.SharedInstance.GetPooledObject();
            if (block != null)  {

                block.setPosition(currentLevel.blocks[i], startColumn);
                block.spriteRenderer.color = blockViewPrefab.setColor(currentLevel.blocks[i], allColors);
                block.blockScale(scaleValue);

                block.prefab.SetActive(true);

                startColumn += scaleValue;
            }
        }
    }
}
