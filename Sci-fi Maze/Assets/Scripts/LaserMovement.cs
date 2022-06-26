using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour
{
    [SerializeField] public float MaxPositionY;
    [SerializeField] public float MinPositionY;
    [SerializeField] public float Speed;
    [SerializeField] public bool IsPeriodical;
    [SerializeField] public float PeriodTime;
    [SerializeField] public float OffsetTime;

    private bool IsActivated;
    private Transform Self;
    private Renderer SelfRenderer;

    private void Start()
    {
        Self = gameObject.GetComponent<Transform>();
        SelfRenderer = gameObject.GetComponent<Renderer>();

        if (IsPeriodical)
        {
            StartCoroutine(ActivatorAndDeactivator(PeriodTime));
        }
    }

    private void FixedUpdate()
    {
        if (Self.localPosition.y >= MaxPositionY || Self.localPosition.y <= MinPositionY)
        {
            Speed = -Speed;
            Self.localPosition += new Vector3(0, Speed / 8, 0);
        }

        Self.localPosition += new Vector3(0, Speed, 0);
    }

    private IEnumerator ActivatorAndDeactivator(float PeriodTime)
    {
        yield return new WaitForSeconds(OffsetTime);

        while (true)
        {
            yield return new WaitForSeconds(PeriodTime);
            if (!IsActivated)
                SelfRenderer.enabled = !SelfRenderer.enabled;
            else
                SelfRenderer.enabled = SelfRenderer.enabled;
        }
    }
}
