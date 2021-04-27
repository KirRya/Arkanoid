using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    public SpriteRenderer spriteRenderer;

    public static float startRow;
    public static float startColumn;

    private const float rowIncreaseValue = 0.3f;
    public static float columnIncreaseValue;

    void Start() {
        spriteRenderer = prefab.GetComponent<SpriteRenderer>();
    }

    public Color setColor(Block block, Colors[] allColors) {
        float redColor   = 0;
        float greenColor = 0;
        float blueColor  = 0;

        for (int i = 0; i < allColors.Length; i++) {
            if (block.colorName == allColors[i].colorName) {

                string[] rgb = allColors[i].colorValue.Split(' ');

                redColor   = float.Parse(rgb[0]);
                greenColor = float.Parse(rgb[1]);
                blueColor  = float.Parse(rgb[2]);
            }
        }

        return new Color(redColor, greenColor, blueColor);
    }

    public void setPosition(Block block) {

        float columnValue = block.columnIndex * columnIncreaseValue;
        float rowValue = block.rowIndex * rowIncreaseValue;

        float columnPosition = startColumn + columnValue;
        float rowPosition = startRow - rowValue;

        this.transform.position = new Vector2(columnPosition, rowPosition);
    }

    public void blockScale(float scale) {
        this.transform.localScale *= scale;
    }

    public void InitBlocks(float _scaleValue) {
        startColumn = DefineBorders.GameZone.startWidth + 1;
        startRow = DefineBorders.topOffset - 1;
        columnIncreaseValue = _scaleValue;
    }
}
