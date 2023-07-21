using model;

namespace XMLToJson
{
    class Program
    {
        static void Main()
        {
            string xmlPayload = "<INFORMATION>\r\n    <ADDITIONAL_FIELDS>\r\n        <ZPRDTYP>DS1</ZPRDTYP>\r\n        <RSTERM>666</RSTERM>\r\n        <PMTERM>66666</PMTERM>\r\n        <PAYMMETH>M</PAYMMETH>\r\n        <PAYFREQ>01</PAYFREQ>\r\n        <RCDDATE>20220802</RCDDATE>\r\n        <LASEX>M</LASEX>\r\n        <LADOB>19920606</LADOB>\r\n        <LACRTBL>DTR2</LACRTBL>\r\n        <LAINSPR>200</LAINSPR>\r\n    </ADDITIONAL_FIELDS>\r\n    <ADDITIONAL_FIELDS>\r\n        <ZPRDTYP>DS2</ZPRDTYP>\r\n        <RSTERM>6</RSTERM>\r\n        <PMTERM>6</PMTERM>\r\n        <PAYMMETH>M</PAYMMETH>\r\n        <PAYFREQ>01</PAYFREQ>\r\n        <RCDDATE>20220802</RCDDATE>\r\n        <LASEX>M</LASEX>\r\n        <LADOB>19920606</LADOB>\r\n        <LACRTBL>DTR2</LACRTBL>\r\n        <LAINSPR>200</LAINSPR>\r\n    </ADDITIONAL_FIELDS>\r\n</INFORMATION>";
            Methods obj = new Methods();

            var i = obj.XmlToModel(xmlPayload);

            ResponseViewModel response = new ResponseViewModel
            {
                Timestamp = DateTime.Now.ToString(),
                Message = "success",
                Code = 200,
                Body = new Information
                {
                    UserDetails = i.UserDetails
                }
            };

            //DefaultContractResolver contractResolver = new DefaultContractResolver
            //{
            //    NamingStrategy = new CamelCaseNamingStrategy()
            //};
            //string json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
            //{
            //    ContractResolver = contractResolver,
            //    Formatting = Newtonsoft.Json.Formatting.Indented,
            //});

           obj.ModelTOJson(response);

        }
    }

    
}