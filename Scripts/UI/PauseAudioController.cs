using UnityEngine;

namespace UI {
	public class PauseAudioController : MonoBehaviour {
		private AudioSource pauseAudioSource;

		// Use this for initialization
		void Start () {
			pauseAudioSource = GetComponent<AudioSource>();
			pauseAudioSource.volume = GameController.MusicSoundLevel;
		}

		// Update is called once per frame
		void Update () {
			pauseAudioSource.volume = GameController.MusicSoundLevel;
		}
	}
}
