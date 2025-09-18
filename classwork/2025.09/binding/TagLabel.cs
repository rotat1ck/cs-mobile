using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binding {
    internal class TagLabel : Label {
        public static readonly BindableProperty TagProperty =
            BindableProperty.Create("Tag", // Название обычного свойства
                typeof(string), // Возвращаемый тип
                typeof(TagLabel), // Тип к которому объявляется свойство
                "0"); // Значение по умолчанию

        public string Tag {
            get => (string)GetValue(TagProperty);

            set {
                SetValue(TagProperty, value);
            }
        }
    }


}
