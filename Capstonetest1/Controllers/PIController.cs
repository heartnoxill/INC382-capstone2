using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Capstonetest1.Models;

namespace Capstonetest1.Controllers
{
    [ApiController]
    [Route("api/pi")]
    public class PIController : ControllerBase
    {
        private readonly string username = "group1";
        private readonly string password = "inc.382";
        private readonly ILogger<PIController> _logger;
        public PIController(ILogger<PIController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetItemValuesAsync(string itemname)
        {
            try
            {
                //business logic
                var credentials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);

                string webId = "";
                string piserverURL = @$"https://202.44.12.146:1443/piwebapi/points/?path=\\PISRV\{itemname}";

                using(HttpResponseMessage response = await client.GetAsync(piserverURL))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    webId = JObject.Parse(content)["WebId"].Value<string>();
                    Console.WriteLine(webId);
                }

                string itemURL = @$"https://202.44.12.146:1443/piwebapi/streams/{webId}/recorded";

                using(HttpResponseMessage response = await client.GetAsync(itemURL))
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var data = (JArray)JObject.Parse(content)["Items"];
                    var result = new List<TagValue>();

                    foreach(var item in data)
                    {
                        if(item["Good"].Value<bool>() == true)
                        {
                            var dataPair = new TagValue()
                            {
                                Values = item["Value"].Value<string>(),
                                TimeStamp = item["Timestamp"].Value<DateTime>()
                            };

                            result.Add(dataPair);
                        }
                    }

                    return Ok(new { result = result, message = "success" });
                }
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("getDieselVol1/{selDate}")]
        public async Task<IActionResult> getDieselVol1(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3wgxUAAAUElTUlZcQTAwMS0wMTAwLU8xLUFJMDAx/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("getDieselVolDaily/{selDate}")]
        public async Task<IActionResult> getDieselVolDaily(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3wyhUAAAUElTUlZcQTAwMS0wMDAwLVMzLURBVEEwMjA/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("avgSalesWaiting/{selDate}")]
        public async Task<IActionResult> avgSalesWaiting(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3wzBUAAAUElTUlZcQTAwMS0wMDAwLVMzLURBVEEwMDE/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("avgInwbWaiting/{selDate}")]
        public async Task<IActionResult> avgInwbWaiting(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3wzRUAAAUElTUlZcQTAwMS0wMzAwLVMzLURBVEEwMDI/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("avgDieselWaiting/{selDate}")]
        public async Task<IActionResult> avgDieselWaiting(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3wzxUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMDM/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("avgGas95Waiting/{selDate}")]
        public async Task<IActionResult> avgGas95Waiting(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w0BUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMDQ/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("avgOutwbWaiting/{selDate}")]
        public async Task<IActionResult> avgOutwbWaiting(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w0RUAAAUElTUlZcQTAwMS0wNDAwLVMzLURBVEEwMDU/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("noFailedDiesel/{selDate}")]
        public async Task<IActionResult> noFailedDiesel(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w0hUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMDY/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("noFailedGas95/{selDate}")]
        public async Task<IActionResult> noFailedGas95(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w0xUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMDc/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("noTruckIn/{selDate}")]
        public async Task<IActionResult> noTruckIn(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w1BUAAAUElTUlZcQTAwMS0wMzAwLVMzLURBVEEwMDg/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("noTruckOut/{selDate}")]
        public async Task<IActionResult> noTruckOut(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w1RUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMDk/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("dailyDieselAvgCycle/{selDate}")]
        public async Task<IActionResult> dailyDieselAvgCycle(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w2hUAAAUElTUlZcQTAwMS0wMzAwLVMzLURBVEEwMTQ/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("dailyGas95AvgCycle/{selDate}")]
        public async Task<IActionResult> dailyGas95AvgCycle(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w3RUAAAUElTUlZcQTAwMS0wMzAwLVMzLURBVEEwMTc/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("getGas95lVolDaily/{selDate}")]
        public async Task<IActionResult> getGas95lVolDaily(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w4hUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMjM/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        ///////////////////////// MONTHLY

        [HttpGet("monthlyTruckIn")]
        public async Task<IActionResult> monthlyTruckIn()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w2BUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMTI/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyTruckOut")]
        public async Task<IActionResult> monthlyTruckOut()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w2RUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMTM/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyDieselAvgCycle")]
        public async Task<IActionResult> monthlyDieselAvgCycle()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w3BUAAAUElTUlZcQTAwMS0wNzAwLVMzLURBVEEwMTY/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyGas95AvgCycle")]
        public async Task<IActionResult> monthlyGas95AvgCycle()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w3xUAAAUElTUlZcQTAwMS0wNzAwLVMzLURBVEEwMTk/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyDieselFilling")]
        public async Task<IActionResult> monthlyDieselFilling()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w4RUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMjI/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyGas95Filling")]
        public async Task<IActionResult> monthlyGas95Filling()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w5BUAAAUElTUlZcQTAwMS0wMDAwLVMzLURBVEEwMjU/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyAvgSCHSales")]
        public async Task<IActionResult> monthlyAvgSCHSales()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w5hUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMjc/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyAvgSCHInwb")]
        public async Task<IActionResult> monthlyAvgSCHInwb()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w6BUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMjk/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyAvgSCHDiesel")]
        public async Task<IActionResult> monthlyAvgSCHDiesel()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w6hUAAAUElTUlZcQTAwMS0wNzAwLVMzLURBVEEwMzE/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyAvgSCHGas95")]
        public async Task<IActionResult> monthlyAvgSCHGas95()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w7BUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMzM/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyAvgSCHOutwb")]
        public async Task<IActionResult> monthlyAvgSCHOutwb()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w7hUAAAUElTUlZcQTAwMS0wMDAwLVMzLURBVEEwMzU/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyFailedDiesel")]
        public async Task<IActionResult> monthlyFailedDiesel()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w8RUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMzg/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyFailedGas95")]
        public async Task<IActionResult> monthlyFailedGas95()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w8hUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMzk/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlySalesWait")]
        public async Task<IActionResult> monthlySalesWait()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w-BUAAAUElTUlZcQTAwMS0wMDAwLVMzLURBVEEwNDU/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyInwbWait")]
        public async Task<IActionResult> monthlyInwbWait()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w-RUAAAUElTUlZcQTAwMS0wMzAwLVMzLURBVEEwNDY/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyDieselWait")]
        public async Task<IActionResult> monthlyDieselWait()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w-hUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwNDc/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyGas95Wait")]
        public async Task<IActionResult> monthlyGas95Wait()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w-xUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwNDg/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("monthlyOutwbWait")]
        public async Task<IActionResult> monthlyOutwbWait()
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                DateTime month = new DateTime(2022,4,29);
                // TimeSpan value =  today.Subtract(selDate);
                TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w_BUAAAUElTUlZcQTAwMS0wNDAwLVMzLURBVEEwNDk/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //////////////////// WEEKLY

        [HttpGet("weeklyTruckIn/{selDate}")]
        public async Task<IActionResult> weeklyTruckIn(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w1hUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMTA/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyTruckOut/{selDate}")]
        public async Task<IActionResult> weeklyTruckOut(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w1xUAAAUElTUlZcQTAwMS0wNDAwLVMzLURBVEEwMTE/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyDieselAvgCycle/{selDate}")]
        public async Task<IActionResult> weeklyDieselAvgCycle(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w2xUAAAUElTUlZcQTAwMS0wNDAwLVMzLURBVEEwMTU/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyGas95AvgCycle/{selDate}")]
        public async Task<IActionResult> weeklyGas95AvgCycle(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w3hUAAAUElTUlZcQTAwMS0wNDAwLVMzLURBVEEwMTg/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyDieselFilling/{selDate}")]
        public async Task<IActionResult> weeklyDieselFilling(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w4BUAAAUElTUlZcQTAwMS0wMzAwLVMzLURBVEEwMjE/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyGas95Filling/{selDate}")]
        public async Task<IActionResult> weeklyGas95Filling(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w4xUAAAUElTUlZcQTAwMS0wNDAwLVMzLURBVEEwMjQ/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyAvgSCHSales/{selDate}")]
        public async Task<IActionResult> weeklyAvgSCHSales(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w5RUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMjY/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyAvgSCHInwb/{selDate}")]
        public async Task<IActionResult> weeklyAvgSCHInwb(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w5xUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMjg/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyAvgSCHDiesel/{selDate}")]
        public async Task<IActionResult> weeklyAvgSCHDiesel(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w6RUAAAUElTUlZcQTAwMS0wNDAwLVMzLURBVEEwMzA/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyAvgSCHGas95/{selDate}")]
        public async Task<IActionResult> weeklyAvgSCHGas95(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w6xUAAAUElTUlZcQTAwMS0wMzAwLVMzLURBVEEwMzI/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyAvgSCHOutwb/{selDate}")]
        public async Task<IActionResult> weeklyAvgSCHOutwb(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w7RUAAAUElTUlZcQTAwMS0wNDAwLVMzLURBVEEwMzQ/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyFailedDiesel/{selDate}")]
        public async Task<IActionResult> weeklyFailedDiesel(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w7xUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMzY/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyFailedGas95/{selDate}")]
        public async Task<IActionResult> weeklyFailedGas95(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w8BUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwMzc/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklySalesWait/{selDate}")]
        public async Task<IActionResult> weeklySalesWait(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w8xUAAAUElTUlZcQTAwMS0wMDAwLVMzLURBVEEwNDA/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyInwbWait/{selDate}")]
        public async Task<IActionResult> weeklyInwbWait(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w9BUAAAUElTUlZcQTAwMS0wMzAwLVMzLURBVEEwNDE/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyDieselWait/{selDate}")]
        public async Task<IActionResult> weeklyDieselWait(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w9RUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwNDI/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyGas95Wait/{selDate}")]
        public async Task<IActionResult> weeklyGas95Wait(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w9hUAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwNDM/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("weeklyOutwbWait/{selDate}")]
        public async Task<IActionResult> weeklyOutwbWait(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3w9xUAAAUElTUlZcQTAwMS0wNDAwLVMzLURBVEEwNDQ/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        ///// INVENTORY STOCK LINE GRAPH

        [HttpGet("InventoryStockDiesel/{selDate}")]
        public async Task<IActionResult> InventoryStockDiesel(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3wAhYAAAUElTUlZcQTAwMS0wMzAwLVMzLURBVEEwNTA/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("InventoryStockGas95/{selDate}")]
        public async Task<IActionResult> InventoryStockGas95(DateTime selDate)
        {
            try
            {
                var credentrials = new NetworkCredential(username, password);
                HttpClientHandler clientHandler = new HttpClientHandler { Credentials = credentrials };
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; // access to https
                HttpClient client = new HttpClient(clientHandler);

                DateTime today = DateTime.Now;
                // DateTime month = new DateTime(2022,4,29);
                TimeSpan value =  today.Subtract(selDate);
                // TimeSpan value =  today.Subtract(month);

                string starttime = Convert.ToString(Convert.ToInt32(value.TotalDays));
                string endtime = Convert.ToString(Convert.ToInt32(value.TotalDays) - 1);

                string itemURL = $@"https://202.44.12.146:1443/piwebapi/streams/F1DP9bkh7eqdMUSKGalDzu9F3wAxYAAAUElTUlZcQTAwMS0wMTAwLVMzLURBVEEwNTE/recorded?starttime=*-{starttime}d&endtime=*-{endtime}d";

                HttpResponseMessage response = await client.GetAsync(itemURL);

                string content = await response.Content.ReadAsStringAsync();
                var data = (JArray)JObject.Parse(content)["Items"];
                var result = new List<TagValue>();

                foreach(var item in data)
                {
                    if(item["Good"].Value<bool>() == true)
                    {
                        var dataPair = new TagValue()
                        {
                            Values = item["Value"].Value<string>(),
                            TimeStamp = item["Timestamp"].Value<DateTime>()
                        };

                        result.Add(dataPair);
                    }
                }

                return Ok(new {result=result, message="success"});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}