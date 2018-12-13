using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class GameSceneController : MonoBehaviour {
        private GameObject healthMeter;
        private GameObject rageMeter;
        private GameObject levelText;
        private GameObject xpText;
        private GameObject skillPointsText;

        // Use this for initialization
        void Start() {
            healthMeter = GameObject.FindWithTag("GameHealthMeter");
            rageMeter = GameObject.FindWithTag("GameRageMeter");
            levelText = GameObject.FindWithTag("GameLevelText");
            xpText = GameObject.FindWithTag("GameXPText");
            skillPointsText = GameObject.FindWithTag("GameSkillPointsText");

            healthMeter.GetComponent<Slider>().value =
                (float) (GameController.CurrentHealthPoints / GameController.MaxHealthPoints * 100);
            rageMeter.GetComponent<Slider>().value =
                (float) (GameController.CurrentRageValue / GameController.MaxRageValue * 100);
            levelText.GetComponent<Text>().text = "LEVEL: " + GameController.CurrentGameLevel;
            xpText.GetComponent<Text>().text =
                "XP: " + GameController.CurrentXP + "/" + GameController.CurrentLevelMaxXp;
            skillPointsText.GetComponent<Text>().text = "SKILL POINTS: " + GameController.SkillPoints;
        }

        // Update is called once per frame
        void Update() {
            healthMeter.GetComponent<Slider>().value =
                (float) (GameController.CurrentHealthPoints / GameController.MaxHealthPoints * 100);
            rageMeter.GetComponent<Slider>().value =
                (float) (GameController.CurrentRageValue / GameController.MaxRageValue * 100);
            levelText.GetComponent<Text>().text = "LEVEL: " + GameController.CurrentGameLevel;
            xpText.GetComponent<Text>().text =
                "XP: " + GameController.CurrentXP + "/" + GameController.CurrentLevelMaxXp;
            skillPointsText.GetComponent<Text>().text = "SKILL POINTS: " + GameController.SkillPoints;
        }
    }
}
