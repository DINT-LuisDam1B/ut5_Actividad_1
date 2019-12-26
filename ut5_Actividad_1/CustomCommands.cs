using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ut5_Actividad_1
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Salir = new RoutedUICommand
            (
                "Salir",
                "Salir",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.S, ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand Enviar = new RoutedUICommand
            (
                "Enviar",
                "Enviar",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.U, ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand Guardar = new RoutedUICommand
            (
                "Guardar",
                "Guardar",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.G, ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand Propiedades = new RoutedUICommand
           (
               "Propiedades",
               "Propiedades",
               typeof(CustomCommands),
               new InputGestureCollection()
               {
                    new KeyGesture(Key.C, ModifierKeys.Control)
               }
           );
        public static readonly RoutedUICommand Conectar = new RoutedUICommand
           (
               "Conectar",
               "Conectar",
               typeof(CustomCommands),
               new InputGestureCollection()
               {
                    new KeyGesture(Key.O, ModifierKeys.Control)
               }
           );
    }
}
