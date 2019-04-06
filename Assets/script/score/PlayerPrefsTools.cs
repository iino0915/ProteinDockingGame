namespace GAPP
{

    using System.Collections.Generic;

    public class PlayerPrefsTools
    {
        public static void GetAllPlayerPrefKeys(ref List<string> keys)
        {
            if (keys != null)
            {
                keys.Clear();
            }
            else
            {
                keys = new List<string>();
            }

#if UNITY_STANDALONE_WIN
		// Unity stores prefs in the registry on Windows
		string regKeyPathPattern =
#if UNITY_EDITOR
		@"Software\Unity\UnityEditor\{0}\{1}";
#else
		@"Software\{0}\{1}";
#endif
		;

		string regKeyPath = string.Format(regKeyPathPattern, UnityEditor.PlayerSettings.companyName, UnityEditor.PlayerSettings.productName);
		Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regKeyPath);
		if (regKey == null)
		{
			return;
		}

		string[] playerPrefKeys = regKey.GetValueNames();
		for (int i = 0; i < playerPrefKeys.Length; i++)
		{
			string playerPrefKey = playerPrefKeys[i];

			// Remove the _hXXXXX suffix
			playerPrefKey = playerPrefKey.Substring(0, playerPrefKey.LastIndexOf("_h"));

			keys.Add(playerPrefKey);
		}
#endif
        }
    }
}