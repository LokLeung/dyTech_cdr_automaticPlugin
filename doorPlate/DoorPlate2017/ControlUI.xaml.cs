using System.Windows;
using System.Windows.Controls;
using corel = Corel.Interop.VGCore;

namespace DoorPlate2017
{

    public partial class ControlUI : UserControl
    {
        private corel.Application corelApp;
        public ControlUI(corel.Application app)
        {
            this.corelApp = app;
            InitializeComponent();
            btn_Command.Click += (s, e) => { global::System.Windows.MessageBox.Show("Working"); };
        }

        private void btn_Command_Click(object sender, RoutedEventArgs e)
        {
            Form1 f1 = new Form1(corelApp);
            f1.TopMost = true;
            f1.Show();
        }
    }
}
