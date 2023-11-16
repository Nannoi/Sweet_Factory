using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstCupController : MonoBehaviour
{
    public float requiredFillAmount; // Adjust this value based on your needs
    private float currentFillAmount = 0f;
    private bool isCupFilled = false;
    public string Tag;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tag)) // Assuming the tiny balls have a "Duck" tag
        {
            // Increase the fill amount
            currentFillAmount += 0.01f; // You can adjust the fill rate based on your preference

            // Check if the cup is filled
            if (currentFillAmount >= requiredFillAmount)
            {
                isCupFilled = true;
                Debug.Log("Cup is filled! Player wins!");
                // You can add additional logic or trigger a win state here
            }
        }
    }

    private void Update()
    {
        if (isCupFilled)
        {
            Debug.Log("Cup is filled");
        }
    }




}
