using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ClipKTArray
{
	public AudioClip[] KTClip;
}

public class OnClickKT : MonoBehaviour
{
    private RectTransform KT;
	public int KTMod = 0;
	public Text textBox;
    private Coroutine KTCor = null;
    private Coroutine textCor = null;
    public AudioClip clickSound;
    public ClipKTArray[] randClip;
    private AudioSource audioSource;
    private int rand;
    private RectTransform textRect;

    private void Awake()
	{
        //audioSource.volume = audioSource.volume == 1 ? 0 : 1;
		KT = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
        if (textBox != null)
        {
            textRect = textBox.GetComponent<RectTransform>();
        }
    }

    public void ClickKT()
    {
        rand = Random.Range(0, randClip[KTMod].KTClip.Length);
        if (KTCor != null)
        {
            StopCoroutine(KTCor);
            KT.localScale = Vector3.one;
        }
        KTCor = StartCoroutine(KTAnim());
        if (textBox != null)
        {
            if (KTMod == 0)//AI KT
            {
                switch (rand)
                {
                    case 0:
                        textBox.text = "�й��ϼ��� �޸�!";
                        break;
                    case 1:
                        textBox.text = "��.. �Ƿ��� �����ϱ��� �޸�..";
                        break;
                    case 2:
                        textBox.text = "���� �ص� ��ź��� ���Ұ� �����ϴ� �޸�";
                        break;
                    case 3:
                        textBox.text = "��.��.��.��.��.��.�� �޸դ�";
                        break;
                    case 4:
                        textBox.text = "������ô°���?        �װ� �� ���Դϴٸ�?";
                        break;
                    case 5:
                        textBox.text = "�̰͹ۿ� ���Ͻó��� �޸�?";
                        break;
                }
            }
            else if (KTMod == 1)// Orignal
            {
                switch (rand)
                {
                    case 0:
                        textBox.text = "����!";
                        break;
                    case 1:
                        textBox.text = "���̽�����! ���!���!�r!";
                        break;
                    case 2:
                        textBox.text = "��!»!";
                        break;
                    case 3:
                        textBox.text = "�餻��";
                        break;
                    case 4:
                        textBox.text = "��.��.��.��.��.��?";
                        break;
                    case 5:
                        textBox.text = "�� ���⼭ ����";
                        break;
                    case 6:
                        textBox.text = "��?? ��Ÿ��?";
                        break;
                    case 7:
                        textBox.text = "EZ~";
                        break;
                    case 8:
                        textBox.text = "������ �����";
                        break;
                }
            }
            else if (KTMod == 2)// Hawawa
            {
                switch (rand)
                {
                    case 0:
                        textBox.text = "�ϿͿ�!�����» ���´� ������̿���!";
                        break;
                    case 1:
                        textBox.text = "�ϿͿ�!�涧��!������̿���!";
                        break;
                    case 2:
                        textBox.text = "���´�!�Ϳ���! ������! �����¯�̿Ϳ�!�ϿͿ�!!";
                        break;
                }
            }
			else if (KTMod == 3)// Lulu
			{
				switch (rand)
				{
					case 0:
						textBox.text = "������� ����!";
						break;
					case 1:
						textBox.text = "Ŀ!��!�󤿤�����!!!!";
						break;
					case 2:
						textBox.text = "ũ�Ԥ�! ũ�ԤĤ�!!!!";
						break;
				}
			}
			if (textCor != null)
            {
                StopCoroutine(textCor);
                textRect.localScale = Vector3.one;
            }
            StartCoroutine(TextAnim());
        }
        audioSource.Stop();
        audioSource.PlayOneShot(clickSound);
        //audioSource.clip = randClip[KTMod].KTClip[rand];
		audioSource.PlayOneShot(randClip[KTMod].KTClip[rand]);
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

    private IEnumerator TextAnim()
	{

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.005f);
            textRect.localRotation *= Quaternion.Euler(0, 0, 5);
        }
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.005f);
            textRect.localRotation *= Quaternion.Euler(0, 0, -10);
        }
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.005f);
            textRect.localRotation *= Quaternion.Euler(0, 0, 2.5f);
        }
        textCor = null;
    }
}
