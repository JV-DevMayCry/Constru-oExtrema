using UnityEngine;

public class PiecesCollision : MonoBehaviour
{
    [SerializeField] private AudioSource collisionAudioSource;
    private bool firstCollision;

    private void OnCollisionEnter(Collision collision)
    {
        collisionAudioSource.PlayOneShot(collisionAudioSource.clip);

        if (!firstCollision)
        {
            firstCollision = true;
            Invoke(nameof(DisableComponent), 1);

        }

    }

    private void DisableComponent()
    {
        enabled = false;
    }
}
