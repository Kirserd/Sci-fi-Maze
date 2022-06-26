using UnityEngine;
using System.Collections;

public class PlasmaBulletMovement : MonoBehaviour
{
    private Transform _self;
    [SerializeField] public Vector3 Direction;
    private void Start()
    {
        _self = gameObject.GetComponent<Transform>();
        OnSpawned();
    }

    private void FixedUpdate()
    {
        _self.position += Direction;
    }

    IEnumerator PlasmaScaling()
    {
        for (int i = 0; i < 10; i++)
        {
            _self.localScale += new Vector3(9f, 9f, 9f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void OnSpawned()
    {
        _self = gameObject.GetComponent<Transform>();
        StartCoroutine(PlasmaScaling());
    }

    public void SetDirection(Vector3 NewDirection)
    {
        Direction = NewDirection;
    }
}
