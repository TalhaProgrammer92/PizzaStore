using System.Windows;
using System.Windows.Controls;

namespace PizzaStore.Presentation.Helpers
{
    public class PasswordBoxHelper
    {
        //public static readonly DependencyProperty BoundPassword =
        //   DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxHelper),
        //       new PropertyMetadata(string.Empty, OnBoundPasswordChanged));
        
        // Added binding support to tell XAML
        public static readonly DependencyProperty BoundPassword =
            DependencyProperty.RegisterAttached(
                "BoundPassword",
                typeof(string),
                typeof(PasswordBoxHelper),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnBoundPasswordChanged
                ));


        public static string GetBoundPassword(DependencyObject dp) =>
            (string)dp.GetValue(BoundPassword);

        public static void SetBoundPassword(DependencyObject dp, string value) =>
            dp.SetValue(BoundPassword, value);

        private static bool _isUpdating = false;

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                passwordBox.PasswordChanged -= PasswordChanged;

                if (!_isUpdating)
                {
                    string newPassword = e.NewValue?.ToString() ?? string.Empty;

                    if (passwordBox.Password != newPassword)
                    {
                        passwordBox.Password = newPassword;
                    }
                }

                passwordBox.PasswordChanged += PasswordChanged;
            }
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                _isUpdating = true;
                SetBoundPassword(passwordBox, passwordBox.Password);
                _isUpdating = false;
            }
        }
    }
}
