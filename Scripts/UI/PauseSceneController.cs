using UnityEngine;

namespace UI {
    public class PauseSceneController : MonoBehaviour {
        public void SkillUpgrade() {
            StartCoroutine(GameController.unloadSceneAsync(GameController.SkillUpgradeSceneName));
        }

        public void Resume() {
            StartCoroutine(GameController.unloadSceneAsync(GameController.PauseSceneName));
            GameController.ResumeGame();
        }

        public void Restart() {
            // TODO, are there any actions that should be done before loading the main menu scene,
            // like saving any thing.
            StartCoroutine(GameController.loadSceneAsync(GameController.GameSceneName));
        }

        public void ToMainMenu() {
            // TODO, are there any actions that should be done before loading the main menu scene,
            // like saving any thing.
            StartCoroutine(GameController.loadSceneAsync(GameController.MainMenuSceneName));
        }

        private void Start() {
            //GameController.PauseGame();
        }
    }
}
