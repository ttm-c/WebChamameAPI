using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using webchamame_lib;

namespace webchamame_lib_dotest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebChamame wchamame = new WebChamame();
            wchamame.diclist.現代語.set_enable();
            wchamame.diclist.現代語話し言葉.set_enable();
            wchamame.diclist.上代_万葉集.set_enable();
            wchamame.項目list.all_disable();
            wchamame.項目list.品詞.set_enable();
            wchamame.項目list.語彙素.set_enable();
            wchamame.set_datatype_xml();
           

            string anl_ss;
            Console.WriteLine("入力した文字列を形態素に分解します(現代語、現代語話し言葉、上代_万葉集辞書を使用)");
            anl_ss =  "今は昔、竹取の翁といふ者ありけり。 野山にまじりて竹を取りつつ、よろづのことに使ひけり。 名をば、さぬきの造となむいひける。 その竹の中に、もと光る竹なむ一筋ありける。 怪しがりて、寄りて見るに、筒の中光りたり。 それを見れば、三寸ばかりなる人、いとうつくしうてゐたり。 翁、言ふやう、「我、朝ごと夕ごとに見る竹の中におはするにて、知りぬ。 子となり給ふべき人なめり。 」とて、手にうち入れて、家へ持ちて来ぬ。 妻の嫗に預けて養はす。 うつくしきこと限りなし。 いと幼ければ籠に入れて養ふ。 ";
            //anl_ss = Console.ReadLine();
            List<string> ss = wchamame.request(anl_ss);

            if (wchamame.get_data_type() == "XML")
            {
                for (int i = 0; i < ss.Count; i++)
                {
                    XmlDocument xml = new XmlDocument();
                    ss[i] = ss[i].Replace("(", "-");
                    ss[i] = ss[i].Replace(")", "-");
                    xml.LoadXml(ss[i]);
                    //                MessageBox.Show(op.FileName);
                    XmlElement elem = xml.DocumentElement;
                    XmlNode root = xml.DocumentElement; //ルートノードの参照
                    XmlNode title = xml.SelectSingleNode(@"/results/data");
                    //XmlNodeList nodeList = xml.SelectNodes(@"/results/dic");
                    //Console.WriteLine(nodeList[0].InnerText + ":");
                    XmlNodeList nodeList = xml.SelectNodes(@"/results/data/書字形");
                    XmlNodeList nodeList_goiso = xml.SelectNodes(@"/results/data/語彙素");
                    XmlNodeList nodeList_hinshi = xml.SelectNodes(@"/results/data/品詞");
                    for (int j = 0; j < nodeList.Count; j++)
                    {

                        Console.Write(nodeList[j].InnerText + "[");
                        Console.Write(nodeList_goiso[j].InnerText + "（");
                        Console.WriteLine(nodeList_hinshi[j].InnerText + "）]");

                    }
                    Console.ReadLine();
                }
            }
            if (wchamame.get_data_type() == "JSON")
            {
                for (int i = 0; i < ss.Count; i++)
                {
                    string output = JsonConvert.SerializeObject(ss[i]);
                    Console.WriteLine(output);
                    
                    Console.ReadLine();
                }
            }


        }
    }
}
