using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.ObjectModel;
using Xamarin.Forms;


using Xamarin.Forms.Xaml;

namespace HW1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public ObservableCollection<Phone> Phones { get; set; }
        public Page2()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone {Title="Очищенная вода", Company="Питьевая вода, в которой нет радиоактивных примесей.", Price=48000, ImagePath="FO3_purified_water.png" },
                new Phone {Title="Грязная вода", Company="Грязная вода является наиболее распространенным видом воды.", Price=35000, ImagePath="FO3_dirty_water.png" },
                new Phone {Title="Ядер-кола", Company="Этот продукт — вершина вкусовых ощущений.", Price=42000, ImagePath="FO3NukaCola" },
                new Phone {Title="Пиво", Company="И сказал Бог: да будет у них пиво.", Price=42000, ImagePath="Fo4_Beer.png" },
                new Phone {Title="Свежая вода", Company="Я начинаю думать, что свежая вода даже лучше, чем очищенная!", Price=52000, ImagePath="FO3BS_aqua_pura.png" }
            };
            this.BindingContext = this;
            InitializeComponent();
        }
        public class Phone
        {
            public string Title { get; set; }
            public string Company { get; set; }
            public int Price { get; set; }

            public string ImagePath { get; set; }
        }

        
        // удаление выделенного объекта
        private void RemoveItem(object sender, EventArgs e)
        {
            Phone phone = phonesList.SelectedItem as Phone;
            if (phone != null)
            {
                Phones.Remove(phone);
                phonesList.SelectedItem = null;
            }
        }
    }
}
