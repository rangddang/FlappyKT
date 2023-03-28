using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koin : MonoBehaviour
{
	private AudioSource audioSource;
	private CircleCollider2D collider2d;
	private SpriteRenderer sprite;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		collider2d = GetComponent<CircleCollider2D>();
		sprite = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (GameManager.gameOver) return;
		if (collision.gameObject.CompareTag("Player"))
		{
			GameManager.koin++;
			audioSource.Play();
			collider2d.enabled = false;
			sprite.enabled = false;
		}
	}
}
