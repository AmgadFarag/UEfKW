using UnityEngine;

namespace UI {
    public class SkillUpgradeAudioController : MonoBehaviour {
        private AudioSource skillUpgradeAudioSource;

        // Use this for initialization
        private void Start () {
            skillUpgradeAudioSource = GetComponent<AudioSource>();
            skillUpgradeAudioSource.volume = GameController.MusicSoundLevel;
        }

        // Update is called once per frame
        private void Update () {
            skillUpgradeAudioSource.volume = GameController.MusicSoundLevel;
        }
    }
}
