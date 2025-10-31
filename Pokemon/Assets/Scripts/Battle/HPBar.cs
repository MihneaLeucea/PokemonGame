using System.Collections;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;

    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3 (hpNormalized,1f);
    }

    public IEnumerator SetHPSmooth(float newHp)
    {
        float curHp = health.transform.localScale.x;
        

        while(curHp - newHp > Mathf.Epsilon)
        {
            curHp -= 2 * Time.deltaTime;
            health.transform.localScale = new Vector3 (curHp, 1f);
            yield return null;
        }
        health.transform.localScale = new Vector3 (newHp, 1f);
    }
}
