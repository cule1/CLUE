namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UI_Keyboard : MonoBehaviour
    {
        [HideInInspector]
        public string inputSentence;

        private InputField input;

        public void ClickKey(string character)
        {
            input.text += character;
        }

        public void Backspace()
        {
            if (input.text.Length > 0)
            {
                input.text = input.text.Substring(0, input.text.Length - 1);
            }
        }

        public void Enter()
        {
            inputSentence = input.text;
            //VRTK_Logger.Info("You've typed [" + input.text + "]");
            input.text = "";
        }

        private void Start()
        {
            input = GetComponentInChildren<InputField>();
        }
    }
}