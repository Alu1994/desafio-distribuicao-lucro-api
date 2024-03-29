﻿using System.Net.Http;

namespace DistribuicaoLucro.Repository.FirebaseWrapper
{
    public class FirebaseResponse
    {
        public FirebaseResponse()
        {
        }

        public FirebaseResponse(bool success, string errorMessage, HttpResponseMessage httpResponse = null, string jsonContent = null)
        {
            this.Success = success;
            this.JSONContent = jsonContent;
            this.ErrorMessage = errorMessage;
            this.HttpResponse = httpResponse;
        }

        public bool Success { get; set; }

        public string JSONContent { get; set; }

        public string ErrorMessage { get; set; }

        public HttpResponseMessage HttpResponse { get; set; }
    }
}