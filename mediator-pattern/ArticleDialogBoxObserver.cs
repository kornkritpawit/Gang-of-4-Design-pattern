using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_mediator;

namespace mediator_pattern
{
    public class ArticleDialogBoxObserver
    {
        private ListBoxObserver _articleListBox;
        private TextBoxObserver _titleTextBox;
        private ButtonObserver _saveButton;

        public ArticleDialogBoxObserver()
        {
            _articleListBox = new ListBoxObserver();
            _articleListBox.AddEventHandler(articleChanged); // Action คือชื่อ function
            // _articleListBox.AddEventHandler(() => {
                //คือวิธีเหมือนด้านบน
            // });
            _titleTextBox = new TextBoxObserver();
            _titleTextBox.AddEventHandler(titleChanged);
            _saveButton = new ButtonObserver();
        }

        public void SimulateChanges() {
            _articleListBox.Selection = "Article 1";
            // _titleTextBox.Text = "";
            Console.WriteLine("Listbox: " + _articleListBox.Selection);
            Console.WriteLine("Textbox : "+ _titleTextBox.Text);
            Console.WriteLine("Button : "+ _saveButton.IsEnabled);
        }
        // public override void OnChanged(UIControl control)
        // {
        //     if (control == _articleListBox) {
        //         articleChanged();
        //     } else if (control == _titleTextBox) {
        //         titleChanged();
        //     } 
        // }

        private void articleChanged() {
            _titleTextBox.Text = _articleListBox.Selection;
            _saveButton.IsEnabled = true;
        }
        private void titleChanged() {
            var content = _titleTextBox.Text;
            var isEmpty = string.IsNullOrEmpty(content);
            _saveButton.IsEnabled = !isEmpty;
            // ถ้า content ไม่ empty ก็จะเปิด ปุ่ม
        }
    }
}