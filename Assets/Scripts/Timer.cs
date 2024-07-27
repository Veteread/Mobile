using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject TimeOut;
    public GameObject Finish;
    public float timeToCountdown;
    private float currentTime;
    private bool win = false;
    

    void Start()
    {
        currentTime = timeToCountdown;
    }

    void Update()

    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            DisplayCountdownText();
            if (win == true)
            {
                currentTime += Time.deltaTime;
            }
        }
        else
        {
            TimeOut.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Finish")
        {
            Finish.SetActive(true);
            win = true;
        }

    }
        void DisplayCountdownText()
    {
        string formattedTime = string.Format("{0:00}:{1:00}", currentTime / 60, currentTime % 60);
        countdownText.SetText(formattedTime);
    }
}