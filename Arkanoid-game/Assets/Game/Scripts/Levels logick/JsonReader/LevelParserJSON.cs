using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LevelParserJSON : MonoBehaviour
{
    [SerializeField]
    private BlockView blockView;

    [SerializeField]
    private GameObject prefabObject;

    [SerializeField]
    private LevelCreator levelCreator;

    private string levelsPath = @"\Levels\{0}";
    private string colorsPath = @"\colors.json";

    private Colors[] allColors;

    [SerializeField]
    private string currentLevelName;


    [SerializeField]
    private BallMovement ball;

    void Start() {
        Level level1 = levelReader(currentLevelName);

        string jsonColorsQuery = colorReader();

        allColors = JsonHelper.FromJson<Colors>(jsonColorsQuery);

        levelCreator.createLevel(level1, blockView, allColors);

        ball.defineSpeed(level1.blocks.Length);
    }

    private Level levelReader(string levelName) {
        return JsonUtility.FromJson<Level>(File.ReadAllText(Application.streamingAssetsPath + string.Format(levelsPath, levelName)));
    }

    private string colorReader() {
        return File.ReadAllText(Application.streamingAssetsPath + string.Format(colorsPath));
    }
}
