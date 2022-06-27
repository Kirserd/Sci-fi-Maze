using System.Collections;
using UnityEngine;

public class ParticleActualLifeTime : MonoBehaviour
{
    public void StartCleaning()
    {
        StartCoroutine(Cleaner());
    }
    private IEnumerator Cleaner()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }

}
