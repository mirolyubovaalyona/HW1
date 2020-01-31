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
    public partial class Page1 : ContentPage
    {
        
        public List<Phone> Phones { get; set; }
        public class Phone
        {
            public string Title { get; set; }
            public string ImagePath { get; set; }
            public string Company { get; set; }
            public int Price { get; set; }
        }
        public Page1()
        {
            InitializeComponent();
            Phones = new List<Phone>
            {
                new Phone {Title="Очищенная вода", Company="Питьевая вода, в которой нет радиоактивных примесей.", Price=48000, ImagePath="FO3_purified_water.png" },
                new Phone {Title="Грязная вода", Company="Грязная вода является наиболее распространенным видом воды.", Price=35000, ImagePath="FO3_dirty_water.png" },
                new Phone {Title="Ядер-кола", Company="Этот продукт — вершина вкусовых ощущений.", Price=42000, ImagePath="FO3NukaCola" },
                new Phone {Title="Пиво", Company="И сказал Бог: да будет у них пиво.", Price=42000, ImagePath="Fo4_Beer.png" },
                new Phone {Title="Свежая вода", Company="Я начинаю думать, что свежая вода даже лучше, чем очищенная!", Price=52000, ImagePath="FO3BS_aqua_pura.png" }
            };

            Label header = new Label
            {
                Text = "Список вод",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Brown,
            };
            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = Phones,
                // Определяем формат отображения данных
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Brown, DetailColor = Color.DarkKhaki };
                    imageCell.SetBinding(ImageCell.TextProperty, "Title");
                    Binding companyBinding = new Binding { Path = "Company", StringFormat = "Оно примерно такое: {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "ImagePath");
                    return imageCell;
                })
            };

            listView.SeparatorColor = Color.Yellow;
            listView.BackgroundColor = Color.DarkCyan;
            listView.ItemTapped += OnItemTapped;
            this.Content = new StackLayout { Children = { header, listView } };
            this.BindingContext = this;
        }
        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Phone selectedPhone = e.Item as Phone;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная влага", $"{selectedPhone.Company} - {selectedPhone.Title}", "Хмммммммм");
                var result = await DisplayAlert("Твоя вода", "Точно купишь?", "Yes", "No");
            if (result)
            {
                // user said Yes!!!
            }
        }
    }
}