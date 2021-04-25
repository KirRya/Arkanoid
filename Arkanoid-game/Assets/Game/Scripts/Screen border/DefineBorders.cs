using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineBorders : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private static float height;
    private static float width;
    private static float aspectRatious;
    private static float widthOffset = 4f;

    void Start()
    {
        height = mainCamera.orthographicSize * 2;
        aspectRatious = mainCamera.aspect;
        width = Mathf.Round(height * aspectRatious);
        GameZone.Init();
    }

    public static class GameZone
    {
        public static Rect gameField;
        public static float startHeight, endHeight, startWidth, endWidth;

        public static void Init()
        {
            endHeight = (height / 2);
            startHeight = -endHeight;

            endWidth = Mathf.Floor(width / widthOffset);
            startWidth = -endWidth;

            gameField = new Rect(startWidth, startHeight, endWidth, endHeight); 
        }
    }
}
