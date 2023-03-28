using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingKT : MonoBehaviour
{
    public float speed;
    public RectTransform[] target = new RectTransform[2];

    private int count;

    private bool pressed;

    private RectTransform rect;
    private Rigidbody2D rigid;
    private float rotateSpeed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        rect = GetComponent<RectTransform>();
        rotateSpeed = Random.Range(90, 1440);
        StartCoroutine(Move());
    }

    public void Onclick()
	{
        rigid.gravityScale = 160;
        rigid.velocity += Vector2.up * 500;
        pressed = true;
	}

    private IEnumerator Move()
    {
        while (true)
        {
            yield return null;
            
            if (pressed)
			{
                if (rect.position.y <= -860)
			    {
                    rect.position = target[0].position;
                    rigid.gravityScale = 0;
                    rigid.velocity = Vector2.zero;
					rotateSpeed = Random.Range(90, 1440);
					pressed = false;
			    }
                continue;
			}
            

            rect.position = Vector2.MoveTowards(rect.position, target[count].position, speed * Time.deltaTime);

            rect.rotation *= Quaternion.Euler(0, 0, rotateSpeed * 0.02f);

            if (Vector2.Distance(rect.position, target[count].position) < 0.01f)
			{
                rotateSpeed = Random.Range(90, 1440);
                rect.localScale = new Vector3(-rect.localScale.x, rect.localScale.y, rect.localScale.z);
                count = count == 1 ? 0 : 1;
            }
        }
    }
}
