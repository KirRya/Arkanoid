using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    private float scaleValue;
    private const int normalBlockColumnsAmount = 5;

    [SerializeField]
    private HealthSystem healthSystem;

    public void createLevel(Level currentLevel, BlockView blockViewPrefab, Colors[] allColors) {

        DefineBorders.matrix = new bool[currentLevel.rowsCounts, currentLevel.columnsCounts];

        scaleValue = ((float)normalBlockColumnsAmount / (float)DefineBorders.matrix.GetLength(1));

        InitializeHelperValues();

        for (int i = 0; i < currentLevel.blocks.Length; i++) {

            BlockView block = ObjectPool.SharedInstance.GetPooledObject();
            if (block != null)  {

                block.setPosition(currentLevel.blocks[i]);
                block.spriteRenderer.color = blockViewPrefab.setColor(currentLevel.blocks[i], allColors);
                block.blockScale(scaleValue);

                block.prefab.SetActive(true);
            }
        }


        healthSystem.Init();
    }


    private void InitializeHelperValues() {
        BlockView.startColumn = DefineBorders.GameZone.startWidth + 1;
        BlockView.startRow = DefineBorders.topOffset;
        BlockView.columnIncreaseValue = scaleValue;
    }
}
