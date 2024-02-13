using UnityEngine;
using UnityEngine.UI;

public class PowerDisplay : MonoBehaviour
{
    public Text PowerText;
    [SerializeField] private PlayerMovement playerMovementScript;

    private void Update()
    {
        if (playerMovementScript != null)
        {
            PowerText.text = "Power: " + (int)(playerMovementScript.GetForwardPower() + playerMovementScript.GetUpwardPower());
        }
    }
}