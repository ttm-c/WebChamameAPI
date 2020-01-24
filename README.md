#Web茶まめの解析機能を叩くためのライブラリです

C#で作成。
含まれているプロジェクトは以下の2つ。
webchamame_lib　－－ライブラリ本体　\bin\Release内のwebchamame_lib.dllを各自のプロジェクトに読み込むと使用できる。
webchamame_lib_dotest　－－動作テスト用のサンプルプログラム　

：webchamame_libの使用方法
任意のプロジェクトでwebchamame_lib.dllを参照に追加し　WebChamame　オブジェクトを生成し使用する。
オブジェクト作成後、各種メソッドを呼び出し必要な設定を行い、request(string)メソッドに解析対象の文章を渡す。
WebChamameクラスが持つメソッドは以下のとおり。

    WebChamame() －－オブジェクト作成時のコンストラクタ
    List<string> request(string)  －－Web茶まめサーバにリクエストを送信する。引数にとった文字列が解析対象となる。有効化した辞書全てで解析リクエストを行う。戻り値のリストには、それぞれの辞書で解析した結果が返却される。
    void set_datatype_json()  －－データ取得タイプをJSONに設定
    void set_datatype_xml()  －－データ取得タイプをXMLに設定
    string get_data_type()  －－設定されているデータ取得タイプを取得、"XML"か"JSON"が返却される

WebChamameクラスは設定として以下のオブジェクトを持っている。
    項目data  －－取得する辞書項目を設定するオブジェクト。WebChamameクラスでは次の24項目が用意されている。それぞれ、有効化するvoid set_enable()、無効化するvoid set_disable()、有効無効を確認する bool get_status()メソッドを持っている。語彙素, 語彙素読み, 品詞, 活用型, 活用形, 発音形出現形, 仮名形出現形, 語種, 書字形_基本形, 発音形_基本形, 仮名形_基本形, 語形_基本形, 語頭変化型, 語頭変化形, 語頭変化結合型, 語末変化型, 語末変化形, 語末変化結合型, アクセント型, アクセント接続型, アクセント修飾型
    dics  －－解析を行う辞書を設定するオブジェクト。WebChamameクラスでは次の9項目が用意されている。それぞれ、有効化するvoid set_enable()、無効化するvoid set_disable()、有効無効を確認する bool get_status()メソッドを持っている。現代語, 現代語話し言葉, 近代文語, 近世口語_洒落本, 中世口語_狂言, 上代_万葉集, 旧仮名口語, 中古和文, 中世文語_説話随筆。
    request()メソッドを実行したときには、この記述順番で有効化された辞書での解析がリクエストされる。例えば、現代語と近代文語が有効化されていた場合、現代語辞書での解析が先にリクエストされ、次に近代文語辞書での解析がリクエストされる。


Web茶まめから現代語、現代話し言葉、上代_万葉集辞書で解析を行い、品詞、語彙素をJSON形式で取得するサンプルプログラムは以下の通り。

    static void Main(string[] args)
            {
                WebChamame wchamame = new WebChamame();//オブジェクト作成
                wchamame.diclist.現代語.set_enable();//現代語辞書での解析を有効化
                wchamame.diclist.上代_万葉集.set_enable();//上代＿万葉集辞書での解析を有効化
                wchamame.diclist.現代語話し言葉.set_enable();//現代語話言葉辞書での解析を有効化
                wchamame.項目list.all_disable();//出力項目を一度全て無効化　デフォルトで有効化されている出力項目のみで良い場合は必要ない
                wchamame.項目list.品詞.set_enable();//品詞項目の出力を有効化
                wchamame.項目list.語彙素.set_enable();//語彙素項目の出力を有効化
                wchamame.set_datatype_json();//出力形式をJSONに設定

                List<string> ss = wchamame.request("解析対象文字列をここに入れる");
                for (int i = 0; i < ss.Count; i++)
                    {
                        Console.WriteLine(ss[i]);//現代語、現代語話し言葉、上代_万葉集の順で表示される。
                    }
            }
