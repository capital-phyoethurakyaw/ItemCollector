using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Nancy.Json;

namespace ItemCollector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static HttpClient client = new HttpClient();
        
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            //Find End Point in your ways
            List<asset> assests = new List<asset>();
            int No = 0;
            for (int i = 20; i <= 600; i += 20)
            {
                var start = i - 20;
                var final = i;
                var client = new RestClient("https://stg-de.piksel.tech/ws/ws_asset/api/token/u/access/mode/json/apiv/5?datemod_start=2000/01/0100:00:00&datemod_end=2022/09/2700:00:00&sortdir=asc&start=" + start + "&end=" + final);
                var request = new RestRequest();
                RestResponse res = client.Execute(request);
                if (res.StatusCode.ToString() == "OK")
                {
                    string content =  res.Content ; 
                    var serial = JsonConvert.DeserializeObject<Root>(content);
                    if (serial.response.success.code == "304")
                    {
                        foreach (var c in serial.response.WsAssetResponse.asset)
                        {
                            No++;
                            c.No = No.ToString();
                            assests.Add(c);
                        }
                    }
                } 

            }
            dataGridView1.DataSource = assests;
           
                   

        }
        protected class Root
        {
            public response response { get; set; }
        }
        protected class response
        {
            public WsAssetResponse WsAssetResponse { get;set; }
            public success success { get; set; }
        }
        protected class success
        {
            public string code { get; set; }
        }
        protected class WsAssetResponse
        {
            public List<asset> asset { get; set; }
        }
     protected class asset
        {
            public string No { get; set; }
            public string assetid { get; set; }
            public string title { get; set; }
            public string dateadd { get; set; }
            public string datemod { get; set; }
            public string defaultThumb { get; set; }
            public string description { get; set; }
            public string tags { get; set; }
            public string isActive { get; set; }
            public string isHidden { get; set; }
            public string posterThumb { get; set; }
            public string geoFilterId { get; set; }
            public string uuid { get; set; }
            public string isPublish { get; set; }
            public string date_start { get; set; }
            public string date_end { get; set; }
            public string youtubePublishable { get; set; }
            public string clientuuid { get; set; }
            public string caption { get; set; }
            //public string AssessID { get; set; }
            //public string AssessID { get; set; }
            //public string AssessID { get; set; }
            //public string AssessID { get; set; }
            //public string AssessID { get; set; }
            //public string AssessID { get; set; }

            //public string AssessID { get; set; }

        }
    }
     
}
