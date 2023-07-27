using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;

namespace model
{
    public class ResponseViewModel
    {
        public string Timestamp { get; set; }
        public string? Message { get; set; }
        public int Code { get; set; }
        public Information Body { get; set; }
    }
    [XmlRoot("INFORMATION")]
    public class Information
    {
        [XmlElement("ADDITIONAL_FIELDS")]
        public List<ADDITIONAL_FIELDS> UserDetails { get; set; }
    }

    public class ADDITIONAL_FIELDS
    {
        [XmlElement("ZPRDTYP")]
        public string ProductType { get; set; }
        [XmlElement("RSTERM")]
        public decimal RiskTerm { get; set; }
        [XmlElement("PMTERM")]
        public decimal PremiumTerm { get; set; }
        [XmlElement("PAYMMETH")]
        public string? PaymentMethod { get; set; }
        [XmlElement("PAYFREQ")]
        public string? PaymentFrequency { get; set; }
        [XmlElement("RCDDATE")]
        public decimal RiskCommencementDate { get; set; }
        [XmlElement("LASEX")]
        public string LifeAssuredGender { get; set; }
        [XmlElement("LADOB")]
        public decimal LifeAssuredDateOfBirth { get; set; }
        [XmlElement("LACRTBL")]
        public string LifeAssuredComponentCode { get; set; }
        [XmlElement("LAINSPR")]
        public decimal LifeAssuredInstallmentPremium { get; set; }
    }

    public class Methods
    {
        public Information XmlToModel(string str)
        {
            var doc = new XmlDocument();
            doc.LoadXml(str);
            XmlElement root = doc.DocumentElement;
            var xNodeReader = new XmlNodeReader(root);
            var serializer = new XmlSerializer(typeof(Information));
            var i = (Information)serializer.Deserialize(xNodeReader);
            return i;
        }

        public void ModelTOJson(ResponseViewModel r)
        {
            string json = JsonConvert.SerializeObject(r, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);


        }
    }
}
