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
        GameObject partical1 = Instantiate(Particals[2], enemy.transform.position, Quaternion.identity);
        GameObject partical2 = Instantiate(Particals[2], enemy.transform.position, Quaternion.identity);
        partical1.GetComponent<ParticleSystem>().startColor = newColor;
        partical2.GetComponent<ParticleSystem>().startColor = newColor;
        if (newColor == Color.red)
        {
            partical1.GetComponent<ParticleSystem>().startColor = Color.blue;
            partical2.GetComponent<ParticleSystem>().startColor = Color.green;
        }
        else if (newColor == Color.green)
        {
            partical1.GetComponent<ParticleSystem>().startColor = Color.blue;
            partical2.GetComponent<ParticleSystem>().startColor = Color.red;
        }
        else if (newColor == Color.blue)
        {
            partical1.GetComponent<ParticleSystem>().startColor = Color.green;
            partical2.GetComponent<ParticleSystem>().startColor = Color.red;
        }
    }
}
