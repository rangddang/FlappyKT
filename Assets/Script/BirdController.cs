using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class ClipArray
{
	public AudioClip[] jumpClip;
}

public class BirdController : MonoBehaviour
{
	public ClipArray[] jumpClipArray;
    public GameObject tongue;
	private Rigidbody2D rigid;
    public float jumpPower = 3f;
    private AudioSource audioSource;
    public AudioClip mingClip;
    private Button AI_KT;
    public SpriteRenderer spriteRenderer;
    public Sprite[] skins;




	void Start()
    {
        AI_KT = GameObject.Find("AI_KT").GetComponent<Button>();
        rigid = GetComponent<Rigidbody2D>();
        audioSource = rigid.GetComponent<AudioSource>();
        spriteRenderer.sprite = skins[GameManager.skin];
        if(GameManager.skin == 6)
        {
            tongue.SetActive(true);
        }
        else
        {
            tongue.SetActive(false);
        }
    }

    void Update()
    {
        if (GameManager.gameOver) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.clip = jumpClipArray[GameManager.skin].jumpClip[Random.Range(0, jumpClipArray[GameManager.skin].jumpClip.Length)];
			audioSource.Play();
            rigid.velocity = Vector2.up * jumpPower;
            rigid.angularVelocity = Random.Range(20, 1000);
            if (GameManager.skin == 6)
            {
				tongue.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(200, 1000);
			}
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameManager.gameOver) return ;

        if(collision.gameObject.CompareTag("Wall"))
        {
            //audio.PlayOneShot(deadClip);
            GameManager.gameOver = true;
            StartCoroutine(clickKT());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.gameOver) return;
        if (collision.gameObject.CompareTag("AddScore"))
        {
            //audio.PlayOneShot(mingClip);
            GameManager.score++;
            collision.gameObject.SetActive(false);
        }
    }

    private IEnumerator clickKT()
	{
        yield return new WaitForSeconds(0.01f);
        AI_KT.onClick.Invoke();
    }
}
