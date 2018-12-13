using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI {
    public class SkillUpgradeSceneController : MonoBehaviour {
        private GameObject skillPointsScore;
        private GameObject movementScore;
        private GameObject attackScore;
        private GameObject healthScore;

        private GameObject upgradeMovementButton;
        private GameObject upgradeAttackButton;
        private GameObject upgradeHealthButton;

        public void CloseUpgradeWindow() {
            StartCoroutine(GameController.unloadSceneAsync(GameController.SkillUpgradeSceneName));
            StartCoroutine(GameController.loadSceneAsync(GameController.PauseSceneName, LoadSceneMode.Additive));
        }

        public void UpgradeMovement() {
            GameController.UpgradeMovementSpeed();
        }

        public void UpgradeAttack() {
            GameController.UpgradeAttacks();
        }

        public void UpgradeHealth() {
            GameController.UpgradeHealthPoints();
        }

        // Use this for initialization
        private void Start() {
            skillPointsScore = GameObject.FindWithTag("UpgradeSkillPointsScore");
            movementScore = GameObject.FindWithTag("UpgradeMovementSkillScore");
            attackScore = GameObject.FindWithTag("UpgradeAttackSkillScore");
            healthScore = GameObject.FindWithTag("UpgradeHealthSkillScore");

            upgradeMovementButton = GameObject.FindWithTag("UpgradeMovementButton");
            upgradeAttackButton = GameObject.FindWithTag("UpgradeAttackButton");
            upgradeHealthButton = GameObject.FindWithTag("UpgradeHealthButton");

            var skillPoints = GameController.SkillPoints;

            skillPointsScore.GetComponent<Text>().text = skillPoints.ToString();
            movementScore.GetComponent<Text>().text = GameController.CurrentMovementSpeed.ToString();
            attackScore.GetComponent<Text>().text = GameController.LightAttackDamage.ToString();
            healthScore.GetComponent<Text>().text = GameController.MaxHealthPoints.ToString();

            if (skillPoints == 0) {
                upgradeMovementButton.GetComponent<Button>().interactable = false;
                upgradeAttackButton.GetComponent<Button>().interactable = false;
                upgradeHealthButton.GetComponent<Button>().interactable = false;
            }
        }

        // Update is called once per frame
        private void Update() {
            var skillPoints = GameController.SkillPoints;

            skillPointsScore.GetComponent<Text>().text = skillPoints.ToString();
            movementScore.GetComponent<Text>().text = GameController.CurrentMovementSpeed.ToString();
            attackScore.GetComponent<Text>().text = GameController.LightAttackDamage.ToString();
            healthScore.GetComponent<Text>().text = GameController.MaxHealthPoints.ToString();

            if (skillPoints == 0) {
                upgradeMovementButton.GetComponent<Button>().interactable = false;
                upgradeAttackButton.GetComponent<Button>().interactable = false;
                upgradeHealthButton.GetComponent<Button>().interactable = false;
            } else {
                upgradeMovementButton.GetComponent<Button>().interactable = true;
                upgradeAttackButton.GetComponent<Button>().interactable = true;
                upgradeHealthButton.GetComponent<Button>().interactable = true;
            }
        }
    }
}
