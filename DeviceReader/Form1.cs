using PipeTestClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceReader
{
    public partial class Form1 : Form
    {
        private LinkClient client = new LinkClient();

        private List<Device> devices = new List<Device>();

        public Form1()
        {
            InitializeComponent();
            client.Start();
        }

        private void btnReadDevices_Click(object sender, EventArgs e)
        {
            lbDevices.Items.Clear();
            devices.Clear();
            devices.
        }
    }
}
