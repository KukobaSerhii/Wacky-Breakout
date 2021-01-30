using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    [SerializeField]
    Sprite standardBlock0;
    [SerializeField]
    Sprite standardBlock1;
    [SerializeField]
    Sprite standardBlock2;

    // Start is called before the first frame update
   protected override void Start()
    {
        blockPoints = ConfigurationUtils.StandardBlockPoints;
        int randomNumber = Random.Range(0, 3);
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        if (randomNumber == 0)
        {
            spriteRenderer.sprite = standardBlock0;
        }
        else if (randomNumber == 1)
        {
            spriteRenderer.sprite = standardBlock1;
        }
        else
        {

            spriteRenderer.sprite = standardBlock2;

        }
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
