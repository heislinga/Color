using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JoinButton : MonoBehaviour
{
    private Text buttonText;
    private LanConnnectionInfo game;

    private void Awake()
    {
        buttonText = GetComponentInChildren<Text>();
    }

    public void Initialize(LanConnnectionInfo game, Transform panelTransform)
    {
        this.game = game;
        buttonText.text = game.name;
        transform.SetParent(panelTransform);
        transform.localScale = Vector3.one;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
    }

    public void JoinGame()
    {
        Debug.Log("Join clicked!");
        FindObjectOfType<CustomNetworkManager>().StartClient(game);
    }
}
