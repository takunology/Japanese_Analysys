using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace Analysys001
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("libmecab.dll")]
        extern static IntPtr mecab_new2(string arg);
        [DllImport("libmecab.dll")]
        extern static IntPtr mecab_sparse_tostr(IntPtr m, string str);
        [DllImport("libmecab.dll")]
        extern static void mecab_destroy(IntPtr m);

        Process process = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Question(object sender, RoutedEventArgs e)
        {
            IntPtr mecab = mecab_new2("もじもじ");
            IntPtr s = mecab_sparse_tostr(mecab, qu.Content.ToString());
            label_answer.Content = Marshal.PtrToStringAnsi(s);
            mecab_destroy(mecab);
        }
    }
}
