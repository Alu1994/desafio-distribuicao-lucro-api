using System;
using System.Net.Http;

namespace DistribuicaoLucro.Repository.FirebaseWrapper
{
    public class FirebaseRequest
    {
        private const string JSON_SUFFIX = ".json";
  
        public FirebaseRequest(HttpMethod method, string uri, string jsonString = null)
        {
            this.Method = method;
            this.JSON = jsonString;
            if (uri.Replace("/", string.Empty).EndsWith("firebaseio.com"))
            {
                this.Uri = $"{uri}/{JSON_SUFFIX}";
                return;
            }
            this.Uri = uri + JSON_SUFFIX;
        }

        private HttpMethod Method { get; set; }

        private string JSON { get; set; }

        private string Uri { get; set; }

        public FirebaseResponse Execute()
        {
            Uri requestURI;
            if (!UtilityHelper.ValidateURI(this.Uri))
                return new FirebaseResponse(false, "Firebase path não é uma url HTTP/S válida.");
            requestURI = new Uri(this.Uri);

            string json = null;
            if (this.JSON != null)
                if (!UtilityHelper.TryParseJSON(this.JSON, out json))
                    return new FirebaseResponse(false, $"JSON Inválido: {json}");

            var response = UtilityHelper.RequestHelper(this.Method, requestURI, json);
            response.Wait();
            var result = response.Result;

            var firebaseResponse = new FirebaseResponse()
            {
                HttpResponse = result,
                ErrorMessage = $"{result.StatusCode} : {result.ReasonPhrase}",
                Success = response.Result.IsSuccessStatusCode
            };

            if (this.Method.Equals(HttpMethod.Get))
            {
                var content = result.Content.ReadAsStringAsync();
                content.Wait();
                firebaseResponse.JSONContent = content.Result;
            }

            return firebaseResponse;
        }
    }
}
