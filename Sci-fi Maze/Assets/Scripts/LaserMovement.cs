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
    [SerializeField] public GameObject LightPrefab;

    private bool IsActivated;
    private Transform Self;
    private Renderer SelfRenderer;
    private Quaternion LightningAngle;
    private GameObject FrontLight, BackLight;

    private void Start()
    {
        Self = gameObject.GetComponent<Transform>();
        SelfRenderer = gameObject.GetComponent<Renderer>();

        if (IsPeriodical)
        {
            StartCoroutine(ActivatorAndDeactivator(PeriodTime));
        }

        CreateLightning();
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

        Light FrontLightRenderer;
        Light BackLightRenderer;
        FrontLightRenderer = FrontLight.GetComponent<Light>();
        BackLightRenderer = BackLight.GetComponent<Light>();

        while (true)
        {
            yield return new WaitForSeconds(PeriodTime);
            if (!IsActivated)
            {
                SelfRenderer.enabled = !SelfRenderer.enabled;
                FrontLightRenderer.enabled = !FrontLightRenderer.enabled;
                BackLightRenderer.enabled = !BackLightRenderer.enabled;
            }
            else
            {
                SelfRenderer.enabled = SelfRenderer.enabled;
                FrontLightRenderer.enabled = FrontLightRenderer.enabled;
                BackLightRenderer.enabled = BackLightRenderer.enabled;
            }
        }
    }


    private void CreateLightning()
    {
        LightningAngle = new Quaternion(0 , Quaternion.identity.y, Quaternion.identity.z, Quaternion.identity.w);
        FrontLight = Instantiate(LightPrefab, Self.position, LightningAngle);     

        LightningAngle = new Quaternion(180, Quaternion.identity.y, Quaternion.identity.z, Quaternion.identity.w);
        BackLight = Instantiate(LightPrefab, Self.position, LightningAngle);

        StartCoroutine(UpdateLightning());
    }

    private IEnumerator UpdateLightning()
    {
        while (true)
        {
            FrontLight.transform.position = Self.position + new Vector3(0, 0.3f, 0);
            BackLight.transform.position = Self.position + new Vector3(0, 0.3f, 0);
            yield return null;
        }
    }
}
