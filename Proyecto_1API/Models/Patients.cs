namespace Proyecto_1API.Models
{
    public class Patients
    {
        public int id { get; set; }
        public string id_number { get; set; }
        public string name { get; set; }
        public string surname_1 { get; set; }
        public string surname_2 { get; set; }

        public string birth_date { get; set; }
        /*public string birth_date {
            get { return this._birth_date; }
            set { this._birth_date = value.ToString(); }
        }*/
        public string gender { get; set; }
        public string contact_number { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string canton { get; set; }
        public string district { get; set; }
        public string marital_status { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string register_date { get; set; }

        /*public string register_date
        {
            get { return this._register_date; }
            set { this._register_date = value.ToString(); }
        }*/
        public string occupation { get; set; }

    }
}
