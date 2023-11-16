using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float totalTime; // Total time in seconds
    private float currentTime;    // Current time left
    private bool isTimerRunning = false;
    public GameObject emitter;
    public GameObject youlose;

    public Text timerText; // Reference to a UI Text component to display the timer

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;

            // Check if the timer has reached zero
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isTimerRunning = false;
                HandleTimeUp(); // Call the method when the timer expires
            }

            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        // Convert the time to minutes and seconds
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        // Update the UI Text component
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void HandleTimeUp()
    {
        // Perform actions when the timer reaches zero
        youlose.SetActive(true);
        emitter.SetActive(false);
        Debug.Log("Time's up! Performing some action...");

        // Add your custom code here.
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        emitter.SetActive(true);
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = totalTime;
        UpdateTimerDisplay();
    }
}
