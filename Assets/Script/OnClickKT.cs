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
                        textBox.text = "분발하세요 휴먼!";
                        break;
                    case 1:
                        textBox.text = "흠.. 실력이 부족하군요 휴먼..";
                        break;
                    case 2:
                        textBox.text = "제가 해도 당신보단 잘할것 같습니다 휴먼";
                        break;
                    case 3:
                        textBox.text = "정.말.로.아.쉽.네.요 휴먼ㅋ";
                        break;
                    case 4:
                        textBox.text = "어딜보시는거죠?        그건 제 턱입니다만?";
                        break;
                    case 5:
                        textBox.text = "이것밖에 못하시나요 휴먼?";
                        break;
                }
            }
            else if (KTMod == 1)// Orignal
            {
                switch (rand)
                {
                    case 0:
                        textBox.text = "데헷!";
                        break;
                    case 1:
                        textBox.text = "오이시쿠나래! 모애!모애!큥!";
                        break;
                    case 2:
                        textBox.text = "밍!쨩!";
                        break;
                    case 3:
                        textBox.text = "븅ㅋ신";
                        break;
                    case 4:
                        textBox.text = "살.고.싶.지.않.아?";
                        break;
                    case 5:
                        textBox.text = "자 여기서 문제";
                        break;
                    case 6:
                        textBox.text = "에?? 와타시?";
                        break;
                    case 7:
                        textBox.text = "EZ~";
                        break;
                    case 8:
                        textBox.text = "콩지야 ㅈ댓어";
                        break;
                }
            }
            else if (KTMod == 2)// Hawawa
            {
                switch (rand)
                {
                    case 0:
                        textBox.text = "하와와!여고생쨩 경태는 놀라운것이와유!";
                        break;
                    case 1:
                        textBox.text = "하와와!경때눈!놀라운것이와유!";
                        break;
                    case 2:
                        textBox.text = "경태눈!귀엽구! 깜찍한! 여고생짱이와요!하와와!!";
                        break;
                }
            }
			else if (KTMod == 3)// Lulu
			{
				switch (rand)
				{
					case 0:
						textBox.text = "보라색맛 나써!";
						break;
					case 1:
						textBox.text = "커!져!라ㅏㅏㅏㅏ!!!!";
						break;
					case 2:
						textBox.text = "크게ㅔ! 크게ㅔㅔ!!!!";
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
