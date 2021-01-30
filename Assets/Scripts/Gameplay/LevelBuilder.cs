using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject paddle;
    [SerializeField]
    GameObject standardBlock;
    [SerializeField]
    GameObject bonusBlock;
    [SerializeField]
    GameObject pickupBlock;
    int amountOfBlocksInGame = 0;

    float standardBlockWidth;
    float standardBlockHeight;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(paddle);
        FindStandardBlockDimensions();
        BuildThreeRowsOfBlocks();
        EventManager.AddPointsAddedListener(HandlePointsAdded);
    }
    void FindStandardBlockDimensions()
    {
        GameObject tempStandardBlock = Instantiate(standardBlock);
        BoxCollider2D standardBlockBoxCollider = tempStandardBlock.GetComponent<BoxCollider2D>();
        standardBlockWidth = standardBlockBoxCollider.size.x;
        standardBlockHeight = standardBlockBoxCollider.size.y;
        Destroy(tempStandardBlock);
    }
    void BuildThreeRowsOfBlocks()
    {


        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;
        int amountOfBlocksInOneRow = (int)(screenWidth / standardBlockWidth);
        int amountOfRows = 3;
        for (int i = 1; i <= amountOfRows; i++)
        {
            float Y_RowPosition = ScreenUtils.ScreenTop - (screenHeight / 6) - standardBlockHeight * i;
            for (int j = 0; j < amountOfBlocksInOneRow; j++)
            {
                float X_PositionInRow = ScreenUtils.ScreenLeft + ((screenWidth - standardBlockWidth * amountOfBlocksInOneRow) / 2) + (standardBlockWidth / 2) + standardBlockWidth * j;

                Vector2 position = new Vector2(X_PositionInRow, Y_RowPosition);
                BuildRandomBlock(position);
                amountOfBlocksInGame++;
            }

        }


    }
    void HandlePointsAdded(int unused)
    {
        amountOfBlocksInGame--;
        if (amountOfBlocksInGame==0)
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in balls)
            {
                Destroy(ball);

            }
            Instantiate(Resources.Load("GameOver"));
            Destroy(GameObject.FindGameObjectWithTag("Paddle"));
        }
    }
    void BuildRandomBlock(Vector2 position)
    {
        float randomBlocktype = Random.value;
        if (randomBlocktype <= ConfigurationUtils.StandardBlockProbabilities)
        {
            Instantiate(standardBlock, position, Quaternion.identity);


        }
        else if (randomBlocktype > ConfigurationUtils.StandardBlockProbabilities && randomBlocktype <= ConfigurationUtils.StandardBlockProbabilities + ConfigurationUtils.BonusBlockProbabilities)
        {
            Instantiate(bonusBlock, position, Quaternion.identity);
        }
        else if (randomBlocktype > ConfigurationUtils.StandardBlockProbabilities + ConfigurationUtils.BonusBlockProbabilities && randomBlocktype <= ConfigurationUtils.StandardBlockProbabilities + ConfigurationUtils.BonusBlockProbabilities + ConfigurationUtils.FreezerBlockProbabilities)
        {
            GameObject freezerBlock = Instantiate(pickupBlock, position, Quaternion.identity);
            PickupBlock script = freezerBlock.GetComponent<PickupBlock>();
            script.PickupEffect = PickupEffect.Freezer;

        }
        else
        {
            GameObject speedupBlock = Instantiate(pickupBlock, position, Quaternion.identity);
            PickupBlock script = speedupBlock.GetComponent<PickupBlock>();
            script.PickupEffect = PickupEffect.Speedup;
        }

    }


    
}
