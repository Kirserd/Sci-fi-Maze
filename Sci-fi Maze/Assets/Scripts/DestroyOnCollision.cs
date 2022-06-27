using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{

    [SerializeField] ParticleSystem Explosion;
    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem ParticleExplosion = Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        ParticleActualLifeTime particleActualLifeTime = ParticleExplosion.GetComponent<ParticleActualLifeTime>();
        particleActualLifeTime.StartCleaning();

        Destroy(this.gameObject);
    }
}
