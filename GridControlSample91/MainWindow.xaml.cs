using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GridControlSample91 {

    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }

        public List<string> Periods { get; set; } = new List<string>() { "1D", "1W", "1M", "1Y" };
        

        protected ObservableCollection<ClassName> _Items;



        public ObservableCollection<ClassName> Items
        {
            get
            {
                if(this._Items == null)
                {
                    this._Items = new ObservableCollection<ClassName>();
                    Random r = new Random();
                    int i = -1;
                    while(++i < 150)
                    {
                        ClassName value = new ClassName();
                        value.Name = string.Format("Name #{0}", r.Next(100));
                        value.Period = Periods[r.Next(Periods.Count)];
                        value.Age = r.Next(40) + 20;
                        value.DateTime = DateTime.Today.AddDays(r.Next(30) - 15);
                        value.IsSelected = r.Next(2) > 0;
                        this._Items.Add(value);
                    }
                }
                return this._Items;
            }
        }

        public class ClassName : BindableBase {
            protected string _Name;
            public string Name
            {
                get { return this._Name; }
                set { this.SetProperty(ref this._Name, value, "Name"); }
            }


            protected string _Period;
            public string Period
            {
                get { return this._Period; }
                set { this.SetProperty(ref this._Period, value, "Period"); }
            }

            protected int _Age;
            public int Age
            {
                get { return this._Age; }
                set { this.SetProperty(ref this._Age, value, "Age"); }
            }

            protected DateTime _DateTime;
            public DateTime DateTime
            {
                get { return this._DateTime; }
                set { this.SetProperty(ref this._DateTime, value, "DateTime"); }
            }

            protected bool _IsSelected;
            public bool IsSelected
            {
                get { return this._IsSelected; }
                set { this.SetProperty(ref this._IsSelected, value, "IsSelected"); }
            }
        }
    }


}
