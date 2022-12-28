using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator8
{
    internal class ViewModel:INotifyPropertyChanged
    {
        private Model _model;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        void OnSumChanged()
        {
            OnPropertyChanged(nameof(Sum));
        }
        public int Adder1
        {
            get { return _model.Adder1; }
            set { _model.Adder1 = value; }
        }
        public int Adder2
        {
            get { return _model.Adder2; }
            set { _model.Adder2 = value; }
        }
        public int Sum
        {
            get { return _model.Sum; }
            set { _model.Sum = value; }
        }
        public ICommand AddCommand { get; }
        public ViewModel()
        {
            _model = new Model();
            AddCommand = new AddCommand();
            ((AddCommand)AddCommand).Called += _model.Add;
            _model.SumChanged += OnSumChanged;
        }
    }
    internal class AddCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public event Action Called;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Called?.Invoke();
        }
    }
}
