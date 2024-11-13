using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DXMauiApp46 {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }

    }

    public class MainViewModel : INotifyPropertyChanged {

        public void OnPropertyChanged(string info) {
            if (this.PropertyChanged != null) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            MoveUpCommand = new Command(Up, CanMove);
            MoveDownCommand = new Command(Down, CanMove);
        }

        public Command MoveUpCommand { get; set; }
        public Command MoveDownCommand { get; set; }

        public bool CanMove() {
            return !string.IsNullOrEmpty(this.SelectedItem);
        }

        public void Up() {
            var idx = this.Items.IndexOf(this.SelectedItem);
            if (idx > 1) {
                this.Items.Move(idx, idx - 1);
            }
        }

        public void Down() {
            var idx = this.Items.IndexOf(this.SelectedItem);
            if(idx + 1 < this.Items.Count - 1) {
                this.Items.Move(idx, idx + 1);
            }
        }


        protected ObservableCollection<string> _Items;
        public ObservableCollection<string> Items {
            get {
                if (this._Items == null) {
                    this._Items = new ObservableCollection<string>(Enumerable.Range(0, 100).Select(c => $"Item {c}"));
                }

                return this._Items;
            }
        }

        protected string _SelectedItem;

        public string SelectedItem {
            get {
                return this._SelectedItem;
            }

            set {
                if (this._SelectedItem != value) {
                    this._SelectedItem = value;
                    this.OnPropertyChanged("SelectedItem");
                    this.MoveUpCommand.ChangeCanExecute();
                    this.MoveDownCommand.ChangeCanExecute();
                }
            }
        }
    }
}