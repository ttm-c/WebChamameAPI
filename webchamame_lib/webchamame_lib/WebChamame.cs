using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webchamame_lib
{
    public class WebChamame
    {
        public string Url { get; set; }
        public dics diclist = new dics();
        public 項目 項目list = new 項目();
        private string return_data_type ="JSON";


        public WebChamame()//オブジェクト作成時のコンストラクタ
        {
            Url = "http://chamame.ninjal.ac.jp/chamamebin/request.php";
        }
        public void set_datatype_json() {
            return_data_type = "JSON";
        }
        public void set_datatype_xml()
        {
            return_data_type = "XML";
        }
        public string get_data_type()
        {
            return return_data_type;
        }

        public List<string> request(string st)
        {
            List<string> return_st = new List<string>();


            if (diclist.現代語.get_status()) { return_st.Add(web_req(st, diclist.現代語)); }
            if (diclist.現代語話し言葉.get_status()) { return_st.Add(web_req(st, diclist.現代語話し言葉)); }
            if (diclist.近代文語.get_status()) { return_st.Add(web_req(st, diclist.近代文語)); }
            if (diclist.近世口語_洒落本.get_status()) { return_st.Add(web_req(st, diclist.近世口語_洒落本)); }
            if (diclist.中世口語_狂言.get_status()) { return_st.Add(web_req(st, diclist.中世口語_狂言)); }
            if (diclist.上代_万葉集.get_status()) { return_st.Add(web_req(st, diclist.上代_万葉集)); }
            if (diclist.旧仮名口語.get_status()) { return_st.Add(web_req(st, diclist.旧仮名口語)); }
            if (diclist.中古和文.get_status()) { return_st.Add(web_req(st, diclist.中古和文)); }
            if (diclist.中世文語_説話随筆.get_status()) { return_st.Add(web_req(st, diclist.中世文語_説話随筆)); }



            return return_st;
        }

        private string web_req(string st, dic d)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            //NameValueCollectionの作成
            System.Collections.Specialized.NameValueCollection ps =
                new System.Collections.Specialized.NameValueCollection();
            //送信するデータ（フィールド名と値の組み合わせ）を追加

            ps.Add("dic", d.value);
            ps.Add("data", st);//解析データを入力
            ps.Add("return_data_type", return_data_type);

            if (項目list.語彙素.get_status()) { ps.Add("f1", "1"); }
            if (項目list.語彙素読み.get_status()) { ps.Add("f2", "1"); }
            if (項目list.品詞.get_status()) { ps.Add("f3", "1"); }
            if (項目list.活用型.get_status()) { ps.Add("f4", "1"); }
            if (項目list.活用形.get_status()) { ps.Add("f5", "1"); }
            if (項目list.発音形出現形.get_status()) { ps.Add("f9", "1"); }
            if (項目list.仮名形出現形.get_status()) { ps.Add("f10", "1"); }
            if (項目list.語種.get_status()) { ps.Add("f11", "1"); }
            if (項目list.書字形_基本形.get_status()) { ps.Add("f12", "1"); }
            if (項目list.発音形_基本形.get_status()) { ps.Add("f13", "1"); }
            if (項目list.仮名形_基本形.get_status()) { ps.Add("f14", "1"); }
            if (項目list.語形_基本形.get_status()) { ps.Add("f15", "1"); }
            if (項目list.語頭変化型.get_status()) { ps.Add("f16", "1"); }
            if (項目list.語頭変化形.get_status()) { ps.Add("f17", "1"); }
            if (項目list.語末変化結合型.get_status()) { ps.Add("f18", "1"); }
            if (項目list.語末変化型.get_status()) { ps.Add("f19", "1"); }
            if (項目list.語末変化形.get_status()) { ps.Add("f20", "1"); }
            if (項目list.語末変化結合型.get_status()) { ps.Add("f21", "1"); }
            if (項目list.アクセント型.get_status()) { ps.Add("f22", "1"); }
            if (項目list.アクセント接続型.get_status()) { ps.Add("f23", "1"); }
            if (項目list.アクセント修飾型.get_status()) { ps.Add("f24", "1"); }


            //データを送信し、また受信する
            byte[] resData = wc.UploadValues(Url, ps);
            wc.Dispose();

            //受信したデータを表示する
            string resText = System.Text.Encoding.UTF8.GetString(resData);

            return resText;
        }

    }
    public class 項目
    {
        public 項目data 語彙素, 語彙素読み, 品詞, 活用型, 活用形, 発音形出現形, 仮名形出現形, 語種, 書字形_基本形, 発音形_基本形, 仮名形_基本形, 語形_基本形, 語頭変化型, 語頭変化形, 語頭変化結合型, 語末変化型, 語末変化形, 語末変化結合型, アクセント型, アクセント接続型, アクセント修飾型;

        public 項目()
        {
            語彙素 = new 項目data(); 語彙素.set_enable();
            語彙素読み = new 項目data(); 語彙素読み.set_enable();
            品詞 = new 項目data(); 品詞.set_enable();
            活用型 = new 項目data(); 活用型.set_enable();
            活用形 = new 項目data(); 活用形.set_enable();
            発音形出現形 = new 項目data(); 発音形出現形.set_enable();
            仮名形出現形 = new 項目data(); 仮名形出現形.set_enable();
            語種 = new 項目data(); 語種.set_enable();
            書字形_基本形 = new 項目data(); 書字形_基本形.set_enable();
            発音形_基本形 = new 項目data(); 発音形_基本形.set_enable();
            仮名形_基本形 = new 項目data(); 仮名形_基本形.set_enable();
            語形_基本形 = new 項目data(); 語形_基本形.set_enable();
            語頭変化型 = new 項目data();
            語頭変化形 = new 項目data();
            語頭変化結合型 = new 項目data();
            語末変化型 = new 項目data();
            語末変化形 = new 項目data();
            語末変化結合型 = new 項目data();
            アクセント型 = new 項目data();
            アクセント接続型 = new 項目data();
            アクセント修飾型 = new 項目data();

        }
        public void all_disable()
        {
            語彙素.set_disable();
            語彙素読み.set_disable();
            品詞.set_disable();
            活用型.set_disable();
            活用形.set_disable();
            発音形出現形.set_disable();
            仮名形出現形.set_disable();
            語種.set_disable();
            書字形_基本形.set_disable();
            発音形_基本形.set_disable();
            仮名形_基本形.set_disable();
            語形_基本形.set_disable();
            語頭変化型.set_disable();
            語頭変化形.set_disable();
            語頭変化結合型.set_disable();
            語末変化型.set_disable();
            語末変化形.set_disable();
            語末変化結合型.set_disable();
            アクセント型.set_disable();
            アクセント接続型.set_disable();
            アクセント修飾型.set_disable();


        }
    }

    public class 項目data
    {
        private bool enable;
        public 項目data()
        {
            enable = false;
        }
        public void set_enable()
        {
            enable = true;
        }
        public void set_disable()
        {
            enable = false;
        }
        public bool get_status()
        {
            return enable;
        }

    }
    public class dics
    {

        public dic 現代語 = new dic("現代語", "gendai");
        public dic 現代語話し言葉 = new dic("現代語話し言葉", "unidic-spoken");
        public dic 近代文語 = new dic("近代文語", "kindai");
        public dic 近世口語_洒落本 = new dic("近世口語（洒落本）", "kinsei");
        public dic 中世口語_狂言 = new dic("中世口語（狂言）", "kyogen");
        public dic 上代_万葉集 = new dic("上代（万葉集）", "manyo");
        public dic 旧仮名口語 = new dic("旧仮名口語", "qkana");
        public dic 中古和文 = new dic("中古和文", "wabun");
        public dic 中世文語_説話随筆 = new dic("中世文語（説話・随筆）", "wakan");

    }

    public class dic
    {
        public readonly string name;
        public readonly string value;
        private bool enable;//  { get; set; }

        public dic(string n, string v)
        {
            name = n;
            value = v;
            enable = false;

        }
        public void set_enable()
        {
            enable = true;
        }
        public void set_disable()
        {
            enable = false;
        }
        public bool get_status()
        {
            return enable;
        }
    }

}
