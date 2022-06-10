﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliverApp.Droid
{
    [Activity(Label = "TabActivity")]
    public class TabActivity : FragmentActivity
    {
        TabLayout tabLayout;

       Android.Support.V7.Widget.Toolbar tabsToolbar; 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Tabs);
            // Create your application here

            tabsToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tabsToolbar); 

            tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabLayout) ;

            tabLayout.TabSelected += TabLayout_TabSelected;

            tabsToolbar.InflateMenu(Resource.Menu.tabsmenu);

            tabsToolbar.MenuItemClick += TabsToolbar_MenuItemClick;



            FragmentNavigate(new DeliveriesFragment());
        }

        private void TabsToolbar_MenuItemClick(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            
            if(e.Item.ItemId == Resource.Id.action_add)
            {
                StartActivity(typeof(NewDeliveryActivity));
            }
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmentNavigate(new DeliveriesFragment());
                    break;

                case 1:
                    FragmentNavigate(new DeliveredFragment());
                    break;


                case 2:
                    FragmentNavigate(new ProfileFragment());

                    break;

                default:
                    break;
            }
        }


        private void FragmentNavigate(Android.Support.V4.App.Fragment fragment)
        {
            var transaction = SupportFragmentManager.BeginTransaction();

            transaction.Replace(Resource.Id.contentFrame, fragment);
            transaction.Commit();
        }
    }
}