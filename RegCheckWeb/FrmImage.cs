namespace RegCheckWeb
{
    public partial class FrmImage : Form
    {
        public FrmImage()
        {
            InitializeComponent();
        }

        private string slika;
        /// <summary>Putanja slike zaposlenog</summary>
        public string Slika
        {
            get { return slika; }
            set
            {
                slika = value;
                pic.Image = new Bitmap(slika);

                //this.Width = pic.Image.Width + this.Width - pic.Width;
                //this.Height = pic.Image.Height + this.Height - pic.Height;
            }
        }
    }
}
