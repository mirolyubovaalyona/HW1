using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HW1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public string[] Monkeys { get; set; }
        public Page1()
        {
            InitializeComponent();
            Monkeys = new string[] { "iPhone 8", "Samsung Galaxy S9", "Huawei P10", "LG G6" };
            this.BindingContext = this;
        }
    }
}