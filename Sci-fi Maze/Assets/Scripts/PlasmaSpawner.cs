using System.Collections;
using UnityEngine;

public class PlasmaSpawner : MonoBehaviour
{
    [SerializeField] public GameObject Plasma;
    [SerializeField] public Vector3 Offset;
    [SerializeField] public Vector3 Direction;
    [SerializeField] public float Period;
    [SerializeField] public PlasmaBulletMovement plasmaBulletMovement;
    private Vector3 Position;
    private void Start()
    {
        StartCoroutine(PlasmaSpawn());
        Position = gameObject.GetComponent<Transform>().position + Offset;
    }

    IEnumerator PlasmaSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Period);
            Instantiate(Plasma, Position, Quaternion.identity);
            plasmaBulletMovement.SetDirection(Direction);
            plasmaBulletMovement.OnSpawned();
        }
    }
}
