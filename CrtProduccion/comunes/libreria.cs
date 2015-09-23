﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CrtProduccion.comunes
{
    class libreria
    {
        public static void limpiaControles(DependencyObject obj)
        {
            // Limpia todos los conbroles de un contenedor
            TextBox tb = obj as TextBox;
            RadioButton rb = obj as RadioButton;
            PasswordBox pb = obj as PasswordBox;
            
            if (tb != null) tb.Text = "";
            if (rb != null) rb.IsChecked = false;
            if (pb != null) pb.Password = "";
            
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj as DependencyObject); i++)
                limpiaControles(VisualTreeHelper.GetChild(obj, i));
        }

        public static void estadoControles(DependencyObject obj, bool isenabled)
        {
            // habilita todos los controles de estas clase
            TextBox tb = obj as TextBox;
            RadioButton rb = obj as RadioButton;
            PasswordBox pb = obj as PasswordBox;
            ComboBox cb = obj as ComboBox;

            if (tb != null) tb.IsEnabled = isenabled;
            if (rb != null) rb.IsEnabled = isenabled;
            if (pb != null) pb.IsEnabled = isenabled;
            if (cb != null) cb.IsEnabled = isenabled;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj as DependencyObject); i++)
                estadoControles(VisualTreeHelper.GetChild(obj, i), isenabled);
        }

  
        public static void Next_if_Enter(object sender, KeyEventArgs e)
        {
            // Hace que la tecla enter pase al siguiente control.
            TextBox s = e.Source as TextBox;
            if (s != null)
            {
                if (e.Key == Key.Enter)
                    s.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }

    }
}