namespace AppMVC.Models
{
    public class SummerNote{
        public SummerNote(string iDEditor, bool loadLib = true)
        {
            IDEditor = iDEditor;
            LoadLib = loadLib;
        }

        public string IDEditor {get; set;}

        public bool LoadLib {get; set;}

        public int Height {get; set;} = 120;

        public string Toolbar {get; set;} = @"
        [
          ['style', ['style']],
          ['font', ['bold', 'underline', 'clear']],
          ['color', ['color']],
          ['para', ['ul', 'ol', 'paragraph']],
          ['table', ['table']],
          ['insert', ['link', 'picture', 'video']],
          ['view', ['fullscreen', 'codeview', 'help']],
          ['height', ['height']]
        ]
        ";
    }
}