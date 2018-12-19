using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardWheel : MonoBehaviour {

	public static readonly float CARD_WHEEL_RADIUS = 5.0f;
	public static readonly int CARD_ANGLE_INCREMENT = 10;
	public static readonly float CARD_HIGHLIGHT_HEIGHT = 1f;
	public static readonly int HIGHLIGHT_ANGLE_BORDER = 8;

	public static readonly float ANIMATION_SPEED = 0.5f;
	public static readonly float THROW_SWIPE_SENSITIVITY = 50f;
	public static readonly float THROW_SWIPE_BORDER = 200f;

	private float currentRotationAngle = 0;
	private Vector3 originalWheelPosition;

	private int currentHighlightIndex = 0; // Current card index to highlight
	private Vector2 firstPressPos, secondPressPos, currentSwipe; // for swipe detection

	public GameObject cardPrefab; // The card prefab

	public GameObject colorPicker;

	private bool waitingForColor = false;
	private bool waitingForDraw = false;
	private int currentWaitIndex = -1;

	private float cardDepth;

	private List<GameObject> addedCards; // All cards from the player object as gameObjects in wheel



	// UI
	public GameObject drawButton, colorHint;

	// Use this for initialization
	void Start () {
		addedCards = new List<GameObject> ();
		cardDepth = 0.005f;
		originalWheelPosition = gameObject.transform.position;

		RotateWheel ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			Touch t = Input.GetTouch (0);
			// SWIPE FOR SCROLLING WHEEL 
			if (t.phase == TouchPhase.Moved) {
				gameObject.transform.Rotate (0f, 0f, -t.deltaPosition.x / 10);

				if (gameObject.transform.rotation.z < 0f) {
					gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
				}

				if (gameObject.transform.rotation.eulerAngles.z > (addedCards.Count - 1)*CARD_ANGLE_INCREMENT) {
					gameObject.transform.rotation = Quaternion.Euler (0, 0, (addedCards.Count - 1)*CARD_ANGLE_INCREMENT);
				}
					
				currentRotationAngle = gameObject.transform.rotation.eulerAngles.z;
				MoveCardWheelZ ();
			}

			if (true) {

				// DETECT SWIPE FOR THROW ANIMATION
				if (t.phase == TouchPhase.Began) {
					firstPressPos = new Vector2 (t.position.x, t.position.y);				
				}

				if (t.phase == TouchPhase.Ended) {
					secondPressPos = new Vector2 (t.position.x, t.position.y);
					currentSwipe = new Vector2 (secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				
					if (currentSwipe.y > THROW_SWIPE_BORDER  &&
						currentSwipe.x > -THROW_SWIPE_SENSITIVITY  &&
						currentSwipe.x < THROW_SWIPE_SENSITIVITY) {		
						if (currentHighlightIndex >= 0) {
						
						}
					}
				}
			}
				
		}


		// Check card to highlight
		HighlightActiveCard();

	}
		
	
	/// <summary>
	/// Realingns the cards on the wheel after a card has been removed/played or added.
	/// </summary>
	private void RealingnCards() {
		gameObject.transform.rotation = Quaternion.Euler (0, 0, 0); // Reset rotation to make positioning easier
		for(int i = 0; i < addedCards.Count; i++) {
			addedCards [i].transform.position = GetCardPosition (i);
			addedCards [i].transform.rotation = Quaternion.Euler (0, 0, -i * CARD_ANGLE_INCREMENT);
		}

		if (currentRotationAngle > (addedCards.Count - 1)*CARD_ANGLE_INCREMENT) {
			currentRotationAngle = (addedCards.Count - 1) * CARD_ANGLE_INCREMENT;
		}

		gameObject.transform.rotation = Quaternion.Euler (0, 0, currentRotationAngle); // Set rotation to original value
	}
		
	/// <summary>
	/// Adjusts the cardwheel gameobject according to its current rotation angle.
	/// Detail: Because the cards are all added with some Z offset (cardDepth) you have to move the
	/// cards depth to make them appear with the same size when you rotate the wheel.
	/// </summary>
	private void MoveCardWheelZ() {
		float moveFactor = currentRotationAngle / CARD_ANGLE_INCREMENT;

		gameObject.transform.position = originalWheelPosition;
		gameObject.transform.Translate (0, 0, moveFactor * cardDepth);
	}

	/// <summary>
	/// Highlights a card if it is within the specified HIGHLIGHT_ANGLE_BOARDER.
	/// </summary>
	private void HighlightActiveCard() {
		if (currentHighlightIndex >= 0 && currentHighlightIndex < addedCards.Count)
			DeHighlightCard (currentHighlightIndex);

		currentHighlightIndex = (int)((currentRotationAngle + HIGHLIGHT_ANGLE_BORDER) / CARD_ANGLE_INCREMENT); // get index to highlight (based on rotation angle)

		if (currentRotationAngle >= currentHighlightIndex * CARD_ANGLE_INCREMENT - HIGHLIGHT_ANGLE_BORDER &&
		    currentRotationAngle <= currentHighlightIndex * CARD_ANGLE_INCREMENT + HIGHLIGHT_ANGLE_BORDER) {
			HighlightCard (currentHighlightIndex); // highlight the card if within bounds
		} else {
			currentHighlightIndex = -1; // reset index so we know no card is active
		}
	}

	/// <summary>
	/// Rotates the card wheel so that it is centered.
	/// </summary>
	private void RotateWheel() {
		if (addedCards.Count > 1) {
			transform.rotation = Quaternion.Euler (0, 0, (addedCards.Count - 1)*CARD_ANGLE_INCREMENT/2);
			currentRotationAngle = gameObject.transform.rotation.eulerAngles.z;
			MoveCardWheelZ ();
		}
	}

	/// <summary>
	/// Adds the given card to the card wheel.
	/// </summary>
	/// <param name="card">Card.</param>
	public void AddCard(ColorCard card) {
		GameObject newCard = Instantiate (cardPrefab, GetCardPosition (addedCards.Count), Quaternion.Euler (0, 0, -addedCards.Count*CARD_ANGLE_INCREMENT));
		newCard.transform.parent = gameObject.transform;
		CardSpriteLoader ctl = newCard.GetComponent<CardSpriteLoader> ();
		ctl.SetSprite(card.GetType(), card.GetColor(), card.GetValue());

		addedCards.Add (newCard);

        RealingnCards();
	}

	/// <summary>
	/// Returns the card position for the given index in the wheel.
	/// </summary>
	/// <returns>The card position.</returns>
	/// <param name="idx">Index in the wheel.</param>
	public Vector3 GetCardPosition(int idx) {
		float x = Mathf.Sin (Mathf.Deg2Rad * idx * CARD_ANGLE_INCREMENT) * CARD_WHEEL_RADIUS + gameObject.transform.position.x;
		float y = Mathf.Cos (Mathf.Deg2Rad * idx * CARD_ANGLE_INCREMENT) * CARD_WHEEL_RADIUS + gameObject.transform.position.y; 
		float z = gameObject.transform.position.z - cardDepth * idx;

		return new Vector3 (x, y, z);
	}

	/// <summary>
	/// Highlights the card on the specified index.
	/// </summary>
	/// <param name="_cardIndex">Card index to highlight.</param>
	public void HighlightCard(int _cardIndex) {
		Vector2 newCardPos = GetHighlightedCardPosition(CARD_ANGLE_INCREMENT*_cardIndex); // Calculate new position for card
		Vector3 newCardPos3 = new Vector3(newCardPos.x, newCardPos.y, addedCards[_cardIndex].transform.position.z); // Convert to Vector3

		gameObject.transform.rotation = Quaternion.Euler (0, 0, 0); // Reset rotation to make positioning easier
		addedCards [_cardIndex].transform.position = newCardPos3; // Set new position of card
		gameObject.transform.rotation = Quaternion.Euler (0, 0, currentRotationAngle); // Set rotation to original value
	}
		
	/// <summary>
	/// Calculates the x,y position for the highlighted state for a given angle.
	/// </summary>
	/// <returns>The highlighted card position.</returns>
	/// <param name="_cardAngle">Card angle.</param>
	public Vector2 GetHighlightedCardPosition(int _cardAngle) {
		float x = Mathf.Sin (Mathf.Deg2Rad * _cardAngle) * (CARD_WHEEL_RADIUS + CARD_HIGHLIGHT_HEIGHT) + gameObject.transform.position.x;
		float y = Mathf.Cos (Mathf.Deg2Rad * _cardAngle) * (CARD_WHEEL_RADIUS + CARD_HIGHLIGHT_HEIGHT) + gameObject.transform.position.y; 

		return new Vector2 (x, y);
	}	

	/// <summary>
	/// Calculates the x,y position for the normal state for a given angle.
	/// </summary>
	/// <returns>The normal card position.</returns>
	/// <param name="_cardAngle">Card angle.</param>
	public Vector2 GetNormalCardPosition(int _cardAngle) {
		float x = Mathf.Sin (Mathf.Deg2Rad * _cardAngle) * CARD_WHEEL_RADIUS + gameObject.transform.position.x;
		float y = Mathf.Cos (Mathf.Deg2Rad * _cardAngle) * CARD_WHEEL_RADIUS + gameObject.transform.position.y; 

		return new Vector2 (x, y);
	}

	/// <summary>
	/// Dehighlights the card at the given index (sets it back to normal state).
	/// </summary>
	/// <param name="_cardIndex">Card index.</param>
	public void DeHighlightCard(int _cardIndex) {
		Vector2 newCardPos = GetNormalCardPosition(CARD_ANGLE_INCREMENT*_cardIndex); // Calculate new position for card
		Vector3 newCardPos3 = new Vector3(newCardPos.x, newCardPos.y, addedCards[_cardIndex].transform.position.z); // Convert to Vector3

		gameObject.transform.rotation = Quaternion.Euler (0, 0, 0); // Reset rotation to make positioning easier
		addedCards [_cardIndex].transform.position = newCardPos3; // Set new position of card
		gameObject.transform.rotation = Quaternion.Euler (0, 0, currentRotationAngle); // Set rotation to original value
	}
}
