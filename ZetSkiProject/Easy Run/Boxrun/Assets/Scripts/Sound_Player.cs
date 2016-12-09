using UnityEngine;
using System.Collections;

public class Sound_Player : MonoBehaviour {

	//?ъ슜???ъ슫?쒕? ?뗮똿???볥뒗??
	
	public AudioClip[] Sound;
	
	//0 : ?먰봽?ъ슫??	//1 : 肄붿씤?띾뱷?ъ슫??	//2 : 二쎌쓬?ъ슫??	
	public void SoundPlay(int SoundNumber){
         
         GetComponent<AudioSource>().clip = Sound[SoundNumber];
         GetComponent<AudioSource>().Play();
		
    }
	
}
