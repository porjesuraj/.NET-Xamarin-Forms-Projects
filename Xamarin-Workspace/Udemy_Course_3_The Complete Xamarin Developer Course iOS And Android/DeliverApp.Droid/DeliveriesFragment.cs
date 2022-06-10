using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using DeliverApp.Droid.Adapters;
using DeliverApp.Droid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliverApp.Droid
{
    public class DeliveriesFragment : Android.Support.V4.App.ListFragment  
    {
        public async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var deliveries = await Delivery.GetDeliveries();
            //  ListAdapter = new ArrayAdapter(Activity, Android.Resource.Layout.SimpleListItem1, deliveries);

            ListAdapter = new DeliveryAdapter(Activity, deliveries); 






            // Create your fragment here
        }

        public DeliveriesFragment()
        {

        }
      /*  public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             return inflater.Inflate(Resource.Layout.Deliveries, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }*/
    }
}