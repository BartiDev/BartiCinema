using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace CustomerCinemaDesktopUI.CustomControls
{
    public class CustomComboBox : ComboBox
    {
        private int caretPosition;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var element = GetTemplateChild("PART_EditableTextBox");
            if(element != null)
            {
                var textBox = (TextBox)element;
                textBox.SelectionChanged += OnDropSelectionChanged;
            }
        }

        private void OnDropSelectionChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if(txt.SelectionLength > 0)
            {
                caretPosition = txt.SelectionLength;
                txt.SelectionLength = 0;
                txt.CaretIndex = caretPosition;
            }
        }
    }
}
