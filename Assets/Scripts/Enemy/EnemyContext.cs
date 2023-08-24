using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController: MonoBehaviour
{
    SpriteGlowEffect enemySprite;
    Color redColor = new Color(0.2f, 0f, 0f);
    Color greenColor = new Color(0f, 0.2f, 0f);
    Color blueColor = new Color(0f, 0f, 0.2f);
    Color[] colors = new Color[3];
    float scale = 0;
    [SerializeField] GameObject partical;
    private void OnEnable()
    {
        enemySprite = GetComponent<SpriteGlowEffect>();
        colors[0] = redColor;
        colors[1] = greenColor;
        colors[2] = blueColor;
        enemySprite.GlowColor = colors[0];
        transform.localScale = Vector3.zero;
        StartCoroutine(startSizeincrease());
        Instantiate(partical, transform.position, Quaternion.identity);
        
    }

    IEnumerator startSizeincrease()
    {
        scale = 0;
        while (true)
        {
            scale += 0.1f;
            transform.localScale = new Vector3(1,1,1) * scale;
            yield return new WaitForSeconds(0.1f);
            if (scale >= 1.5)
                StopAllCoroutines();
            yield return new WaitForEndOfFrame();
        }
    }
}
