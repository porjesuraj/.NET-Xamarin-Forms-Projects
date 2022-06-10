using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace layout.RelativePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RelativePage : ContentPage
    {
        public RelativePage()
        {
            InitializeComponent();

            #region Relative layout by code
/*
            var layout = new RelativeLayout();

            var aquaBox = new BoxView { Color = Color.Aqua };
            layout.Children.Add(aquaBox,
                widthConstraint: Constraint.RelativeToParent(Parent => Parent.Width),
                heightConstraint: Constraint.RelativeToParent(Parent => Parent.Height * 0.3)

                );

            var silverBox = new BoxView { Color = Color.Silver };

            layout.Children.Add(silverBox,
                
                yConstraint: Constraint.RelativeToView(aquaBox,(RelativeLayout,element) => element.Height + 20)
                );

            Content = layout; */
            #endregion




        }
    }
}