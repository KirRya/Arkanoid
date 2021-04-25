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

    void Start() {
        string levelName = "level1.json";
        Level level1 = levelReader(levelName);

        string jsonColorsQuery = colorReader();

        allColors = JsonHelper.FromJson<Colors>(jsonColorsQuery);

        levelCreator.createLevel(level1, blockView, allColors);
    }

    private Level levelReader(string levelName) {
        return JsonUtility.FromJson<Level>(File.ReadAllText(Application.streamingAssetsPath + string.Format(levelsPath, levelName)));
    }

    private string colorReader() {
        return File.ReadAllText(Application.streamingAssetsPath + string.Format(colorsPath));
    }
}
