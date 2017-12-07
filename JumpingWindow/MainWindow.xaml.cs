using System.Windows;
using System.Windows.Input;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
namespace JumpingWindow
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var engineMain = Python.CreateEngine();
            //ビルトインスコープに追加するとスクリプト側が複数ファイルで構成されていてもwindowが参照可能
            ScriptScope builtin = engineMain.GetBuiltinModule();
            builtin.SetVariable("window", this);
            engineMain.ExecuteFile("jumping.py");
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}