using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _8.Inheritence.Classes
{
    class Radio : ElectricalDevice
    {
      

        public Radio(bool isOn, string brand):base(isOn,brand)
        {
            IsOn = isOn;
            Brand = brand;
        }

      
        public override void DeviceStatus()
        {
            if (IsOn)
            {
                Console.WriteLine("Listening to the Radio!");
                MessageBox.Show("RADIO is On", "Success", MessageBoxButton.OK);
            }
            else
            {
                Console.WriteLine("Radio is switched off,switch it on first");
                MessageBox.Show("Radio is Off", "Error", MessageBoxButton.OK);

            }
        }

    }
}
