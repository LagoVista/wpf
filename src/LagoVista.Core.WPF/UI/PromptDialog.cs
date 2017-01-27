using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LagoVista.Core.WPF.UI
{
    internal class PromptDialog<T> : Window
    {
        TextBox _textInput;
        TextBlock _help;

        public bool isRequired { get; set; }

        public PromptDialog()
        {
            Width = 200;
            Height = 100;
            var container = new Grid();
            container.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            container.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            container.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            container.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            container.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            container.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            Content = container;

            Button okButton = new Button();
            okButton.Margin = new Thickness(4);
            okButton.Content = "Done";
            okButton.SetValue(Grid.ColumnProperty, 1);
            okButton.SetValue(Grid.RowProperty, 2);
            container.Children.Add(okButton);
            okButton.Click += (sndr, args) => { if (IsValid) Close(); };

            Button cancelButton = new Button();
            cancelButton.Margin = new Thickness(4);
            cancelButton.Content = "Cancel";
            cancelButton.SetValue(Grid.ColumnProperty, 2);
            cancelButton.SetValue(Grid.RowProperty, 2);
            container.Children.Add(cancelButton);
            cancelButton.Click += (sndr, args) => Close();

            _help = new TextBlock();
            _help.SetValue(Grid.ColumnSpanProperty, 2);
            _help.Visibility = Visibility.Collapsed;
            container.Children.Add(_help);

            _textInput = new TextBox();
            _textInput.SetValue(Grid.RowProperty, 1);
            _textInput.SetValue(Grid.ColumnSpanProperty, 2);
            _textInput.Margin = new Thickness(4);
            container.Children.Add(_textInput);

            if (typeof(T) == typeof(int))
            {
                _textInput.TextAlignment = TextAlignment.Right;
                Masking.SetMask(_textInput, @"^\d+$");
            }

            if (typeof(T) == typeof(decimal))
            {
                _textInput.TextAlignment = TextAlignment.Right;
                Masking.SetMask(_textInput, @"^[0-9]+\.?([0-9][0-9]?)?$");
            }
        }

        public String Help
        {
            get
            {
                return _help.Text;
            }
            set
            {
                _help.Text = value;
                if (String.IsNullOrEmpty(value))
                {
                    Height = 100;
                    _help.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Height = 140;
                    _help.Visibility = Visibility.Visible;
                }
            }
        }

        public bool HasValue
        {
            get { return !String.IsNullOrEmpty(_textInput.Text); }
        }

        public bool IsValid
        {
            get
            {
                if (!isRequired)
                {
                    return true;
                }

                if (String.IsNullOrEmpty(_textInput.Text))
                {
                    return false;
                }

                if (typeof(T) == typeof(int))
                {
                    decimal val;
                    return decimal.TryParse(_textInput.Text, out val);
                }
                else if (typeof(T) == typeof(decimal))
                {
                    decimal val;
                    return decimal.TryParse(_textInput.Text, out val);
                }
                else if (typeof(T) == typeof(string))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Invalid Type");
                }
            }
        }

        public String StringValue
        {
            get { return _textInput.Text; }
            set { _textInput.Text = value; }
        }

        public Decimal? DecimalVaue
        {
            get
            {
                decimal val;
                if (decimal.TryParse(_textInput.Text, out val))
                    return val;
                else
                    return null;
            }
            set
            {
                _textInput.Text = value.HasValue ? value.ToString() : String.Empty;
            }
        }

        public int? IntValue
        {
            get
            {
                int val;
                if (int.TryParse(_textInput.Text, out val))
                    return val;
                else
                    return null;
            }
            set
            {
                _textInput.Text = value.HasValue ? value.ToString() : String.Empty;
            }
        }
    }


}
