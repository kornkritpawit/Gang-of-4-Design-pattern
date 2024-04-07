using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_mediator;

namespace mediator_pattern
{
    public class ArticleDialogBox
    {
        private ListBox _articleListBox;
        private TextBox _titleTextBox;
        private Button _saveButton;
        public ArticleDialogBox()
        {
            _articleListBox = new ListBox();
            _articleListBox.AddEventHandler(articleChanged); // Action คือชื่อ function
            // _articleListBox.AddEventHandler(() => {
                //คือวิธีเหมือนด้านบน
            // });
            _titleTextBox = new TextBox();
            _titleTextBox.AddEventHandler(titleChanged);
            _saveButton = new Button();
        }
        public void SimulateChanges() {
            _articleListBox.Selection = "Article 1";
            Console.WriteLine("Listbox: " + _articleListBox.Selection);
            Console.WriteLine("Textbox : "+ _titleTextBox.Text);
            Console.WriteLine("Button : "+ _saveButton.IsEnabled);
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