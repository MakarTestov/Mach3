using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tags
{
    /// <summary>
    /// Для получения имен сцен игры
    /// </summary>
    static class AllNameScene
    {
        public static string GetName_MineMenu() => "MineMenu";
        public static string GetName_Records() => "Records";
        public static string GetName_About() => "About";
        public static string GetName_GameScene() => "Game";
    }
}
