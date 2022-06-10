using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _8.Inheritence.Classes
{
    class ElectricalDevice
    {
        public bool IsOn { get; set; }

        public string Brand { get; set; }

        public ElectricalDevice(bool isOn, string brand)
        {
            IsOn = isOn;
            Brand = brand;
        }

        public void SwitchOn() => IsOn = true;
        public void SwitchOff() => IsOn = false;

        public virtual void DeviceStatus()
        {
            if (IsOn)
            {
                Console.WriteLine("Electric Device is On!");
                MessageBox.Show(" Device is On", "Success", MessageBoxButton.OK);
            }
            else
            {
                Console.WriteLine(" Device is switched off,switch it on first");
                MessageBox.Show(" Device is Off", "Error", MessageBoxButton.OK);

            }
        }
    }
}
