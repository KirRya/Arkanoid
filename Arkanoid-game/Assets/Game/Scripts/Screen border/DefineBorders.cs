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

    private const float topOffsetValue = 0.2f;
    private const float bottomOffsetValue = 0.4f;

    public static float topOffset = 0;
    public static float bottomOffset = 0;

    public static bool[,] matrix;


    void Start() {

        height = mainCamera.orthographicSize * 2;
        aspectRatious = mainCamera.aspect;
        width = Mathf.Round(height * aspectRatious);
        GameZone.Init();
    }

    public static class GameZone {

        public static Rect gameField;
        public static float startHeight, endHeight, startWidth, endWidth;

        public static Rect gameFieldWithOffset;

        public static void Init() {

            CalculateParameters();
            CalculateOffsets();
            InitializeGameFields();
        }

        public static void ShowGameFieldsParameters() {
            Debug.Log($"Start width: {startWidth}, end width: {endWidth}, start height: {startHeight}, endHeight: {endHeight}, gameField: {gameField.ToString()}; topOffset: {topOffset}; bottomOffset: {bottomOffset}; gameFieldWithOffest: {gameFieldWithOffset.ToString()}");
        }

        private static void CalculateOffsets() {

            topOffset = endHeight - (endHeight * topOffsetValue);
            bottomOffset = startHeight -(startHeight * bottomOffsetValue);
        }

        private static void CalculateParameters() {

            endHeight = (height / 2);
            startHeight = -endHeight;

            endWidth = (width / 2);
            startWidth = -endWidth;
        }

        private static void InitializeGameFields() {

            gameField = new Rect(startWidth, startHeight, endWidth, endHeight);
            gameFieldWithOffset = new Rect(startWidth, bottomOffset, endWidth, topOffset);
        }  
    }

}
