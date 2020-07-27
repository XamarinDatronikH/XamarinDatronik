using System;
namespace XamarinDatronik.Models
{
    public class DragAndDropListItem
    {
        public DragAndDropListItem(string text, string imageSource = null, object actualObject = null)
        {
            Text = text;
            ImageSource = imageSource;
            ActualObject = actualObject;
        }

        public string Text { get; set; }

        public string ImageSource { get; set; }

        public object ActualObject { get; set; }
    }
}
