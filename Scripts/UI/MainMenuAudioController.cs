using UnityEngine;

namespace UI {
    public class MainMenuAudioController : MonoBehaviour {
        private AudioSource mainMenuAudioSource;

        // Use this for initialization
        private void Start() {
            mainMenuAudioSource = GetComponent<AudioSource>();
            mainMenuAudioSource.volume = GameController.MusicSoundLevel;
        }

        // Update is called once per frame
        private void Update() {
            mainMenuAudioSource.volume = GameController.MusicSoundLevel;
        }
    }
}
