using UnityEngine;
using System.Collections;

public class GlobalManager : MonoBehaviour
{

    private int HP = 244;
    private int TIME = 360;
    [SerializeField] public HpVisualisator hpVisualisator;
    [SerializeField] public TimeVisualisator timeVisualisator;

    private void Start()
    {
        hpVisualisator.CurrentHPUpdate(HP);
        StartCoroutine(Timer());
    }

    public void TakeDamage(int Amount)
    {
        if (HP > Amount)
            HP -= Amount;
        else
        {
            HP = 0;
            if (TIME >= 0) StartCoroutine(GameRestart());
        }

        hpVisualisator.CurrentHPUpdate(HP);
    }

    private IEnumerator GameRestart()
    {
        yield return null;
    }
    private IEnumerator Timer()
    {
        while (TIME > 0)
        {
            yield return new WaitForSeconds(1f);
            TIME -= 1;
            timeVisualisator.CurrentTimeUpdate(TIME);
        }

        if(HP>0) StartCoroutine(GameRestart());
    }
}
