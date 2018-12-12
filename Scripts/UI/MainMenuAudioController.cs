using UnityEngine;

namespace UI {
    public class MainMenuAudioController : MonoBehaviour {
        private AudioSource mainMenuAudioSource;

        // Use this for initialization
        void Start() {
            mainMenuAudioSource = GetComponent<AudioSource>();
            mainMenuAudioSource.volume = GameController.MusicSoundLevel;
        }

        // Update is called once per frame
        void Update() {
            mainMenuAudioSource.volume = GameController.MusicSoundLevel;
        }
    }
}
