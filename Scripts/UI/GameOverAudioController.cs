using UnityEngine;

namespace UI {
	public class GameOverAudioController : MonoBehaviour {
		private AudioSource gameOverAudioSource;

		// Use this for initialization
		void Start () {
			gameOverAudioSource = GetComponent<AudioSource>();
			gameOverAudioSource.volume = GameController.MusicSoundLevel;
		}

		// Update is called once per frame
		void Update () {
			gameOverAudioSource.volume = GameController.MusicSoundLevel;
		}
	}
}
