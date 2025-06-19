using UnityEngine;

namespace Savers
{
    public class PlayerPrefsInputSaver : InputSaver
    {
        private const string INPUT_SAVE_KEY = "InputSave";

        public override void SaveInput(string input)
        {
            PlayerPrefs.SetString(INPUT_SAVE_KEY, input);
        }

        public override bool HasRestoreInput(out string input)
        {
            if (PlayerPrefs.HasKey(INPUT_SAVE_KEY))
            {
                input = PlayerPrefs.GetString(INPUT_SAVE_KEY);
                PlayerPrefs.DeleteKey(INPUT_SAVE_KEY);
                return true;
            }
            else
            {
                input = string.Empty;
                return false;
            }
        }
    }
}