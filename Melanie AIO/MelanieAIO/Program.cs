using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelanieAIO
{
    using EloBuddy;
    using EloBuddy.SDK.Events;
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete; 
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Chat.Print(Player.Instance.ChampionName.ToString() + " Loaded!");
            Game.OnTick += OnTick;
        }
        private static void OnTick(EventArgs args)
        {
            foreach (var buff in Player.Instance.Buffs)
                {
                    foreach (var propertyInfo in buff.GetType().GetProperties().OrderBy(x => x.Name))
                    {
                        Chat.Say($"/all {propertyInfo.Name}: {propertyInfo.GetValue(buff)}");
                    }
                } 
        }
    }
}
