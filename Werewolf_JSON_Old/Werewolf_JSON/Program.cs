using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"C:\Users\takun\Desktop\学校用\プログラム設計法\werewolfworld-gh-pages\village\example\0.3\server2client\morning.jsonld";
            var JsonText = File.ReadAllText(FilePath);
            Console.WriteLine(JsonText);
            var CharacterJson = JsonConvert.DeserializeObject<Character>(JsonText);
            //var RoleJson = JsonConvert.DeserializeObject<Role>(JsonText);

            Console.WriteLine("取得データ " + CharacterJson.Id + " " + CharacterJson.Name);
                
            //Console.WriteLine("役職 " + RoleJson.Id + " " + RoleJson.Name);
            Console.ReadKey();
        }
    }
}
