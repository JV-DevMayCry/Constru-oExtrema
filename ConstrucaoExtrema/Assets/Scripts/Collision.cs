using UnityEngine;

public class Collision : MonoBehaviour
{
   
   [SerializeField] private AudioSource collisionAudioSource;
    private bool firstCollision;

    private void OlisionEnter(Collision collision)
    {
        collisionAudioSource.PlayOneShot(collisionAudioSource.clip);

        if (!firstCollision)
        {
            firstCollision = true;
            Invoke(nameof(DisableComponent), 5);

        }

    }

    private void DisableComponent()
    {
        enabled = false;
    }
}
