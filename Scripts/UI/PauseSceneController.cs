using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI {
    public class PauseSceneController : MonoBehaviour {
        public void SkillUpgrade() {
            StartCoroutine(GameController.loadSceneAsync(GameController.SkillUpgradeSceneName, LoadSceneMode.Additive));
            StartCoroutine(GameController.unloadSceneAsync(GameController.PauseSceneName));
        }

        public void Resume() {
            StartCoroutine(GameController.unloadSceneAsync(GameController.PauseSceneName));
            GameController.ResumeGame();
        }

        public void Restart() {
            // TODO, are there any actions that should be done before loading the main menu scene,
            // like saving any thing.
            StartCoroutine(GameController.loadSceneAsync(GameController.GameSceneName, LoadSceneMode.Single));
        }

        public void ToMainMenu() {
            // TODO, are there any actions that should be done before loading the main menu scene,
            // like saving any thing.
            StartCoroutine(GameController.loadSceneAsync(GameController.MainMenuSceneName, LoadSceneMode.Single));
        }

        private void Start() {
            // TODO, call it from here or what?
            GameController.PauseGame();
        }
    }
}
