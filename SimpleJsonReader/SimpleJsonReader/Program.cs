using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SimpleJsonReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\Users\takun\Desktop\学校用\プログラム設計法\werewolfworld-gh-pages\village\example\0.3\server2client\morning.jsonld";
            var s = new DataContractJsonSerializer(typeof(Data));
            var json = File.ReadAllText(file);

            var ms = new MemoryStream(Encoding.UTF8.GetBytes((json)));
          
            //s.WriteObject(ms, new Data { Name = "たくのろじぃ" });
            //Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
            ms.Seek(0, SeekOrigin.Begin);
            var data = s.ReadObject(ms) as Data;
            var data2 = s.ReadObject(ms) as Village;
            Console.WriteLine($"ID : {data.Id}");
            for (int i = 0; i < data.Context.GetLength(0); i++)
            Console.WriteLine($"context{i} : {data.Context[i].ToString()}");

            Console.WriteLine($"{data2.datas}");


        }
    }

    [DataContract]
    public class Data
    {
        [DataMember(Name = "@context")]
        public string[] Context { get; set; }

        [DataMember(Name = "@id")]
        public string Id { get; set; }
    }

    [DataContract]
    public class Village
    {
        [DataMember(Name = "village")]
        public object datas { get; set; }
    }

    /*[DataContract(Name = "village")]
    public class Village
    {
        [DataMember(Name = "name")]
        public string name { get; set; }
    }*/
}
