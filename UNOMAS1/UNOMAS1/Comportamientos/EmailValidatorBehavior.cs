using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace UNOMAS1
{
    class EmailValidatorBehavior : Behavior<Entry>
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        static readonly BindablePropertyKey IntValuePropertyKey = BindableProperty.CreateReadOnly("IntValue", typeof(int), typeof(EmailValidatorBehavior), 0);
        public static readonly BindableProperty IntValueProperty = IntValuePropertyKey.BindableProperty;
        public int IntValue
        {
            get { return (int)base.GetValue(IntValueProperty); }
            private set { base.SetValue(IntValuePropertyKey, value); }
        }

        //Variable para saber si el campo es obligatorio
        public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create("IsRequired", typeof(bool), typeof(EmailValidatorBehavior), false);
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == "")
            {
                if (IsRequired)
                    IntValue = 4;
                else
                    IntValue = 0;
            }
            else
            {
                bool IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));

                if (IsValid)
                    IntValue = 1;
                else
                    IntValue = 2;

                ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }
    }
}
