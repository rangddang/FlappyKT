using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSadKT : MonoBehaviour
{
	private RectTransform KT;
	private Coroutine KTCor = null;
	private AudioSource audioSource;
	public AudioClip clickSound;

	private void Awake()
	{
		KT = GetComponent<RectTransform>();
		audioSource = GetComponent<AudioSource>();
	}

	public void OnClickKT()
	{
		if (KTCor != null)
		{
			StopCoroutine(KTCor);
			KT.localScale = Vector3.one;
		}
		KTCor = StartCoroutine(KTAnim());
		audioSource.Stop();
		audioSource.PlayOneShot(clickSound);
	}

	private IEnumerator KTAnim()
	{
		for (int i = 0; i < 4; i++)
		{
			yield return new WaitForSeconds(0.005f);
			KT.localScale -= new Vector3(0.1f, 0.1f, 0);
		}
		for (int i = 0; i < 10; i++)
		{
			yield return new WaitForSeconds(0.005f);
			KT.localScale += new Vector3(0.04f, 0.04f, 0);
		}

		KTCor = null;
	}
}
