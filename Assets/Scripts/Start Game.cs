using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonAfterDelay : MonoBehaviour
{
    // Reference to the Button GameObject
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        // Start the coroutine to show the button after a delay
        StartCoroutine(ShowButtonAfterTime(30.0f)); // 30 seconds delay
    }

    // Coroutine to handle the delay
    IEnumerator ShowButtonAfterTime(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Activate the button GameObject
        button.SetActive(true);
    }
}
