using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _8.Inheritence.Classes
{
    internal class TV : ElectricalDevice
    {
        public TV(bool isOn, string brand) : base(isOn, brand)
        {
        }

        public override void DeviceStatus()
        {
            if (IsOn)
            {
                Console.WriteLine("Watching TV!");
                MessageBox.Show("TV is switched On", "Success", MessageBoxButton.OK);
            }
            else
            {
                Console.WriteLine("TV is switched off,switch it on first");
                MessageBox.Show("TV is switched Off", "Error", MessageBoxButton.OK);

            }
        }
    }
}
