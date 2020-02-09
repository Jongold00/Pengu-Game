using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private int hungerCount = 0;

    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (!Timer.isGameOver)
        {
            hungerCount++;

            if (timer.hunger + hungerCount < 100)
            {
                timer.hunger = timer.hunger + hungerCount;
            }
        }
    }
}