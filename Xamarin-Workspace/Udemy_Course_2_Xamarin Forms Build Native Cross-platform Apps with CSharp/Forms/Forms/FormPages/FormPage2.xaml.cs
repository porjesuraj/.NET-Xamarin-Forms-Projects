using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Forms.FormPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormPage2 : ContentPage
    {
        private IList<ContactMethod> _contactmethods;
        public FormPage2()
        {
            InitializeComponent();

            _contactmethods = GetContactMethods();

            foreach (var method in _contactmethods)
                picker.Items.Add(method.Name);
                

        }

        private void contactMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            var contactmethod = contactMethods.Items[contactMethods.SelectedIndex];

            DisplayAlert("Response", contactmethod, "OK");
        }

        private void contactMethods_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            var name = picker.Items[picker.SelectedIndex];

           var conmethod =  _contactmethods.Single(cm => cm.Name == name);

          var id =   conmethod.Id;

            DisplayAlert("Selection", name +" :" + id, "OK");
        }

        public class ContactMethod
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private IList<ContactMethod> GetContactMethods()
        {
            return new List<ContactMethod>
            {
                new ContactMethod{ Id=1, Name="SMS"},
                new ContactMethod{ Id=2, Name="Email"},
                new ContactMethod{ Id=3, Name="Whatsapp"},
            };
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            dLabel.Text = e.NewDate.ToString("d MMM yyyy"); 
        }
    }
}