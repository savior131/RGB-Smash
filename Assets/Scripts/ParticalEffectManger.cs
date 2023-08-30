using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalEffectManger : MonoBehaviour
{
    [SerializeField] GameObject[] Particals;

    public void releaseCreateEnemyPartical(Transform position , Color newColor)
    {
        GameObject partical = Instantiate(Particals[0] ,position.transform.position , Quaternion.identity);
        partical.transform.parent = position.gameObject.transform;
        partical.GetComponent<ParticleSystem>().startColor = newColor;
    }
    public void enemyTrailPartical(Transform enemy, Color newColor)
    {
        GameObject partical = Instantiate(Particals[1], enemy.transform.position, Quaternion.identity);
        partical.transform.parent=enemy.gameObject.transform;
        partical.GetComponent<ParticleSystem>().startColor = newColor;
    }

    public void enemyDestroyPartical(Transform enemy, Color newColor)
    {
        GameObject partical = Instantiate(Particals[2], enemy.transform.position, Quaternion.identity);
        partical.GetComponent<ParticleSystem>().startColor = newColor;
    }
}
