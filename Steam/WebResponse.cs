namespace FightSabers.Misc
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    internal class WebResponse
    {
        public readonly HttpStatusCode StatusCode;
        public readonly string ReasonPhrase;
        public readonly HttpResponseHeaders Headers;
        public readonly HttpRequestMessage RequestMessage;
        public readonly bool IsSuccessStatusCode;
        private readonly byte[] _content;

        internal WebResponse(HttpResponseMessage resp, byte[] content)
        {
            this.StatusCode = resp.StatusCode;
            this.ReasonPhrase = resp.ReasonPhrase;
            this.Headers = resp.Headers;
            this.RequestMessage = resp.RequestMessage;
            this.IsSuccessStatusCode = resp.IsSuccessStatusCode;
            this._content = content;
        }

        public byte[] ContentToBytes() => 
            this._content;

        public T ContentToJson<T>() => 
            JsonConvert.DeserializeObject<T>(this.ContentToString());

        public string ContentToString() => 
            Encoding.UTF8.GetString(this._content);

        public JObject ConvertToJObject() => 
            JObject.Parse(this.ContentToString());
    }
}
