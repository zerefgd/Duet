using System.Collections.Generic;

namespace Constants
{
    public class DATA
    {
        public const string CURRENT_LEVEL = "CURRENT_LEVEL";
        public const string SETTINGS_SOUND = "SETTINGS_SOUND";
        public static readonly List<string> START_MESSAGES = new()
        {
            "Its good to see you. Stay close to me, and don’t touch anything.",
            " You will need a circular state of mind.",
            "This will be easy, just hold left.",
            " Never give up.",
            " Some things are worth fighting for.",
            " Some things are worth fighting for.",

            "This will be full of unexpected twists and turns.",
            "Tread carefully, and control yourself",
            "Trust your instincts.",
            "Change is normal.",
            "Do not deny it.",
            "Embrace it."
        };


    }

    public class AnimationNames
    {
        public const string MAINMENU_MENUPANEL_LEFT = "AN_MainMenu_MenuPanel_Left";
        public const string MAINMENU_MENUPANEL_RIGHT = "AN_MainMenu_MenuPanel_Right";
        public const string MAINMENU_LEVELPANEL_LEFT = "AN_MainMenu_LevelPanel_Left";
        public const string MAINMENU_LEVELPANEL_RIGHT = "AN_MainMenu_LevelPanel_Right";
        public const string GAME_TEXT_DEFAULT = "AN_Game_Text_Default";
    }


    public class Tags
    {
        public const string RESPAWN = "Respawn";
        public const string FINISH = "Finish";
    }
}