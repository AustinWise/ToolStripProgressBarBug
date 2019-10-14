using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        PropertyInfo mRequiresScale;
        PropertyInfo mRequiredScalingEnabled;
        public Form1()
        {
            this.mRequiresScale = typeof(Control).GetProperty("RequiredScaling", BindingFlags.NonPublic | BindingFlags.Instance);
            this.mRequiredScalingEnabled = typeof(Control).GetProperty("RequiredScalingEnabled", BindingFlags.NonPublic | BindingFlags.Instance);

            InitializeComponent();
        }

        void showScale()
        {
            if (DesignMode)
                return;
            var sb = new StringBuilder();
            sb.AppendLine($"toolStripProgressBar1.Height: {toolStripProgressBar1.Height}");
            sb.AppendLine($"toolStripProgressBar1.Control.{mRequiresScale.Name}: {mRequiresScale.GetValue(this.toolStripProgressBar1.Control)}");
            sb.AppendLine($"toolStripProgressBar1.Control.{mRequiredScalingEnabled.Name}: {mRequiredScalingEnabled.GetValue(this.toolStripProgressBar1.Control)}");
            sb.AppendLine($"toolStripProgressBar1.Control.Font font: {toolStripProgressBar1.Control.Font.Name}");
            sb.AppendLine($"statusStrip1.Control.Font font: {statusStrip1.Font.Name}");
            MessageBox.Show(sb.ToString());
        }
    }
}
