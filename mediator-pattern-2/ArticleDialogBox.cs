using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_mediator;

namespace mediator_pattern
{
    public class ArticleDialogBox : DialogBox
    {
        private ListBox _articleListBox;
        private TextBox _titleTextBox;
        private Button _saveButton;

        public ArticleDialogBox()
        {
            _articleListBox = new ListBox(this);
            _titleTextBox = new TextBox(this);
            _saveButton = new Button(this);
        }

        public void SimulateChanges() {
            _articleListBox.Selection = "Article 1";
            // _titleTextBox.Text = "";
            Console.WriteLine("Listbox: " + _articleListBox.Selection);
            Console.WriteLine("Textbox : "+ _titleTextBox.Text);
            Console.WriteLine("Button : "+ _saveButton.IsEnabled);
        }
        public override void OnChanged(UIControl control)
        {
            if (control == _articleListBox) {
                articleChanged();
            } else if (control == _titleTextBox) {
                titleChanged();
            } 
            // 
        }

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