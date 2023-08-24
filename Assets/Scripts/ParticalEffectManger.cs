using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalEffectManger : MonoBehaviour
{
    [SerializeField] GameObject creatEnemyPartical;

    public void releasCreatEnemyPartical(Transform position , Color newColor)
    {
        GameObject partical = Instantiate(creatEnemyPartical ,position.transform.position , Quaternion.identity);
        partical.GetComponent<ParticleSystem>().startColor = newColor;
    }
}
