using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSpriteLoader : MonoBehaviour {

    public Sprite ACTIVE;
    public Sprite INACTIVE;


    public void SetActive(bool active)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (active)
        {
            spriteRenderer.sprite = ACTIVE;
        }
        else
        {
            spriteRenderer.sprite = INACTIVE;
        }
    }
}
