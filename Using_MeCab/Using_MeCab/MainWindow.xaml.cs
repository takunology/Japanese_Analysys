using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Using_MeCab
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        string output = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MeCab_Open(object sender, RoutedEventArgs e)
        {
            Process Mecab = new Process();

            Mecab.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            //Mecab.StartInfo.StandardOutputEncoding = Encoding.Unicode;

            Mecab.StartInfo.RedirectStandardInput = true;
            Mecab.StartInfo.FileName = "mecab";            // コマンド名
            //Mecab.StartInfo.Arguments = "";               // 引数
            Mecab.StartInfo.CreateNoWindow = true;            // DOSプロンプトの黒い画面を非表示
            Mecab.StartInfo.UseShellExecute = false;          // プロセスを新しいウィンドウで起動するか否か
            Mecab.StartInfo.RedirectStandardOutput = true;    // 標準出力をリダイレクトして取得したい

            Mecab.Start();

            Mecab.StandardInput.Write(Submit_Text.Text + "\n");

            while (true)
            {
                output += Mecab.StandardOutput.ReadLine() + "\n";
                if(Mecab.StandardOutput.ReadLine() == "EOS")
                {
                    break;
                }
            }
            //Mecab.WaitForExit();

            Mecab.Close();

            OutPut.Content = output;
            output = "";
        }
    }
}
