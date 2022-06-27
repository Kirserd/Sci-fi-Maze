using System.Collections;
using UnityEngine;

public class LaserLightMovement : MonoBehaviour
{
    private float MaxPositionY;
    private float MinPositionY;
    private float Speed;
    private bool IsPeriodical;
    private float PeriodTime;
    private float OffsetTime;
    private bool IsActivated;
    private Transform Self;
    private Light SelfLight;

    private void Start()
    {
        Self = gameObject.GetComponent<Transform>();
        SelfLight = gameObject.GetComponent<Light>();

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
                SelfLight.enabled = !SelfLight.enabled;
            else
                SelfLight.enabled = SelfLight.enabled;
        }
    }

    public void SetInfo(float maxPositionY, float minPositionY, float speed, bool isPeriodical, float periodTime, float offsetTime, bool isActivated)
    {
        MaxPositionY = maxPositionY;
        MinPositionY = minPositionY;
        Speed = speed;
        IsPeriodical = isPeriodical;
        PeriodTime = periodTime;
        OffsetTime = offsetTime;
        IsActivated = isActivated;
    }
}