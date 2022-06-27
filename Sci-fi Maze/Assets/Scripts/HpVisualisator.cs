using TMPro;
using UnityEngine;

public class HpVisualisator : MonoBehaviour
{
    private int CurrentHp = 244;
    private void Update()
    {
        GetComponent<TMP_Text>().text = CurrentHp.ToString();
    }

    public void CurrentHPUpdate(int UpdatedHp)
    {
        CurrentHp = UpdatedHp;
    }
}
