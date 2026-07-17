using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    [SerializeField]private UnityEvent OnGameOver;

    public void OnTriggerEnter(Collider other)
    {
        OnGameOver.Invoke();
        Time.timeScale = 0;
    }
}
