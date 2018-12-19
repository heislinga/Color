using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject cardPrefab;
    public GameObject tablePrefab;

    public GameObject cardWheel;

	// Use this for initialization
	void Start () {



        CardWheel cw = cardWheel.GetComponent<CardWheel>();



        cw.AddCard(new ColorCard(ColorCard.Type.REVERSE, ColorCard.Color.RED, 0));
        cw.AddCard(new ColorCard(ColorCard.Type.STANDARD, ColorCard.Color.RED, 0));
        cw.AddCard(new ColorCard(ColorCard.Type.SKIP, ColorCard.Color.RED, 0));

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
