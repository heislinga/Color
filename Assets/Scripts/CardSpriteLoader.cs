using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpriteLoader : MonoBehaviour {

    public Sprite RED_0;
    public Sprite RED_1;
    public Sprite RED_2;
    public Sprite RED_3;
    public Sprite RED_4;
    public Sprite RED_5;
    public Sprite RED_6;
    public Sprite RED_7;
    public Sprite RED_8;
    public Sprite RED_9;
    public Sprite RED_PICK2;
    public Sprite RED_REVERSE;
    public Sprite RED_SKIP;

    public Sprite GREEN_0;
    public Sprite GREEN_1;
    public Sprite GREEN_2;
    public Sprite GREEN_3;
    public Sprite GREEN_4;
    public Sprite GREEN_5;
    public Sprite GREEN_6;
    public Sprite GREEN_7;
    public Sprite GREEN_8;
    public Sprite GREEN_9;
    public Sprite GREEN_PICK2;
    public Sprite GREEN_REVERSE;
    public Sprite GREEN_SKIP;

    public Sprite BLUE_0;
    public Sprite BLUE_1;
    public Sprite BLUE_2;
    public Sprite BLUE_3;
    public Sprite BLUE_4;
    public Sprite BLUE_5;
    public Sprite BLUE_6;
    public Sprite BLUE_7;
    public Sprite BLUE_8;
    public Sprite BLUE_9;
    public Sprite BLUE_PICK2;
    public Sprite BLUE_REVERSE;
    public Sprite BLUE_SKIP;

    public Sprite YELLOW_0;
    public Sprite YELLOW_1;
    public Sprite YELLOW_2;
    public Sprite YELLOW_3;
    public Sprite YELLOW_4;
    public Sprite YELLOW_5;
    public Sprite YELLOW_6;
    public Sprite YELLOW_7;
    public Sprite YELLOW_8;
    public Sprite YELLOW_9;
    public Sprite YELLOW_PICK2;
    public Sprite YELLOW_REVERSE;
    public Sprite YELLOW_SKIP;

    public Sprite WILD;
    public Sprite WILD_4;
    public Sprite WILD_RANDOM;

    public Sprite BACK;

    private SpriteRenderer spriteRenderer;


    public void SetSprite(ColorCard.Type t, ColorCard.Color c, int value)
    {
        Sprite front = BACK; // default back;

        switch (t)
        {
            case ColorCard.Type.STANDARD:
                switch (c)
                {
                    case ColorCard.Color.BLUE:
                        switch (value)
                        {
                            case 0:
                                front = BLUE_0;
                                break;
                            case 1:
                                front = BLUE_1;
                                break;
                            case 2:
                                front = BLUE_2;
                                break;
                            case 3:
                                front = BLUE_3;
                                break;
                            case 4:
                                front = BLUE_4;
                                break;
                            case 5:
                                front = BLUE_5;
                                break;
                            case 6:
                                front = BLUE_6;
                                break;
                            case 7:
                                front = BLUE_7;
                                break;
                            case 8:
                                front = BLUE_8;
                                break;
                            case 9:
                                front = BLUE_9;
                                break;
                        }
                        break;
                    case ColorCard.Color.GREEN:
                        switch (value)
                        {
                            case 0:
                                front = GREEN_0;
                                break;
                            case 1:
                                front = GREEN_1;
                                break;
                            case 2:
                                front = GREEN_2;
                                break;
                            case 3:
                                front = GREEN_3;
                                break;
                            case 4:
                                front = GREEN_4;
                                break;
                            case 5:
                                front = GREEN_5;
                                break;
                            case 6:
                                front = GREEN_6;
                                break;
                            case 7:
                                front = GREEN_7;
                                break;
                            case 8:
                                front = GREEN_8;
                                break;
                            case 9:
                                front = GREEN_9;
                                break;
                        }
                        break;
                    case ColorCard.Color.RED:
                        switch (value)
                        {
                            case 0:
                                front = RED_0;
                                break;
                            case 1:
                                front = RED_1;
                                break;
                            case 2:
                                front = RED_2;
                                break;
                            case 3:
                                front = RED_3;
                                break;
                            case 4:
                                front = RED_4;
                                break;
                            case 5:
                                front = RED_5;
                                break;
                            case 6:
                                front = RED_6;
                                break;
                            case 7:
                                front = RED_7;
                                break;
                            case 8:
                                front = RED_8;
                                break;
                            case 9:
                                front = RED_9;
                                break;
                        }
                        break;
                    case ColorCard.Color.YELLOW:
                        switch (value)
                        {
                            case 0:
                                front = YELLOW_0;
                                break;
                            case 1:
                                front = YELLOW_1;
                                break;
                            case 2:
                                front = YELLOW_2;
                                break;
                            case 3:
                                front = YELLOW_3;
                                break;
                            case 4:
                                front = YELLOW_4;
                                break;
                            case 5:
                                front = YELLOW_5;
                                break;
                            case 6:
                                front = YELLOW_6;
                                break;
                            case 7:
                                front = YELLOW_7;
                                break;
                            case 8:
                                front = YELLOW_8;
                                break;
                            case 9:
                                front = YELLOW_9;
                                break;
                        }
                        break;
                }
                break;
            case ColorCard.Type.DRAW2:
                switch (c)
                {
                    case ColorCard.Color.BLUE:
                        front = BLUE_PICK2;
                        break;
                    case ColorCard.Color.GREEN:
                        front = GREEN_PICK2;
                        break;
                    case ColorCard.Color.RED:
                        front = RED_PICK2;
                        break;
                    case ColorCard.Color.YELLOW:
                        front = YELLOW_PICK2;
                        break;
                }
                break;
            case ColorCard.Type.REVERSE:
                switch (c)
                {
                    case ColorCard.Color.BLUE:
                        front = BLUE_REVERSE;
                        break;
                    case ColorCard.Color.GREEN:
                        front = GREEN_REVERSE;
                        break;
                    case ColorCard.Color.RED:
                        front = RED_REVERSE;
                        break;
                    case ColorCard.Color.YELLOW:
                        front = YELLOW_REVERSE;
                        break;
                }
                break;
            case ColorCard.Type.SKIP:
                switch (c)
                {
                    case ColorCard.Color.BLUE:
                        front = BLUE_SKIP;
                        break;
                    case ColorCard.Color.GREEN:
                        front = GREEN_SKIP;
                        break;
                    case ColorCard.Color.RED:
                        front = RED_SKIP;
                        break;
                    case ColorCard.Color.YELLOW:
                        front = YELLOW_SKIP;
                        break;
                }
                break;
            case ColorCard.Type.WILD:
                front = WILD;
                break;
            case ColorCard.Type.WILD4:
                front = WILD_4;
                break;
            case ColorCard.Type.WILDRANDOM:
                front = WILD_RANDOM;
                break;
        }

        // SET Sprite
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = front;
        
    }

}
